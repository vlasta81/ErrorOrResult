using ErrorOrResult;

namespace ErrorOrResultTests;

public class ErrorInfoTests
{
    [Fact]
    public void ErrorInfo_WithSingleError_ShouldInitializeCorrectly()
    {
        var error = Error.Validation("Test.Code", "Test description");
        var errorInfo = new ErrorInfo(error);

        Assert.Equal(error, errorInfo.FirstError);
        Assert.Single(errorInfo.AllErrors);
        Assert.Equal(error, errorInfo.AllErrors[0]);
    }

    [Fact]
    public void ErrorInfo_WithErrorArray_ShouldInitializeCorrectly()
    {
        var errors = new[]
        {
            Error.Validation("Error1", "Description1"),
            Error.Conflict("Error2", "Description2")
        };
        var errorInfo = new ErrorInfo(errors);

        Assert.Equal(errors[0], errorInfo.FirstError);
        Assert.Equal(2, errorInfo.AllErrors.Length);
        Assert.Equal(errors[0], errorInfo.AllErrors[0]);
        Assert.Equal(errors[1], errorInfo.AllErrors[1]);
    }

    [Fact]
    public void ErrorInfo_WithErrorList_ShouldInitializeCorrectly()
    {
        var errors = new List<Error>
        {
            Error.NotFound("Error1", "Description1"),
            Error.Unauthorized("Error2", "Description2"),
            Error.Forbidden("Error3", "Description3")
        };
        var errorInfo = new ErrorInfo(errors);

        Assert.Equal(errors[0], errorInfo.FirstError);
        Assert.Equal(3, errorInfo.AllErrors.Length);
    }

    [Fact]
    public void ErrorInfo_WithNullArray_ShouldThrowArgumentNullException()
    {
        Error[]? errors = null;

        Assert.Throws<ArgumentNullException>(() => new ErrorInfo(errors!));
    }

    [Fact]
    public void ErrorInfo_WithNullList_ShouldThrowArgumentNullException()
    {
        List<Error>? errors = null;

        Assert.Throws<ArgumentNullException>(() => new ErrorInfo(errors!));
    }

    [Fact]
    public void ErrorInfo_WithEmptyArray_ShouldThrowArgumentException()
    {
        var errors = Array.Empty<Error>();

        Assert.Throws<ArgumentException>(() => new ErrorInfo(errors));
    }

    [Fact]
    public void ErrorInfo_Equality_ShouldWorkCorrectly()
    {
        var error1 = Error.Validation("Code", "Desc");
        var error2 = Error.Validation("Code", "Desc");
        var error3 = Error.NotFound("Other", "Desc");

        var errorInfo1 = new ErrorInfo(error1);
        var errorInfo2 = new ErrorInfo(error2);
        var errorInfo3 = new ErrorInfo(error3);

        Assert.Equal(errorInfo1.FirstError, errorInfo2.FirstError);
        Assert.NotEqual(errorInfo1.FirstError, errorInfo3.FirstError);
        Assert.True(errorInfo1.AllErrors.SequenceEqual(errorInfo2.AllErrors));
        Assert.False(errorInfo1.AllErrors.SequenceEqual(errorInfo3.AllErrors));
    }

    [Fact]
    public void ErrorInfo_WithMultipleErrors_FirstErrorShouldBeFirst()
    {
        var firstError = Error.Validation("First", "First error");
        var secondError = Error.Conflict("Second", "Second error");
        var errors = new[] { firstError, secondError };

        var errorInfo = new ErrorInfo(errors);

        Assert.Equal(firstError, errorInfo.FirstError);
        Assert.NotEqual(secondError, errorInfo.FirstError);
    }

    [Fact]
    public void ErrorInfo_ToString_WithSingleError_ShouldReturnSingleFormat()
    {
        var error = Error.NotFound("User.NotFound", "User not found");
        var errorInfo = new ErrorInfo(error);

        var str = errorInfo.ToString();

        Assert.Equal("Error: User.NotFound", str);
    }

    [Fact]
    public void ErrorInfo_ToString_WithMultipleErrors_ShouldReturnMultipleFormat()
    {
        var errors = new[]
        {
            Error.Validation("E1", "Desc1"),
            Error.Conflict("E2", "Desc2"),
            Error.NotFound("E3", "Desc3")
        };
        var errorInfo = new ErrorInfo(errors);

        var str = errorInfo.ToString();

        Assert.StartsWith("Errors (3):", str);
        Assert.Contains("E1", str);
        Assert.Contains("E2", str);
        Assert.Contains("E3", str);
    }

    [Fact]
    public void ErrorInfo_Default_Count_ShouldBeZero()
    {
        ErrorInfo errorInfo = default;

        Assert.Equal(0, errorInfo.Count);
    }

    [Fact]
    public void ErrorInfo_Default_AllErrors_ShouldReturnEmpty()
    {
        ErrorInfo errorInfo = default;

        Assert.True(errorInfo.AllErrors.IsEmpty);
    }

    [Fact]
    public void ErrorInfo_Default_FirstError_ShouldThrowInvalidOperationException()
    {
        ErrorInfo errorInfo = default;

        Assert.Throws<InvalidOperationException>(() => errorInfo.FirstError);
    }

    [Fact]
    public void ErrorInfo_Default_ToString_ShouldReturnNoErrors()
    {
        ErrorInfo errorInfo = default;

        Assert.Equal("No errors", errorInfo.ToString());
    }

    [Fact]
    public void ErrorInfo_WithEmptySpan_ShouldThrowArgumentException()
    {
        // ReadOnlySpan<T> cannot be captured in a lambda, so use try/catch directly
        bool threw = false;
        try
        {
            _ = new ErrorInfo(ReadOnlySpan<Error>.Empty);
        }
        catch (ArgumentException)
        {
            threw = true;
        }
        Assert.True(threw);
    }

    [Fact]
    public void ErrorInfo_WithEmptyList_ShouldThrowArgumentException()
    {
        var errors = new List<Error>();

        Assert.Throws<ArgumentException>(() => new ErrorInfo(errors));
    }
}
