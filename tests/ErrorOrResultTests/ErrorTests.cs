using ErrorOrResult;

namespace ErrorOrResultTests;

public class ErrorTests
{
    [Fact]
    public void Error_Constructor_ShouldInitializeProperties()
    {
        var error = new Error("Code123", "Description", ErrorType.Validation);

        Assert.Equal("Code123", error.Code);
        Assert.Equal("Description", error.Description);
        Assert.Equal(ErrorType.Validation, error.Type);
        Assert.Equal(422, error.NumericType);
    }

    [Fact]
    public void Error_Failure_ShouldCreateFailureError()
    {
        var error = Error.Failure();

        Assert.Equal("General.Failure", error.Code);
        Assert.Equal("A failure has occurred!", error.Description);
        Assert.Equal(ErrorType.Failure, error.Type);
        Assert.Equal(500, error.NumericType);
    }

    [Fact]
    public void Error_Failure_WithCustomParameters_ShouldUseProvidedValues()
    {
        var error = Error.Failure("Custom.Code", "Custom description");

        Assert.Equal("Custom.Code", error.Code);
        Assert.Equal("Custom description", error.Description);
        Assert.Equal(ErrorType.Failure, error.Type);
    }

    [Fact]
    public void Error_Unexpected_ShouldCreateUnexpectedError()
    {
        var error = Error.Unexpected();

        Assert.Equal("General.Unexpected", error.Code);
        Assert.Equal("An unexpected error has occurred!", error.Description);
        Assert.Equal(ErrorType.Unexpected, error.Type);
        Assert.Equal(520, error.NumericType);
    }

    [Fact]
    public void Error_Validation_ShouldCreateValidationError()
    {
        var error = Error.Validation();

        Assert.Equal("General.Validation", error.Code);
        Assert.Equal("A validation error has occurred!", error.Description);
        Assert.Equal(ErrorType.Validation, error.Type);
        Assert.Equal(422, error.NumericType);
    }

    [Fact]
    public void Error_Conflict_ShouldCreateConflictError()
    {
        var error = Error.Conflict();

        Assert.Equal("General.Conflict", error.Code);
        Assert.Equal("A conflict error has occurred!", error.Description);
        Assert.Equal(ErrorType.Conflict, error.Type);
        Assert.Equal(409, error.NumericType);
    }

    [Fact]
    public void Error_NotFound_ShouldCreateNotFoundError()
    {
        var error = Error.NotFound();

        Assert.Equal("General.NotFound", error.Code);
        Assert.Equal("A 'Not Found' error has occurred!", error.Description);
        Assert.Equal(ErrorType.NotFound, error.Type);
        Assert.Equal(404, error.NumericType);
    }

    [Fact]
    public void Error_Unauthorized_ShouldCreateUnauthorizedError()
    {
        var error = Error.Unauthorized();

        Assert.Equal("General.Unauthorized", error.Code);
        Assert.Equal("An 'Unauthorized' error has occurred!", error.Description);
        Assert.Equal(ErrorType.Unauthorized, error.Type);
        Assert.Equal(401, error.NumericType);
    }

    [Fact]
    public void Error_Forbidden_ShouldCreateForbiddenError()
    {
        var error = Error.Forbidden();

        Assert.Equal("General.Forbidden", error.Code);
        Assert.Equal("A 'Forbidden' error has occurred!", error.Description);
        Assert.Equal(ErrorType.Forbidden, error.Type);
        Assert.Equal(403, error.NumericType);
    }

    [Fact]
    public void Error_BadRequest_ShouldCreateBadRequestError()
    {
        var error = Error.BadRequest();

        Assert.Equal("General.BadRequest", error.Code);
        Assert.Equal("A 'BadRequest' error has occurred!", error.Description);
        Assert.Equal(ErrorType.BadRequest, error.Type);
        Assert.Equal(400, error.NumericType);
    }

    [Fact]
    public void Error_Custom_ShouldCreateCustomError()
    {
        var error = Error.Custom("Custom.Code", "Custom description", ErrorType.Conflict);

        Assert.Equal("Custom.Code", error.Code);
        Assert.Equal("Custom description", error.Description);
        Assert.Equal(ErrorType.Conflict, error.Type);
        Assert.Equal(409, error.NumericType);
    }

    [Fact]
    public void Error_Deconstruct_ShouldExtractComponents()
    {
        var error = new Error("Code", "Desc", ErrorType.Validation);

        var (code, description, type) = error;

        Assert.Equal("Code", code);
        Assert.Equal("Desc", description);
        Assert.Equal(ErrorType.Validation, type);
    }

    [Fact]
    public void Error_Equality_ShouldWorkCorrectly()
    {
        var error1 = new Error("Code", "Desc", ErrorType.Validation);
        var error2 = new Error("Code", "Desc", ErrorType.Validation);
        var error3 = new Error("Other", "Desc", ErrorType.Validation);

        Assert.Equal(error1, error2);
        Assert.NotEqual(error1, error3);
    }

    [Fact]
    public void Error_WithDescription_ShouldCreateNewErrorWithUpdatedDescription()
    {
        var originalError = Error.Validation("Test.Code", "Original description");

        var modifiedError = originalError.WithDescription("New description");

        // Original error should be unchanged (record struct immutability)
        Assert.Equal("Test.Code", originalError.Code);
        Assert.Equal("Original description", originalError.Description);
        Assert.Equal(ErrorType.Validation, originalError.Type);

        // New error should have updated description but same code and type
        Assert.Equal("Test.Code", modifiedError.Code);
        Assert.Equal("New description", modifiedError.Description);
        Assert.Equal(ErrorType.Validation, modifiedError.Type);

        // Errors should not be equal since description differs
        Assert.NotEqual(originalError, modifiedError);
    }

    [Fact]
    public void Error_WithDescription_CanBeChained()
    {
        var error = Error.NotFound()
            .WithDescription("First update")
            .WithDescription("Second update");

        Assert.Equal("General.NotFound", error.Code);
        Assert.Equal("Second update", error.Description);
        Assert.Equal(ErrorType.NotFound, error.Type);
    }
}
