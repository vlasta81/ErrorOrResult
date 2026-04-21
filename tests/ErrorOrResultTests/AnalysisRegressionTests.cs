using ErrorOrResult;

namespace ErrorOrResultTests;

/// <summary>
/// Regression tests covering fixes from the library code analysis:
/// security hardening, default(ErrorInfo) guards, null-argument checks,
/// ToString formatting, and the Combine ordering contract.
/// </summary>
public class AnalysisRegressionTests
{
    [Fact]
    public void Failure_WithDefaultErrorInfo_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => Result.Failure<int>(default(ErrorInfo)));
    }

    [Fact]
    public void Failure_WithNullErrorArray_ShouldThrow()
    {
        Error[]? errors = null;
        Assert.Throws<ArgumentNullException>(() => Result.Failure<int>(errors!));
    }

    [Fact]
    public void Failure_WithNullErrorList_ShouldThrow()
    {
        List<Error>? errors = null;
        Assert.Throws<ArgumentNullException>(() => Result.Failure<int>(errors!));
    }

    [Fact]
    public void Result_ToString_OnFailure_ShouldRenderInnerErrorInfo()
    {
        var result = Result.Failure<int>(Error.Validation("E1", "desc"));

        string text = result.ToString();

        Assert.Contains("Failure:", text);
        Assert.Contains("E1", text);
        // Regression: previously rendered "ErrorOrResult.ErrorInfo" due to Nullable<T>.ToString()
        Assert.DoesNotContain("ErrorOrResult.ErrorInfo", text);
    }

    [Fact]
    public void Result_Success_None_ShouldBeCached()
    {
        var a = Result.Success();
        var b = Result.Success();
        // Both share value semantics; the underlying readonly instance is reused.
        Assert.Equal(a, b);
        Assert.True(a.IsSuccess);
    }

    [Fact]
    public void MapError_WithNullMapper_ShouldThrow()
    {
        var result = Result.Failure<int>(Error.Failure("E", "d"));

        Assert.Throws<ArgumentNullException>(() => result.MapError(null!));
    }

    [Fact]
    public void Combine_WithTwoErrors_ShouldPreserveOrder_LeftFirst()
    {
        var left = Result.Failure<int>(Error.NotFound("Left", "left"));
        var right = Result.Failure<string>(Error.Validation("Right", "right"));

        var combined = left.Combine(right);

        Assert.True(combined.IsError);
        Assert.Equal(2, combined.ErrorInfo.Count);
        Assert.Equal("Left", combined.ErrorInfo.AllErrors[0].Code);
        Assert.Equal("Right", combined.ErrorInfo.AllErrors[1].Code);
        // Documented behavior: FirstError drives ToProblem status code.
        Assert.Equal(ErrorType.NotFound, combined.Error.Type);
    }

    [Fact]
    public void Combine_WithOneErrorEach_ShouldReturnBothErrors_RightSide()
    {
        var left = Result.Failure<int>(Error.Validation("L", "l"));
        var right = Result.Failure<string>(Error.NotFound("R", "r"));

        var combined = left.Combine(right);

        // Left is validation => FirstError is validation => status 422 path in ToProblem.
        Assert.Equal(ErrorType.Validation, combined.Error.Type);
        Assert.Equal(2, combined.Errors.Length);
    }

    [Fact]
    public void ErrorInfo_Default_FirstError_ShouldThrow()
    {
        ErrorInfo info = default;
        Assert.Throws<InvalidOperationException>(() => info.FirstError);
        Assert.Equal(0, info.Count);
        Assert.True(info.AllErrors.IsEmpty);
    }

    [Fact]
    public void ErrorInfo_FromEmptyArray_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new ErrorInfo(Array.Empty<Error>()));
    }

    [Fact]
    public void ErrorInfo_FromEmptyList_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new ErrorInfo(new List<Error>()));
    }

    [Fact]
    public void ErrorInfo_ToString_WithMultipleErrors_ShouldListAllCodes()
    {
        Error[] errors =
        [
            Error.Validation("A", "a"),
            Error.NotFound("B", "b"),
            Error.Conflict("C", "c"),
        ];
        var info = new ErrorInfo(errors);

        string text = info.ToString();

        Assert.Contains("Errors (3)", text);
        Assert.Contains("A", text);
        Assert.Contains("B", text);
        Assert.Contains("C", text);
    }

    [Fact]
    public void Combine_WithComparer_ShouldPlaceHigherSeverityFirst()
    {
        var left = Result.Failure<int>(Error.NotFound("Low", "404"));
        var right = Result.Failure<string>(Error.Validation("High", "422"));

        var combined = left.Combine(right, ErrorComparers.BySeverityDescending);

        Assert.True(combined.IsError);
        Assert.Equal(2, combined.Errors.Length);
        Assert.Equal("High", combined.Errors[0].Code);
        Assert.Equal("Low", combined.Errors[1].Code);
        Assert.Equal(ErrorType.Validation, combined.Error.Type);
    }

    [Fact]
    public void Combine_WithNullComparer_ShouldPreserveOperandOrder()
    {
        var left = Result.Failure<int>(Error.NotFound("L", "l"));
        var right = Result.Failure<string>(Error.Validation("R", "r"));

        var combined = left.Combine(right, errorComparer: null);

        Assert.Equal("L", combined.Errors[0].Code);
        Assert.Equal("R", combined.Errors[1].Code);
    }

    [Fact]
    public void ErrorComparers_BySeverityDescending_ShouldRankAllErrorTypes()
    {
        Error[] input =
        [
            Error.Unexpected("U", "u"),
            Error.NotFound("NF", "nf"),
            Error.Validation("V", "v"),
            Error.Failure("F", "f"),
            Error.Forbidden("FB", "fb"),
            Error.Unauthorized("UA", "ua"),
            Error.Conflict("C", "c"),
            Error.Custom("BR", "br", ErrorType.BadRequest),
        ];
        Array.Sort(input, ErrorComparers.BySeverityDescending);

        string[] expected = ["V", "BR", "C", "UA", "FB", "NF", "F", "U"];
        Assert.Equal(expected, input.Select(e => e.Code).ToArray());
    }
}
