using ErrorOrResult;

namespace ErrorOrResultTests;

public class ResultLinqExtensionsTests
{
    [Fact]
    public void Select_OnSuccessfulResult_ShouldTransformValue()
    {
        var result = Result.Success(5);

        var selected = from x in result
                       select x * 10;

        Assert.True(selected.IsSuccess);
        Assert.Equal(50, selected.Value);
    }

    [Fact]
    public void Select_OnFailedResult_ShouldPropagateError()
    {
        var error = Error.Validation("Test", "Test error");
        var result = Result.Failure<int>(error);

        var selected = from x in result
                       select x * 10;

        Assert.True(selected.IsError);
        Assert.Equal(error, selected.Error);
    }

    [Fact]
    public void Select_CanChangeType()
    {
        var result = Result.Success(42);

        var selected = from x in result
                       select $"Number: {x}";

        Assert.True(selected.IsSuccess);
        Assert.Equal("Number: 42", selected.Value);
    }

    [Fact]
    public void SelectMany_OnSuccessfulResults_ShouldChainOperations()
    {
        var result1 = Result.Success(10);

        var result = from x in result1
                     from y in Result.Success(x * 2)
                     select y + 5;

        Assert.True(result.IsSuccess);
        Assert.Equal(25, result.Value);
    }

    [Fact]
    public void SelectMany_WhenFirstFails_ShouldPropagateError()
    {
        var error = Error.NotFound("Test", "Not found");
        var result1 = Result.Failure<int>(error);

        var result = from x in result1
                     from y in Result.Success(x * 2)
                     select y + 5;

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void SelectMany_WhenSecondFails_ShouldPropagateError()
    {
        var result1 = Result.Success(10);
        var error = Error.Conflict("Test", "Conflict");

        var result = from x in result1
                     from y in Result.Failure<int>(error)
                     select y + 5;

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void SelectMany_WithMultipleFromClauses_ShouldChainCorrectly()
    {
        var result1 = Result.Success(2);
        var result2 = Result.Success(3);

        var result = from x in result1
                     from y in result2
                     from z in Result.Success(x + y)
                     select x * y * z;

        Assert.True(result.IsSuccess);
        Assert.Equal(30, result.Value);
    }

    [Fact]
    public void SelectMany_WithResultSelector_ShouldCombineValues()
    {
        var result1 = Result.Success(10);

        var result = from x in result1
                     from y in Result.Success(x + 5)
                     select (x, y, sum: x + y);

        Assert.True(result.IsSuccess);
        Assert.Equal((10, 15, 25), result.Value);
    }

    [Fact]
    public void ComplexLinqQuery_WithSuccessfulOperations_ShouldWork()
    {
        var result = from x in Result.Success(5)
                     from y in Result.Success(x * 2)
                     let sum = x + y
                     from z in Result.Success(sum + 1)
                     select new { Original = x, Doubled = y, Sum = sum, Final = z };

        Assert.True(result.IsSuccess);
        Assert.Equal(5, result.Value.Original);
        Assert.Equal(10, result.Value.Doubled);
        Assert.Equal(15, result.Value.Sum);
        Assert.Equal(16, result.Value.Final);
    }

    [Fact]
    public void ComplexLinqQuery_WithFailure_ShouldPropagateError()
    {
        var error = Error.Validation("Invalid", "Value is invalid");

        var result = from x in Result.Success(5)
                     from y in Result.Failure<int>(error)
                     let sum = x + y
                     from z in Result.Success(sum + 1)
                     select new { Original = x, Doubled = y, Sum = sum, Final = z };

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void LinqQuery_WithTypeTransformations_ShouldWork()
    {
        var result = from num in Result.Success(42)
                     from str in Result.Success(num.ToString())
                     from len in Result.Success(str.Length)
                     select (num, str, len);

        Assert.True(result.IsSuccess);
        Assert.Equal((42, "42", 2), result.Value);
    }

    [Fact]
    public void LinqQuery_MixedWithNonLinqOperations_ShouldWork()
    {
        var result = (from x in Result.Success(10)
                      select x * 2)
                     .Bind(x => Result.Success(x + 5))
                     .Map(x => x.ToString());

        Assert.True(result.IsSuccess);
        Assert.Equal("25", result.Value);
    }
}
