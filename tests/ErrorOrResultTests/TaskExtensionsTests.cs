using ErrorOrResult;

namespace ErrorOrResultTests;

public class TaskExtensionsTests
{
    [Fact]
    public async Task ToResultAsync_WithSuccessfulTask_ShouldReturnSuccessResult()
    {
        var task = Task.FromResult(42);

        var result = await task.ToResultAsync();

        Assert.True(result.IsSuccess);
        Assert.Equal(42, result.Value);
    }

    [Fact]
    public async Task ToResultAsync_WithException_ShouldReturnErrorResult()
    {
        var task = Task.FromException<int>(new InvalidOperationException("Test exception"));

        var result = await task.ToResultAsync();

        Assert.True(result.IsError);
        Assert.Equal("Exception.Caught", result.Error.Code);
        Assert.DoesNotContain("Test exception", result.Error.Description);
        Assert.Equal(ErrorType.Unexpected, result.Error.Type);
    }

    [Fact]
    public async Task ToResultAsync_WithReferenceType_WhenValueIsNotNull_ShouldReturnSuccessResult()
    {
        var task = Task.FromResult<string?>("test value");
        var error = Error.NotFound("Test", "Value not found");

        var result = await task.ToResultAsync(error);

        Assert.True(result.IsSuccess);
        Assert.Equal("test value", result.Value);
    }

    [Fact]
    public async Task ToResultAsync_WithReferenceType_WhenValueIsNull_ShouldReturnErrorResult()
    {
        var task = Task.FromResult<string?>(null);
        var error = Error.NotFound("Test", "Value not found");

        var result = await task.ToResultAsync(error);

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public async Task ToResultAsync_WithReferenceType_WhenExceptionOccurs_ShouldReturnUnexpectedError()
    {
        var task = Task.FromException<string?>(new ArgumentException("Test argument exception"));
        var error = Error.NotFound("Test", "Value not found");

        var result = await task.ToResultAsync(error);

        Assert.True(result.IsError);
        Assert.Equal("Exception.Caught", result.Error.Code);
        Assert.DoesNotContain("Test argument exception", result.Error.Description);
        Assert.Equal(ErrorType.Unexpected, result.Error.Type);
    }

    [Fact]
    public async Task ToResultAsync_WithValueType_WhenHasValue_ShouldReturnSuccessResult()
    {
        var task = Task.FromResult<int?>(100);
        var error = Error.NotFound("Test", "Value not found");

        var result = await task.ToResultAsync(error);

        Assert.True(result.IsSuccess);
        Assert.Equal(100, result.Value);
    }

    [Fact]
    public async Task ToResultAsync_WithValueType_WhenNull_ShouldReturnErrorResult()
    {
        var task = Task.FromResult<int?>(null);
        var error = Error.NotFound("Test", "Value not found");

        var result = await task.ToResultAsync(error);

        Assert.True(result.IsError);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public async Task ToResultAsync_WithValueType_WhenExceptionOccurs_ShouldReturnUnexpectedError()
    {
        var task = Task.FromException<int?>(new TimeoutException("Request timeout"));
        var error = Error.NotFound("Test", "Value not found");

        var result = await task.ToResultAsync(error);

        Assert.True(result.IsError);
        Assert.Equal("Exception.Caught", result.Error.Code);
        Assert.DoesNotContain("Request timeout", result.Error.Description);
    }

    [Fact]
    public async Task ToResultAsync_WithComplexType_ShouldWork()
    {
        var dto = new TestDto { Id = 1, Name = "Test" };
        var task = Task.FromResult(dto);

        var result = await task.ToResultAsync();

        Assert.True(result.IsSuccess);
        Assert.Equal(1, result.Value.Id);
        Assert.Equal("Test", result.Value.Name);
    }

    [Fact]
    public async Task ToResultAsync_WithDelayedTask_ShouldWaitForCompletion()
    {
        var task = Task.Run(async () =>
        {
            await Task.Delay(10);
            return "delayed result";
        });

        var result = await task.ToResultAsync();

        Assert.True(result.IsSuccess);
        Assert.Equal("delayed result", result.Value);
    }

    private record TestDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
