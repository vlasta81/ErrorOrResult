using ErrorOrResult;

namespace ErrorOrResultTests;

public class ResultAdvancedExtensionsTests
{
    [Fact]
    public void Ensure_WhenPredicatePasses_ShouldReturnOriginalSuccessResult()
    {
        var result = Result.Success(10);

        var ensured = result.Ensure(x => x > 5, Error.Validation("Test", "Value too small"));

        Assert.True(ensured.IsSuccess);
        Assert.Equal(10, ensured.Value);
    }

    [Fact]
    public void Ensure_WhenPredicateFails_ShouldReturnErrorResult()
    {
        var result = Result.Success(3);
        var error = Error.Validation("Test", "Value too small");

        var ensured = result.Ensure(x => x > 5, error);

        Assert.True(ensured.IsError);
        Assert.Equal(error, ensured.Error);
    }

    [Fact]
    public void Ensure_OnFailedResult_ShouldReturnOriginalError()
    {
        var originalError = Error.NotFound();
        var result = Result.Failure<int>(originalError);
        var validationError = Error.Validation("Test", "Test");

        var ensured = result.Ensure(x => x > 0, validationError);

        Assert.True(ensured.IsError);
        Assert.Equal(originalError, ensured.Error);
    }

    [Fact]
    public async Task EnsureAsync_WhenPredicatePasses_ShouldReturnOriginalSuccessResult()
    {
        var resultTask = Task.FromResult(Result.Success(20));

        var ensured = await resultTask.EnsureAsync(x => x > 10, Error.Validation());

        Assert.True(ensured.IsSuccess);
        Assert.Equal(20, ensured.Value);
    }

    [Fact]
    public async Task EnsureAsync_WhenPredicateFails_ShouldReturnErrorResult()
    {
        var resultTask = Task.FromResult(Result.Success(5));
        var error = Error.Validation("Test", "Value too small");

        var ensured = await resultTask.EnsureAsync(x => x > 10, error);

        Assert.True(ensured.IsError);
        Assert.Equal(error, ensured.Error);
    }

    [Fact]
    public void MapError_OnSuccessfulResult_ShouldReturnOriginalResult()
    {
        var result = Result.Success(42);

        var mapped = result.MapError(e => Error.Unexpected("Mapped", "Mapped error"));

        Assert.True(mapped.IsSuccess);
        Assert.Equal(42, mapped.Value);
    }

    [Fact]
    public void MapError_OnFailedResultWithSingleError_ShouldTransformError()
    {
        var originalError = Error.Validation("Original", "Original error");
        var result = Result.Failure<int>(originalError);

        var mapped = result.MapError(e => Error.Conflict(e.Code + ".Mapped", e.Description + " mapped"));

        Assert.True(mapped.IsError);
        Assert.Equal("Original.Mapped", mapped.Error.Code);
        Assert.Equal("Original error mapped", mapped.Error.Description);
        Assert.Equal(ErrorType.Conflict, mapped.Error.Type);
    }

    [Fact]
    public void MapError_OnFailedResultWithMultipleErrors_ShouldTransformAllErrors()
    {
        var error1 = Error.Validation("E1", "Error 1");
        var error2 = Error.NotFound("E2", "Error 2");
        var result = Result.Failure<int>(new[] { error1, error2 });

        var mapped = result.MapError(e => Error.Conflict(e.Code + ".Modified", e.Description));

        Assert.True(mapped.IsError);
        Assert.Equal(2, mapped.Errors.Length);
        Assert.Equal("E1.Modified", mapped.Errors[0].Code);
        Assert.Equal("E2.Modified", mapped.Errors[1].Code);
        Assert.All(mapped.Errors, e => Assert.Equal(ErrorType.Conflict, e.Type));
    }

    [Fact]
    public void Combine_WhenBothSuccessful_ShouldReturnTuple()
    {
        var result1 = Result.Success(10);
        var result2 = Result.Success("test");

        var combined = result1.Combine(result2);

        Assert.True(combined.IsSuccess);
        Assert.Equal((10, "test"), combined.Value);
    }

    [Fact]
    public void Combine_WhenFirstFails_ShouldReturnFirstError()
    {
        var error = Error.Validation("E1", "Error 1");
        var result1 = Result.Failure<int>(error);
        var result2 = Result.Success("test");

        var combined = result1.Combine(result2);

        Assert.True(combined.IsError);
        Assert.Single(combined.Errors);
        Assert.Equal(error, combined.Error);
    }

    [Fact]
    public void Combine_WhenSecondFails_ShouldReturnSecondError()
    {
        var result1 = Result.Success(10);
        var error = Error.NotFound("E2", "Error 2");
        var result2 = Result.Failure<string>(error);

        var combined = result1.Combine(result2);

        Assert.True(combined.IsError);
        Assert.Single(combined.Errors);
        Assert.Equal(error, combined.Error);
    }

    [Fact]
    public void Combine_WhenBothFail_ShouldCombineAllErrors()
    {
        var error1 = Error.Validation("E1", "Error 1");
        var error2 = Error.NotFound("E2", "Error 2");
        var result1 = Result.Failure<int>(error1);
        var result2 = Result.Failure<string>(error2);

        var combined = result1.Combine(result2);

        Assert.True(combined.IsError);
        Assert.Equal(2, combined.Errors.Length);
        Assert.Equal(error1, combined.Errors[0]);
        Assert.Equal(error2, combined.Errors[1]);
    }

    [Fact]
    public void Combine_WhenBothHaveMultipleErrors_ShouldCombineAllErrors()
    {
        var error1 = Error.Validation("E1", "Error 1");
        var error2 = Error.Validation("E2", "Error 2");
        var error3 = Error.NotFound("E3", "Error 3");
        var error4 = Error.Conflict("E4", "Error 4");

        var result1 = Result.Failure<int>(new[] { error1, error2 });
        var result2 = Result.Failure<string>(new[] { error3, error4 });

        var combined = result1.Combine(result2);

        Assert.True(combined.IsError);
        Assert.Equal(4, combined.Errors.Length);
    }

    [Fact]
    public void ChainedOperations_ShouldWorkCorrectly()
    {
        var result = Result.Success(10)
            .Map(x => x * 2)
            .Ensure(x => x > 15, Error.Validation("TooSmall", "Value must be greater than 15"))
            .Bind(x => Result.Success(x + 5))
            .Map(x => x.ToString());

        Assert.True(result.IsSuccess);
        Assert.Equal("25", result.Value);
    }

    [Fact]
    public void ChainedOperations_WithFailure_ShouldPropagateError()
    {
        var validationError = Error.Validation("TooSmall", "Value must be greater than 100");
        
        var result = Result.Success(10)
            .Map(x => x * 2)
            .Ensure(x => x > 100, validationError)
            .Bind(x => Result.Success(x + 5))
            .Map(x => x.ToString());

        Assert.True(result.IsError);
        Assert.Equal(validationError, result.Error);
    }
}
