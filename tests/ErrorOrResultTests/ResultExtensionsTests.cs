using ErrorOrResult;

namespace ErrorOrResultTests;

public class ResultExtensionsTests
{
    [Fact]
    public void Map_OnSuccessfulResult_ShouldTransformValue()
    {
        var result = Result.Success(10);

        var mapped = result.Map(x => x * 2);

        Assert.True(mapped.IsSuccess);
        Assert.Equal(20, mapped.Value);
    }

    [Fact]
    public void Map_OnFailedResult_ShouldPropagateError()
    {
        var error = Error.Validation("Test", "Test error");
        var result = Result.Failure<int>(error);

        var mapped = result.Map(x => x * 2);

        Assert.True(mapped.IsError);
        Assert.Equal(error, mapped.Error);
    }

    [Fact]
    public void Map_CanChangeType()
    {
        var result = Result.Success(42);

        var mapped = result.Map(x => x.ToString());

        Assert.True(mapped.IsSuccess);
        Assert.Equal("42", mapped.Value);
    }

    [Fact]
    public async Task MapAsync_OnSuccessfulResult_ShouldTransformValue()
    {
        var resultTask = Task.FromResult(Result.Success(5));

        var mapped = await resultTask.MapAsync(x => x + 10);

        Assert.True(mapped.IsSuccess);
        Assert.Equal(15, mapped.Value);
    }

    [Fact]
    public async Task MapAsync_OnFailedResult_ShouldPropagateError()
    {
        var error = Error.NotFound();
        var resultTask = Task.FromResult(Result.Failure<int>(error));

        var mapped = await resultTask.MapAsync(x => x * 2);

        Assert.True(mapped.IsError);
        Assert.Equal(error, mapped.Error);
    }

    [Fact]
    public void Bind_OnSuccessfulResult_ShouldExecuteBinder()
    {
        var result = Result.Success(10);

        var bound = result.Bind(x => Result.Success(x * 3));

        Assert.True(bound.IsSuccess);
        Assert.Equal(30, bound.Value);
    }

    [Fact]
    public void Bind_OnSuccessfulResult_WhenBinderReturnsError_ShouldReturnError()
    {
        var result = Result.Success(10);
        var error = Error.Validation("Bind.Error", "Binder failed");

        var bound = result.Bind<int, int>(x => error);

        Assert.True(bound.IsError);
        Assert.Equal(error, bound.Error);
    }

    [Fact]
    public void Bind_OnFailedResult_ShouldNotExecuteBinderAndPropagateError()
    {
        var error = Error.NotFound();
        var result = Result.Failure<int>(error);
        bool binderExecuted = false;

        var bound = result.Bind<int, int>(x =>
        {
            binderExecuted = true;
            return Result.Success(x * 2);
        });

        Assert.False(binderExecuted);
        Assert.True(bound.IsError);
        Assert.Equal(error, bound.Error);
    }

    [Fact]
    public void Bind_CanChangeType()
    {
        var result = Result.Success(100);

        var bound = result.Bind(x => Result.Success($"Value: {x}"));

        Assert.True(bound.IsSuccess);
        Assert.Equal("Value: 100", bound.Value);
    }

    [Fact]
    public async Task BindAsync_OnSuccessfulResult_ShouldExecuteBinder()
    {
        var resultTask = Task.FromResult(Result.Success(20));

        var bound = await resultTask.BindAsync(x => Task.FromResult(Result.Success(x / 2)));

        Assert.True(bound.IsSuccess);
        Assert.Equal(10, bound.Value);
    }

    [Fact]
    public async Task BindAsync_OnFailedResult_ShouldNotExecuteBinderAndPropagateError()
    {
        var error = Error.Conflict();
        var resultTask = Task.FromResult(Result.Failure<int>(error));
        bool binderExecuted = false;

        var bound = await resultTask.BindAsync(x =>
        {
            binderExecuted = true;
            return Task.FromResult(Result.Success(x * 2));
        });

        Assert.False(binderExecuted);
        Assert.True(bound.IsError);
        Assert.Equal(error, bound.Error);
    }

    [Fact]
    public void Match_OnSuccessfulResult_ShouldExecuteOnSuccess()
    {
        var result = Result.Success(50);

        var matched = result.Match(
            onSuccess: x => $"Success: {x}",
            onFailure: _ => "Failed");

        Assert.Equal("Success: 50", matched);
    }

    [Fact]
    public void Match_OnFailedResult_ShouldExecuteOnFailure()
    {
        var error = Error.NotFound("Test", "Test error");
        var result = Result.Failure<int>(error);

        var matched = result.Match(
            onSuccess: x => $"Success: {x}",
            onFailure: errorInfo => $"Error: {errorInfo.FirstError.Code}");

        Assert.Equal("Error: Test", matched);
    }

