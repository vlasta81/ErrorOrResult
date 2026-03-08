using ErrorOrResult;

namespace ErrorOrResultTests;

public class NoneTests
{
    [Fact]
    public void None_CanBeUsedAsGenericParameter()
    {
        var result = Result.Success(new None());

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void None_WithError_ShouldCreateFailedResult()
    {
        var error = Error.Validation("Test", "Test error");
        var result = Result.Failure<None>(error);

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void None_AllInstancesAreEqual()
    {
        var none1 = new None();
        var none2 = new None();

        Assert.Equal(none1, none2);
    }

    [Fact]
    public void None_CanBeUsedForOperationsWithoutReturnValue()
    {
        var result = PerformOperation(true);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void None_InFailedOperation_ShouldReturnError()
    {
        var result = PerformOperation(false);

        Assert.True(result.IsError);
        Assert.Equal("Operation.Failed", result.Error.Code);
    }

    [Fact]
    public void None_CanBeChainedWithMap()
    {
        var result = Result.Success(new None())
            .Map(_ => 42);

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void None_CanBeChainedWithBind()
    {
        var result = Result.Success(new None())
            .Bind(_ => Result.Success("test"));

        Assert.True(result.IsSuccess);
        Assert.Equal("test", result.Value);
    }

    [Fact]
    public void None_CanBeUsedWithMatch()
    {
        var result = Result.Success(new None());

        var matched = result.Match(
            onSuccess: _ => "Success",
            onFailure: _ => "Failed");

        Assert.Equal("Success", matched);
    }

    private static Result<None> PerformOperation(bool success)
    {
        if (success)
        {
            return Result.Success(new None());
        }
        return Result.Failure<None>(Error.Failure("Operation.Failed", "The operation failed"));
    }
}
