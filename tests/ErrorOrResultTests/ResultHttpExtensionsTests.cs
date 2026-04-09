using ErrorOrResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorOrResultTests;

public class ResultHttpExtensionsTests
{
    // --- ToHttpResult<TOutput> ---

    [Fact]
    public void ToHttpResult_OnSuccessfulResult_ShouldReturnOk200()
    {
        var result = Result.Success(42);

        var httpResult = result.ToHttpResult();

        var okResult = Assert.IsType<Ok<int>>(httpResult);
        Assert.Equal(42, okResult.Value);
    }

    [Fact]
    public void ToHttpResult_OnSuccessfulResult_WithCustomHandler_ShouldInvokeHandler()
    {
        var result = Result.Success(42);
        bool handlerCalled = false;

        var httpResult = result.ToHttpResult(v =>
        {
            handlerCalled = true;
            return Results.Created("/api/items/42", v);
        });

        Assert.True(handlerCalled);
        Assert.IsType<Created<int>>(httpResult);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithGeneralFailure_ShouldReturnProblem500()
    {
        var result = Result.Failure<int>(Error.Failure("General.Failure", "A failure occurred"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(500, problem.ProblemDetails.Status);
        Assert.Equal("General.Failure", problem.ProblemDetails.Title);
        Assert.Equal("A failure occurred", problem.ProblemDetails.Detail);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithNotFoundError_ShouldReturnProblem404()
    {
        var result = Result.Failure<int>(Error.NotFound("Resource.NotFound", "Resource not found"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(404, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithConflictError_ShouldReturnProblem409()
    {
        var result = Result.Failure<string>(Error.Conflict("Resource.Conflict", "Resource already exists"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(409, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithUnexpectedError_ShouldReturnProblem520()
    {
        var result = Result.Failure<string>(Error.Unexpected("Exception.Caught", "Unexpected error"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(520, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithValidationError_ShouldReturnProblemWith422()
    {
        var result = Result.Failure<int>(Error.Validation("Field.Required", "Field is required"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(422, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithUnauthorizedError_ShouldReturnProblem401()
    {
        var result = Result.Failure<string>(Error.Unauthorized("Auth.Required", "Authentication required"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(401, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithForbiddenError_ShouldReturnProblem403()
    {
        var result = Result.Failure<string>(Error.Forbidden("Access.Denied", "Access denied"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(403, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToHttpResult_OnFailedResult_WithBadRequestError_ShouldReturnProblem400()
    {
        var result = Result.Failure<string>(Error.BadRequest("Request.Invalid", "Bad request"));

        var httpResult = result.ToHttpResult();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(400, problem.ProblemDetails.Status);
    }

    // --- ToHttpResult(Result<None>) ---

    [Fact]
    public void ToHttpResult_NoneOnSuccess_ShouldReturnNoContent204()
    {
        var result = Result.Success();

        var httpResult = result.ToHttpResult();

        Assert.IsType<NoContent>(httpResult);
    }

    [Fact]
    public void ToHttpResult_NoneOnError_ShouldReturnProblem()
    {
        var result = Result.Failure(Error.Failure("Op.Failed", "Operation failed"));

        var httpResult = result.ToHttpResult();

        Assert.IsType<ProblemHttpResult>(httpResult);
    }

    // --- ToHttpResultAsync ---

    [Fact]
    public async Task ToHttpResultAsync_OnSuccessfulResult_ShouldReturnOk200()
    {
        var resultTask = Task.FromResult(Result.Success("hello"));

        var httpResult = await resultTask.ToHttpResultAsync();

        var okResult = Assert.IsType<Ok<string>>(httpResult);
        Assert.Equal("hello", okResult.Value);
    }

    [Fact]
    public async Task ToHttpResultAsync_OnFailedResult_ShouldReturnProblem()
    {
        var resultTask = Task.FromResult(Result.Failure<string>(Error.NotFound()));

        var httpResult = await resultTask.ToHttpResultAsync();

        Assert.IsType<ProblemHttpResult>(httpResult);
    }

    [Fact]
    public async Task ToHttpResultAsync_NoneOnSuccess_ShouldReturnNoContent()
    {
        var resultTask = Task.FromResult(Result.Success());

        var httpResult = await resultTask.ToHttpResultAsync();

        Assert.IsType<NoContent>(httpResult);
    }

    // --- ToProblem (ErrorInfo extension) ---

    [Fact]
    public void ToProblem_WithMultipleErrors_ShouldIncludeErrorsExtension()
    {
        var errorInfo = new ErrorInfo(new[]
        {
            Error.Failure("E1", "Description 1"),
            Error.Conflict("E2", "Description 2")
        });

        var httpResult = errorInfo.ToProblem();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.True(problem.ProblemDetails.Extensions.ContainsKey("errors"));
    }

    [Fact]
    public void ToProblem_WithSingleError_ShouldNotIncludeErrorsExtension()
    {
        var errorInfo = new ErrorInfo(Error.Failure("E1", "Description 1"));

        var httpResult = errorInfo.ToProblem();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.False(problem.ProblemDetails.Extensions.ContainsKey("errors"));
    }

    [Fact]
    public void ToProblem_WithUnauthorizedError_ShouldReturn401()
    {
        var errorInfo = new ErrorInfo(Error.Unauthorized("Auth.Required", "Authentication required"));

        var httpResult = errorInfo.ToProblem();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(401, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToProblem_WithForbiddenError_ShouldReturn403()
    {
        var errorInfo = new ErrorInfo(Error.Forbidden("Access.Denied", "No access"));

        var httpResult = errorInfo.ToProblem();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(403, problem.ProblemDetails.Status);
    }

    [Fact]
    public void ToProblem_WithValidationError_ShouldReturn422()
    {
        var errorInfo = new ErrorInfo(Error.Validation("Field.Invalid", "Field is invalid"));

        var httpResult = errorInfo.ToProblem();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(422, problem.ProblemDetails.Status);
    }

    // --- ToValidationProblem ---

    [Fact]
    public void ToValidationProblem_ShouldGroupErrorsByCode()
    {
        var errorInfo = new ErrorInfo(new[]
        {
            Error.Validation("Field1", "Required"),
            Error.Validation("Field1", "Too short"),
            Error.Validation("Field2", "Invalid format")
        });

        var httpResult = errorInfo.ToValidationProblem();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(422, problem.ProblemDetails.Status);
        var validationDetails = Assert.IsType<Microsoft.AspNetCore.Http.HttpValidationProblemDetails>(problem.ProblemDetails);
        Assert.Contains("Field1", validationDetails.Errors.Keys);
        Assert.Contains("Field2", validationDetails.Errors.Keys);
        Assert.Equal(2, validationDetails.Errors["Field1"].Length);
        Assert.Single(validationDetails.Errors["Field2"]);
    }

    [Fact]
    public void ToValidationProblem_WithSingleError_ShouldGroupUnderItsCode()
    {
        var errorInfo = new ErrorInfo(Error.Validation("Email.Invalid", "Email is not valid"));

        var httpResult = errorInfo.ToValidationProblem();

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(422, problem.ProblemDetails.Status);
        var validationDetails = Assert.IsType<Microsoft.AspNetCore.Http.HttpValidationProblemDetails>(problem.ProblemDetails);
        Assert.Single(validationDetails.Errors);
        Assert.Contains("Email.Invalid", validationDetails.Errors.Keys);
        Assert.Equal("Email is not valid", validationDetails.Errors["Email.Invalid"][0]);
    }

    // --- ToOk ---

    [Fact]
    public void ToOk_OnSuccessfulResult_ShouldReturnTypedOk()
    {
        var result = Result.Success("typed value");

        var okResult = result.ToOk();

        Assert.NotNull(okResult);
        Assert.Equal("typed value", okResult.Value);
    }

    [Fact]
    public void ToOk_OnFailedResult_ShouldThrowInvalidOperationException()
    {
        var result = Result.Failure<string>(Error.NotFound());

        Assert.Throws<InvalidOperationException>(() => result.ToOk());
    }

    // --- ToCreated ---

    [Fact]
    public void ToCreated_OnSuccessfulResult_ShouldReturnTypedCreated()
    {
        var result = Result.Success(42);

        var createdResult = result.ToCreated("/api/items/42");

        Assert.NotNull(createdResult);
        Assert.Equal(42, createdResult.Value);
        Assert.Equal("/api/items/42", createdResult.Location);
    }

    [Fact]
    public void ToCreated_OnFailedResult_ShouldThrowInvalidOperationException()
    {
        var result = Result.Failure<int>(Error.Validation());

        Assert.Throws<InvalidOperationException>(() => result.ToCreated("/api/items"));
    }

    // --- ToCreatedAtRoute ---

    [Fact]
    public void ToCreatedAtRoute_OnSuccessfulResult_ShouldReturnTypedCreatedAtRoute()
    {
        var result = Result.Success(99);

        var createdResult = result.ToCreatedAtRoute("GetItem", new { id = 99 });

        Assert.NotNull(createdResult);
        Assert.Equal(99, createdResult.Value);
        Assert.Equal("GetItem", createdResult.RouteName);
    }

    [Fact]
    public void ToCreatedAtRoute_OnFailedResult_ShouldThrowInvalidOperationException()
    {
        var result = Result.Failure<int>(Error.Conflict());

        Assert.Throws<InvalidOperationException>(() => result.ToCreatedAtRoute("GetItem"));
    }

    // --- ToAccepted ---

    [Fact]
    public void ToAccepted_OnSuccessfulResult_ShouldReturnTypedAccepted()
    {
        var result = Result.Success("processing");

        var acceptedResult = result.ToAccepted("/api/status/123");

        Assert.NotNull(acceptedResult);
        Assert.Equal("processing", acceptedResult.Value);
        Assert.Equal("/api/status/123", acceptedResult.Location);
    }

    [Fact]
    public void ToAccepted_OnSuccessfulResult_WithoutUri_ShouldReturnAcceptedWithNullLocation()
    {
        var result = Result.Success("processing");

        var acceptedResult = result.ToAccepted();

        Assert.NotNull(acceptedResult);
        Assert.Equal("processing", acceptedResult.Value);
        Assert.Null(acceptedResult.Location);
    }

    [Fact]
    public void ToAccepted_OnFailedResult_ShouldThrowInvalidOperationException()
    {
        var result = Result.Failure<string>(Error.Failure());

        Assert.Throws<InvalidOperationException>(() => result.ToAccepted());
    }

    // --- ToNoContent ---

    [Fact]
    public void ToNoContent_OnSuccessfulNoneResult_ShouldReturnTypedNoContent()
    {
        var result = Result.Success();

        var noContentResult = result.ToNoContent();

        Assert.NotNull(noContentResult);
    }

    [Fact]
    public void ToNoContent_OnFailedNoneResult_ShouldThrowInvalidOperationException()
    {
        var result = Result.Failure(Error.Failure("Op.Failed", "Failed"));

        Assert.Throws<InvalidOperationException>(() => result.ToNoContent());
    }

    // --- MatchHttp ---

    [Fact]
    public void MatchHttp_OnSuccessfulResult_ShouldInvokeOnSuccess()
    {
        var result = Result.Success(42);

        var httpResult = result.MatchHttp(v => Results.Ok(v));

        Assert.IsType<Ok<int>>(httpResult);
    }

    [Fact]
    public void MatchHttp_OnFailedResult_WithNoCustomHandler_ShouldUseDefaultProblemMapping()
    {
        var result = Result.Failure<int>(Error.NotFound("Resource", "Not found"));

        var httpResult = result.MatchHttp(v => Results.Ok(v));

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(404, problem.ProblemDetails.Status);
    }

    [Fact]
    public void MatchHttp_OnFailedResult_WithCustomHandler_ShouldInvokeCustomHandler()
    {
        var result = Result.Failure<int>(Error.Failure());
        bool customHandlerCalled = false;

        var httpResult = result.MatchHttp(
            v => Results.Ok(v),
            errorInfo =>
            {
                customHandlerCalled = true;
                return Results.StatusCode(503);
            });

        Assert.True(customHandlerCalled);
    }

    // --- MatchHttpAsync ---

    [Fact]
    public async Task MatchHttpAsync_OnSuccessfulResult_ShouldInvokeOnSuccess()
    {
        var resultTask = Task.FromResult(Result.Success("async value"));

        var httpResult = await resultTask.MatchHttpAsync(v => Results.Ok(v));

        Assert.IsType<Ok<string>>(httpResult);
    }

    [Fact]
    public async Task MatchHttpAsync_OnFailedResult_ShouldReturnProblem()
    {
        var resultTask = Task.FromResult(Result.Failure<string>(Error.Conflict("Dupe", "Already exists")));

        var httpResult = await resultTask.MatchHttpAsync(v => Results.Ok(v));

        var problem = Assert.IsType<ProblemHttpResult>(httpResult);
        Assert.Equal(409, problem.ProblemDetails.Status);
    }
}