    [Fact]
    public async Task MatchAsync_OnSuccessfulResult_ShouldExecuteOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Success(100));

        var matched = await resultTask.MatchAsync(
            onSuccess: x => x * 2,
            onFailure: _ => 0);

        Assert.Equal(200, matched);
    }

    [Fact]
    public async Task MatchAsync_OnFailedResult_ShouldExecuteOnFailure()
    {
        var error = Error.Validation();
        var resultTask = Task.FromResult(Result.Failure<int>(error));

        var matched = await resultTask.MatchAsync(
            onSuccess: x => x,
            onFailure: _ => -1);

        Assert.Equal(-1, matched);
    }

    [Fact]
    public void Switch_OnSuccessfulResult_ShouldExecuteOnSuccessAction()
    {
        var result = Result.Success(42);
        int capturedValue = 0;
        ErrorInfo? capturedError = null;

        result.Switch(
            onSuccess: x => capturedValue = x,
            onFailure: e => capturedError = e);

        Assert.Equal(42, capturedValue);
        Assert.Null(capturedError);
    }

    [Fact]
    public void Switch_OnFailedResult_ShouldExecuteOnFailureAction()
    {
        var error = Error.Forbidden();
        var result = Result.Failure<int>(error);
        int capturedValue = 0;
        ErrorInfo? capturedError = null;

        result.Switch(
            onSuccess: x => capturedValue = x,
            onFailure: e => capturedError = e);

        Assert.Equal(0, capturedValue);
        Assert.NotNull(capturedError);
        Assert.Equal(error, capturedError.Value.FirstError);
    }

    [Fact]
    public void Tap_OnSuccessfulResult_ShouldExecuteActionAndReturnOriginalResult()
    {
        var result = Result.Success(25);
        int capturedValue = 0;

        var tapped = result.Tap(x => capturedValue = x * 2);

        Assert.True(tapped.IsSuccess);
        Assert.Equal(25, tapped.Value);
        Assert.Equal(50, capturedValue);
    }

    [Fact]
    public void Tap_OnFailedResult_ShouldNotExecuteActionAndReturnOriginalResult()
    {
        var error = Error.Conflict();
        var result = Result.Failure<int>(error);
        bool actionExecuted = false;

        var tapped = result.Tap(_ => actionExecuted = true);

        Assert.False(actionExecuted);
        Assert.True(tapped.IsError);
        Assert.Equal(error, tapped.Error);
    }

    [Fact]
    public async Task TapAsync_OnSuccessfulResult_ShouldExecuteActionAndReturnOriginalResult()
    {
        var resultTask = Task.FromResult(Result.Success(15));
        int capturedValue = 0;

        var tapped = await resultTask.TapAsync(async x =>
        {
            capturedValue = x;
            await Task.CompletedTask;
        });

        Assert.True(tapped.IsSuccess);
        Assert.Equal(15, tapped.Value);
        Assert.Equal(15, capturedValue);
    }

    [Fact]
    public void TapError_OnFailedResult_ShouldExecuteActionAndReturnOriginalResult()
    {
        var error = Error.Validation("Code", "Desc");
        var result = Result.Failure<int>(error);
        ErrorInfo? capturedError = null;

        var tapped = result.TapError(e => capturedError = e);

        Assert.True(tapped.IsError);
        Assert.Equal(error, tapped.Error);
        Assert.NotNull(capturedError);
        Assert.Equal(error, capturedError.Value.FirstError);
    }

    [Fact]
    public void TapError_OnSuccessfulResult_ShouldNotExecuteActionAndReturnOriginalResult()
    {
        var result = Result.Success(100);
        bool actionExecuted = false;

        var tapped = result.TapError(_ => actionExecuted = true);

        Assert.False(actionExecuted);
        Assert.True(tapped.IsSuccess);
        Assert.Equal(100, tapped.Value);
    }

    [Fact]
    public void ThrowOnError_OnSuccessfulResult_ShouldReturnValue()
    {
        var result = Result.Success(42);

        var value = result.ThrowOnError();

        Assert.Equal(42, value);
    }

    [Fact]
    public void ThrowOnError_OnFailedResult_ShouldThrowException()
    {
        var error = Error.Validation("Test.Code", "Test description");
        var result = Result.Failure<int>(error);

        var exception = Assert.Throws<InvalidOperationException>(() => result.ThrowOnError());
        Assert.Contains("Test.Code", exception.Message);
        Assert.Contains("Test description", exception.Message);
    }

    [Fact]
    public async Task ThrowOnErrorAsync_OnSuccessfulResult_ShouldReturnValue()
    {
        var resultTask = Task.FromResult(Result.Success("test value"));

        var value = await resultTask.ThrowOnErrorAsync();

        Assert.Equal("test value", value);
    }

    [Fact]
    public async Task ThrowOnErrorAsync_OnFailedResult_ShouldThrowException()
    {
        var error = Error.NotFound("Resource", "Resource not found");
        var resultTask = Task.FromResult(Result.Failure<string>(error));

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            async () => await resultTask.ThrowOnErrorAsync());

        Assert.Contains("Resource", exception.Message);
    }

    [Fact]
    public async Task TapAsync_OnFailedResult_ShouldNotExecuteActionAndReturnOriginalResult()
    {
        var error = Error.Conflict();
        var resultTask = Task.FromResult(Result.Failure<int>(error));
        bool actionExecuted = false;

        var tapped = await resultTask.TapAsync(async _ =>
        {
            actionExecuted = true;
            await Task.CompletedTask;
        });

        Assert.False(actionExecuted);
        Assert.True(tapped.IsError);
        Assert.Equal(error, tapped.Error);
    }
}
