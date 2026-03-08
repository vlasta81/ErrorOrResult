using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ErrorOrResult
{
    /// <summary>
    /// Provides extension methods for converting <see cref="Result{TOutput}"/> instances to ASP.NET Core HTTP responses.
    /// </summary>
    public static class ResultHttpExtensions
    {

        /// <summary>
        /// Converts a result to an HTTP response.
        /// Returns OK (200) with the value on success, or a problem details response on error.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to convert.</param>
        /// <param name="onSuccess">Optional custom function to create the success response.</param>
        /// <returns>An <see cref="IResult"/> representing the HTTP response.</returns>
        public static IResult ToHttpResult<TOutput>(this Result<TOutput> result, Func<TOutput, IResult>? onSuccess = null)
        {
            if (result.IsSuccess)
            {
                return onSuccess?.Invoke(result.Value) ?? Results.Ok(result.Value);
            }
            return result.ErrorInfo.ToProblem();
        }

        /// <summary>
        /// Converts a result with no value to an HTTP response.
        /// Returns NoContent (204) on success, or a problem details response on error.
        /// </summary>
        /// <param name="result">The result to convert.</param>
        /// <returns>An <see cref="IResult"/> representing the HTTP response.</returns>
        public static IResult ToHttpResult(this Result<None> result)
        {
            if (result.IsSuccess)
            {
                return Results.NoContent();
            }
            return result.ErrorInfo.ToProblem();
        }

        /// <summary>
        /// Asynchronously converts a result to an HTTP response.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="resultTask">The task representing the result to convert.</param>
        /// <param name="onSuccess">Optional custom function to create the success response.</param>
        /// <returns>A task representing an <see cref="IResult"/> HTTP response.</returns>
        public static async Task<IResult> ToHttpResultAsync<TOutput>(this Task<Result<TOutput>> resultTask, Func<TOutput, IResult>? onSuccess = null)
        {
            return (await resultTask.ConfigureAwait(false)).ToHttpResult(onSuccess);
        }

        /// <summary>
        /// Asynchronously converts a result with no value to an HTTP response.
        /// </summary>
        /// <param name="resultTask">The task representing the result to convert.</param>
        /// <returns>A task representing an <see cref="IResult"/> HTTP response.</returns>
        public static async Task<IResult> ToHttpResultAsync(this Task<Result<None>> resultTask)
        {
            return (await resultTask.ConfigureAwait(false)).ToHttpResult();
        }

        /// <summary>
        /// Converts a successful result to a typed OK (200) response.
        /// Throws an exception if the result is in error state.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to convert.</param>
        /// <returns>A typed OK response with the value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        public static Ok<TOutput> ToOk<TOutput>(this Result<TOutput> result)
        {
            return TypedResults.Ok(EnsureSuccess(result));
        }

        /// <summary>
        /// Converts a successful result to a typed CreatedAtRoute (201) response.
        /// Throws an exception if the result is in error state.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to convert.</param>
        /// <param name="routeName">The name of the route to use for generating the location URI.</param>
        /// <param name="routeValues">The route values to use for generating the location URI.</param>
        /// <returns>A typed CreatedAtRoute response with the value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        public static CreatedAtRoute<TOutput> ToCreatedAtRoute<TOutput>(this Result<TOutput> result, string routeName, object? routeValues = null)
        {
            return TypedResults.CreatedAtRoute(EnsureSuccess(result), routeName, routeValues);
        }

        /// <summary>
        /// Converts a successful result to a typed Created (201) response.
        /// Throws an exception if the result is in error state.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to convert.</param>
        /// <param name="uri">The location URI for the created resource.</param>
        /// <returns>A typed Created response with the value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        public static Created<TOutput> ToCreated<TOutput>(this Result<TOutput> result, string uri)
        {
            return TypedResults.Created(uri, EnsureSuccess(result));
        }

        /// <summary>
        /// Converts a successful result to a typed Accepted (202) response.
        /// Throws an exception if the result is in error state.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to convert.</param>
        /// <param name="uri">Optional location URI where the status of the operation can be monitored.</param>
        /// <returns>A typed Accepted response with the value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        public static Accepted<TOutput> ToAccepted<TOutput>(this Result<TOutput> result, string? uri = null)
        {
            return TypedResults.Accepted(uri, EnsureSuccess(result));
        }

        /// <summary>
        /// Converts a successful result with no value to a typed NoContent (204) response.
        /// Throws an exception if the result is in error state.
        /// </summary>
        /// <param name="result">The result to convert.</param>
        /// <returns>A typed NoContent response.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        public static NoContent ToNoContent(this Result<None> result)
        {
            if (!result.IsSuccess)
            {
                throw new InvalidOperationException($"Cannot convert error result to NoContent. Error: {result.Error.Code}");
            }
            return TypedResults.NoContent();
        }

        /// <summary>
        /// Pattern matches on a result and executes one of two functions to create an HTTP response.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to match on.</param>
        /// <param name="onSuccess">The function to execute if the result is successful.</param>
        /// <param name="onFailure">Optional function to execute if the result is in error state. If not provided, uses default error handling.</param>
        /// <returns>An <see cref="IResult"/> representing the HTTP response.</returns>
        public static IResult MatchHttp<TOutput>(this Result<TOutput> result, Func<TOutput, IResult> onSuccess, Func<ErrorInfo, IResult>? onFailure = null)
        {
            if (result.IsSuccess)
            {
                return onSuccess(result.Value);
            }
            if (onFailure is not null)
            {
                return onFailure(result.ErrorInfo);
            }
            return result.ToHttpResult();
        }

        /// <summary>
        /// Asynchronously pattern matches on a result and executes one of two functions to create an HTTP response.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="resultTask">The task representing the result to match on.</param>
        /// <param name="onSuccess">The function to execute if the result is successful.</param>
        /// <param name="onFailure">Optional function to execute if the result is in error state. If not provided, uses default error handling.</param>
        /// <returns>A task representing an <see cref="IResult"/> HTTP response.</returns>
        public static async Task<IResult> MatchHttpAsync<TOutput>(this Task<Result<TOutput>> resultTask, Func<TOutput, IResult> onSuccess, Func<ErrorInfo, IResult>? onFailure = null)
        {
            Result<TOutput> result = await resultTask.ConfigureAwait(false);
            return result.MatchHttp(onSuccess, onFailure);
        }

        /// <summary>
        /// Converts error information to a Problem Details (RFC 7807) HTTP response.
        /// Maps error types to appropriate HTTP status codes.
        /// </summary>
        /// <param name="errorInfo">The error information to convert.</param>
        /// <returns>An <see cref="IResult"/> representing a problem details response.</returns>
        public static IResult ToProblem(this ErrorInfo errorInfo)
        {
            Error first = errorInfo.FirstError;
            return first.Type switch
            {
                ErrorType.Validation => errorInfo.ToValidationProblem(),
                ErrorType.Unauthorized => Results.Problem(
                    title: first.Code,
                    detail: first.Description,
                    statusCode: 401),
                ErrorType.Forbidden => Results.Problem(
                    title: first.Code,
                    detail: first.Description,
                    statusCode: 403),
                _ => Results.Problem(
                    title: first.Code,
                    detail: first.Description,
                    statusCode: first.NumericType,
                    extensions: errorInfo.Count > 1 ? new Dictionary<string, object?>
                    {
                        ["errors"] = errorInfo.AllErrors.Select(e => new
                        {
                            code = e.Code,
                            message = e.Description
                        })
                    } : null)
            };
        }

        private static TOutput EnsureSuccess<TOutput>(Result<TOutput> result)
        {
            if (!result.IsSuccess)
            {
                throw new InvalidOperationException($"Error: {result.Error.Code}");
            }
            return result.Value;
        }

        /// <summary>
        /// Converts error information to a validation problem details response (HTTP 422).
        /// Groups errors by their code.
        /// </summary>
        /// <param name="errorInfo">The error information to convert.</param>
        /// <returns>An <see cref="IResult"/> representing a validation problem response.</returns>
        public static IResult ToValidationProblem(this ErrorInfo errorInfo)
        {
            Dictionary<string, string[]> errors = errorInfo.AllErrors.GroupBy(e => e.Code).ToDictionary(
                g => g.Key,
                g => g.Select(e => e.Description).ToArray()
            );
            return Results.ValidationProblem(errors);
        }

    }

}
