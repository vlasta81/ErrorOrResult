using ErrorOrResult;

namespace ErrorOrResultTests;

public class ResultTests
{
    [Fact]
    public void Result_Success_ShouldCreateSuccessfulResult()
    {
        var result = Result.Success(42);

        Assert.True(result.IsSuccess);
        Assert.False(result.IsError);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Result_Success_WithReferenceType_ShouldCreateSuccessfulResult()
    {
        var result = Result.Success("test string");

        Assert.True(result.IsSuccess);
        Assert.False(result.IsError);
        Assert.Equal("test string", result.Value);
    }

    [Fact]
    public void Result_Failure_WithSingleError_ShouldCreateFailedResult()
    {
        var error = Error.Validation("Test.Error", "Test description");
        var result = Result.Failure<int>(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
        Assert.Single(result.Errors);
    }

    [Fact]
    public void Result_Failure_WithMultipleErrors_ShouldCreateFailedResult()
    {
        var errors = new[]
        {
            Error.Validation("Error1", "Description1"),
            Error.Conflict("Error2", "Description2")
        };
        var result = Result.Failure<string>(errors);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.Equal(errors[0], result.Error);
        Assert.Equal(2, result.Errors.Length);
    }

    [Fact]
    public void Result_Failure_WithEmptyErrors_ShouldThrowArgumentException()
    {
        var errors = Array.Empty<Error>();

        Assert.Throws<ArgumentException>(() => Result.Failure<int>(errors));
    }

    [Fact]
    public void Result_Failure_WithErrorInfo_ShouldCreateFailedResult()
    {
        var errorInfo = new ErrorInfo(Error.NotFound());
        var result = Result.Failure<int>(errorInfo);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsError);
        Assert.Equal(errorInfo, result.ErrorInfo);
    }

    [Fact]
    public void Result_Value_OnSuccessfulResult_ShouldReturnValue()
    {
        var result = Result.Success(100);

        var value = result.Value;

        Assert.Equal(100, value);
    }

    [Fact]
    public void Result_Value_OnFailedResult_ShouldThrowInvalidOperationException()
    {
        var result = Result.Failure<int>(Error.Validation());

        Assert.Throws<InvalidOperationException>(() => result.Value);
    }

    [Fact]
    public void Result_ErrorInfo_OnFailedResult_ShouldReturnErrorInfo()
    {
        var error = Error.NotFound("Test", "Test");
        var result = Result.Failure<int>(error);

        var errorInfo = result.ErrorInfo;

        Assert.Equal(error, errorInfo.FirstError);
    }

    [Fact]
    public void Result_ErrorInfo_OnSuccessfulResult_ShouldThrowInvalidOperationException()
    {
        var result = Result.Success(42);

        Assert.Throws<InvalidOperationException>(() => result.ErrorInfo);
    }

    [Fact]
    public void Result_Error_OnFailedResult_ShouldReturnFirstError()
    {
        var error1 = Error.Validation("Error1", "Desc1");
        var error2 = Error.Conflict("Error2", "Desc2");
        var result = Result.Failure<int>(new[] { error1, error2 });

        var error = result.Error;

        Assert.Equal(error1, error);
    }

    [Fact]
    public void Result_ImplicitConversionFromValue_ShouldCreateSuccessResult()
    {
        Result<int> result = 42;

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Result_ImplicitConversionFromError_ShouldCreateFailedResult()
    {
        var error = Error.NotFound();
        Result<string> result = error;

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void Result_ImplicitConversionFromErrorInfo_ShouldCreateFailedResult()
    {
        var errorInfo = new ErrorInfo(Error.Validation());
        Result<int> result = errorInfo;

        Assert.True(result.IsError);
        Assert.Equal(errorInfo, result.ErrorInfo);
    }

    [Fact]
    public void Result_MultipleErrors_ShouldStoreAllErrors()
    {
        var error1 = Error.Validation("E1", "D1");
        var error2 = Error.Conflict("E2", "D2");
        var error3 = Error.NotFound("E3", "D3");

        var result = Result.Failure<int>(new[] { error1, error2, error3 });

        Assert.Equal(3, result.Errors.Length);
        Assert.Equal(error1, result.Errors[0]);
        Assert.Equal(error2, result.Errors[1]);
        Assert.Equal(error3, result.Errors[2]);
    }

    [Fact]
    public void Result_GetValueOrDefault_OnSuccessfulResult_ShouldReturnValue()
    {
        var result = Result.Success(42);

        var value = result.GetValueOrDefault(0);

        Assert.Equal(42, value);
    }

    [Fact]
    public void Result_GetValueOrDefault_OnFailedResult_ShouldReturnDefaultValue()
    {
        var result = Result.Failure<int>(Error.NotFound());

        var value = result.GetValueOrDefault(99);

        Assert.Equal(99, value);
    }

    [Fact]
    public void Result_GetValueOrThrow_OnSuccessfulResult_ShouldReturnValue()
    {
        var result = Result.Success("test");

        var value = result.GetValueOrThrow();

        Assert.Equal("test", value);
    }

    [Fact]
    public void Result_GetValueOrThrow_OnFailedResult_ShouldThrowException()
    {
        var result = Result.Failure<int>(Error.Validation());

        Assert.Throws<InvalidOperationException>(() => result.GetValueOrThrow());
    }

    [Fact]
    public void Result_ToString_OnSuccessfulResult_ShouldShowValue()
    {
        var result = Result.Success(100);

        var str = result.ToString();

        Assert.Contains("Success", str);
        Assert.Contains("100", str);
    }

    [Fact]
    public void Result_ToString_OnFailedResult_ShouldShowError()
    {
        var error = Error.NotFound("Test", "Not found");
        var result = Result.Failure<int>(error);

        var str = result.ToString();

        Assert.Contains("Failure", str);
    }

    [Fact]
    public void Result_StaticSuccess_WithoutValue_ShouldCreateNoneResult()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Result_StaticSuccess_WithValue_ShouldCreateSuccessResult()
    {
        var result = Result.Success(42);

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Result_StaticFailure_WithSingleError_ShouldCreateFailedResult()
    {
        var error = Error.NotFound();
        var result = Result.Failure<int>(error);

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void Result_StaticFailure_WithErrorArray_ShouldCreateFailedResult()
    {
        var errors = new[] { Error.Validation(), Error.Conflict() };
        var result = Result.Failure<string>(errors);

        Assert.True(result.IsError);
        Assert.Equal(2, result.Errors.Length);
    }

    [Fact]
    public void Result_StaticFailure_WithErrorList_ShouldCreateFailedResult()
    {
        var errors = new List<Error> { Error.Validation(), Error.NotFound() };
        var result = Result.Failure<double>(errors);

        Assert.True(result.IsError);
        Assert.Equal(2, result.Errors.Length);
    }

    [Fact]
    public void Result_StaticFailure_WithNone_ShouldCreateFailedNoneResult()
    {
        var error = Error.Failure();
        var result = Result.Failure(error);

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }
}
