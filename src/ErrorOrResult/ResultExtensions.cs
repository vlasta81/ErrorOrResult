using System.Collections.Immutable;
using System.Diagnostics;

namespace ErrorOrResult
{
    /// <summary>
    /// Provides extension methods for working with <see cref="Result{TOutput}"/> instances.
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// Maps the success value of a result to a new value using the specified selector function.
        /// If the result is in error state, the error is propagated.
        /// </summary>
        /// <typeparam name="TInput">The type of the input result value.</typeparam>
        /// <typeparam name="TOutput">The type of the output result value.</typeparam>
        /// <param name="result">The result to map.</param>
        /// <param name="selector">The function to apply to the success value.</param>
        /// <returns>A result containing the mapped value or the original error.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is uninitialized.</exception>
        public static Result<TOutput> Map<TInput, TOutput>(this Result<TInput> result, Func<TInput, TOutput> selector)
        {
            if (!result.IsSuccess && !result.IsError)
            {
                throw new InvalidOperationException("Cannot map uninitialized Result!");
            }
            return result.IsSuccess ? Result.Success(selector(result.Value)) : Result.Failure<TOutput>(result.ErrorInfo);
        }

        /// <summary>
        /// Asynchronously maps the success value of a result to a new value using the specified selector function.
        /// </summary>
        /// <typeparam name="TInput">The type of the input result value.</typeparam>
        /// <typeparam name="TOutput">The type of the output result value.</typeparam>
        /// <param name="resultTask">The task representing the result to map.</param>
        /// <param name="selector">The function to apply to the success value.</param>
        /// <returns>A task representing a result containing the mapped value or the original error.</returns>
        public static async Task<Result<TOutput>> MapAsync<TInput, TOutput>(this Task<Result<TInput>> resultTask, Func<TInput, TOutput> selector)
        {
            Result<TInput> result = await resultTask.ConfigureAwait(false);
            return result.Map(selector);
        }

        /// <summary>
        /// Chains a result with another operation that returns a result (flatMap/bind operation).
        /// If the first result is in error state, the error is propagated without executing the binder.
        /// </summary>
        /// <typeparam name="TInput">The type of the input result value.</typeparam>
        /// <typeparam name="TOutput">The type of the output result value.</typeparam>
        /// <param name="result">The result to bind.</param>
        /// <param name="binder">The function that takes the success value and returns a new result.</param>
        /// <returns>The result returned by the binder or the original error.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is uninitialized.</exception>
        public static Result<TOutput> Bind<TInput, TOutput>(this Result<TInput> result, Func<TInput, Result<TOutput>> binder)
        {
            if (!result.IsSuccess && !result.IsError)
            {
                throw new InvalidOperationException("Cannot bind uninitialized Result!");
            }
            return result.IsSuccess ? binder(result.Value) : Result.Failure<TOutput>(result.ErrorInfo);
        }

        /// <summary>
        /// Asynchronously chains a result with another asynchronous operation that returns a result.
        /// </summary>
        /// <typeparam name="TInput">The type of the input result value.</typeparam>
        /// <typeparam name="TOutput">The type of the output result value.</typeparam>
        /// <param name="resultTask">The task representing the result to bind.</param>
        /// <param name="binder">The asynchronous function that takes the success value and returns a new result.</param>
        /// <returns>A task representing the result returned by the binder or the original error.</returns>
        public static async Task<Result<TOutput>> BindAsync<TInput, TOutput>(this Task<Result<TInput>> resultTask, Func<TInput, Task<Result<TOutput>>> binder)
        {
            Result<TInput> result = await resultTask.ConfigureAwait(false);
            return result.IsSuccess ? await binder(result.Value).ConfigureAwait(false) : Result.Failure<TOutput>(result.ErrorInfo);
        }

        /// <summary>
        /// Pattern matches on the result, executing one of two functions based on success or error state.
        /// </summary>
        /// <typeparam name="TInput">The type of the input result value.</typeparam>
        /// <typeparam name="TOutput">The type of the return value.</typeparam>
        /// <param name="result">The result to match on.</param>
        /// <param name="onSuccess">The function to execute if the result is successful.</param>
        /// <param name="onFailure">The function to execute if the result is in error state.</param>
        /// <returns>The value returned by either onSuccess or onFailure.</returns>
        public static TOutput Match<TInput, TOutput>(this Result<TInput> result, Func<TInput, TOutput> onSuccess, Func<ErrorInfo, TOutput> onFailure) => result.IsSuccess ? onSuccess(result.Value) : onFailure(result.ErrorInfo);

        /// <summary>
        /// Asynchronously pattern matches on a result.
        /// </summary>
        /// <typeparam name="TInput">The type of the input result value.</typeparam>
        /// <typeparam name="TOutput">The type of the return value.</typeparam>
        /// <param name="resultTask">The task representing the result to match on.</param>
        /// <param name="onSuccess">The function to execute if the result is successful.</param>
        /// <param name="onFailure">The function to execute if the result is in error state.</param>
        /// <returns>A task representing the value returned by either onSuccess or onFailure.</returns>
        public static async Task<TOutput> MatchAsync<TInput, TOutput>(this Task<Result<TInput>> resultTask, Func<TInput, TOutput> onSuccess, Func<ErrorInfo, TOutput> onFailure)
        {
            Result<TInput> result = await resultTask.ConfigureAwait(false);
            return result.Match(onSuccess, onFailure);
        }

        /// <summary>
        /// Executes a side-effect action on the success value without modifying the result.
        /// Useful for logging or other side effects.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to tap.</param>
        /// <param name="action">The action to execute on the success value.</param>
        /// <returns>The original result unchanged.</returns>
        public static Result<TOutput> Tap<TOutput>(this Result<TOutput> result, Action<TOutput> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }
            return result;
        }

        /// <summary>
        /// Asynchronously executes a side-effect action on the success value without modifying the result.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="resultTask">The task representing the result to tap.</param>
        /// <param name="action">The asynchronous action to execute on the success value.</param>
        /// <returns>A task representing the original result unchanged.</returns>
        public static async Task<Result<TOutput>> TapAsync<TOutput>(this Task<Result<TOutput>> resultTask, Func<TOutput, Task> action)
        {
            Result<TOutput> result = await resultTask.ConfigureAwait(false);
            if (result.IsSuccess)
            {
                await action(result.Value);
            }
            return result;
        }

        /// <summary>
        /// Executes a side-effect action on the error information without modifying the result.
        /// Useful for logging errors.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to tap.</param>
        /// <param name="action">The action to execute on the error information.</param>
        /// <returns>The original result unchanged.</returns>
        public static Result<TOutput> TapError<TOutput>(this Result<TOutput> result, Action<ErrorInfo> action)
        {
            if (result.IsError)
            {
                action(result.ErrorInfo);
            }
            return result;
        }

        /// <summary>
        /// Validates the success value using a predicate. If the predicate fails, converts to an error result.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to validate.</param>
        /// <param name="predicate">The predicate to test the success value against.</param>
        /// <param name="error">The error to use if the predicate fails.</param>
        /// <returns>The original result if successful and predicate passes, otherwise a failed result.</returns>
        public static Result<TOutput> Ensure<TOutput>(this Result<TOutput> result, Func<TOutput, bool> predicate, Error error)
        {
            if (result.IsSuccess && !predicate(result.Value))
            {
                return Result.Failure<TOutput>(error);
            }
            return result;
        }

        /// <summary>
        /// Asynchronously validates the success value using a predicate.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="resultTask">The task representing the result to validate.</param>
        /// <param name="predicate">The predicate to test the success value against.</param>
        /// <param name="error">The error to use if the predicate fails.</param>
        /// <returns>A task representing the validated result.</returns>
        public static async Task<Result<TOutput>> EnsureAsync<TOutput>(this Task<Result<TOutput>> resultTask, Func<TOutput, bool> predicate, Error error)
        {
            Result<TOutput> result = await resultTask.ConfigureAwait(false);
            return result.Ensure(predicate, error);
        }

        /// <summary>
        /// Transforms all errors in a result using the specified mapper function.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result whose errors to transform.</param>
        /// <param name="mapper">The function to transform each error.</param>
        /// <returns>The original result if successful, otherwise a result with transformed errors.</returns>
        public static Result<TOutput> MapError<TOutput>(this Result<TOutput> result, Func<Error, Error> mapper)
        {
            if (!result.IsError)
            {
                return result;
            }
            ErrorInfo errorInfo = result.ErrorInfo;
            if (errorInfo.Count == 1)
            {
                return Result.Failure<TOutput>(mapper(errorInfo.FirstError));
            }
            return Result.Failure<TOutput>(errorInfo.AllErrors.Select(mapper).ToArray());
        }

        /// <summary>
        /// Combines two results into a single result containing a tuple of both values.
        /// If either result is in error state, all errors are combined.
        /// </summary>
        /// <typeparam name="TOutput1">The type of the first result value.</typeparam>
        /// <typeparam name="TOutput2">The type of the second result value.</typeparam>
        /// <param name="result1">The first result.</param>
        /// <param name="result2">The second result.</param>
        /// <returns>A result containing a tuple of both values if both are successful, otherwise a combined error result.</returns>
        public static Result<(TOutput1, TOutput2)> Combine<TOutput1, TOutput2>(this Result<TOutput1> result1, Result<TOutput2> result2)
        {
            if (result1.IsSuccess && result2.IsSuccess)
            {
                return Result.Success((result1.Value, result2.Value));
            }
            ImmutableArray<Error>.Builder errors = ImmutableArray.CreateBuilder<Error>();
            if (result1.IsError) errors.AddRange(result1.Errors);
            if (result2.IsError) errors.AddRange(result2.Errors);
            return Result.Failure<(TOutput1, TOutput2)>(errors.ToArray());
        }

        /// <summary>
        /// Executes one of two actions based on whether the result is successful or in error state.
        /// Similar to Match but returns void.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to switch on.</param>
        /// <param name="onSuccess">The action to execute if the result is successful.</param>
        /// <param name="onFailure">The action to execute if the result is in error state.</param>
        public static void Switch<TOutput>(this Result<TOutput> result, Action<TOutput> onSuccess, Action<ErrorInfo> onFailure)
        {
            if (result.IsSuccess)
            {
                onSuccess(result.Value);
            }
            else
            {
                onFailure(result.ErrorInfo);
            }
        }

        /// <summary>
        /// Throws an exception if the result is in error state, otherwise returns the success value.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="result">The result to check.</param>
        /// <returns>The success value if the result is successful.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        [StackTraceHidden]
        public static TOutput ThrowOnError<TOutput>(this Result<TOutput> result)
        {
            if (result.IsError)
            {
                Error error = result.Error;
                throw new InvalidOperationException($"Error: {error.Code} - {error.Description}");
            }
            return result.Value;
        }

        /// <summary>
        /// Asynchronously throws an exception if the result is in error state, otherwise returns the success value.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="resultTask">The task representing the result to check.</param>
        /// <returns>A task representing the success value if the result is successful.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        [StackTraceHidden]
        public static async Task<TOutput> ThrowOnErrorAsync<TOutput>(this Task<Result<TOutput>> resultTask)
        {
            Result<TOutput> result = await resultTask.ConfigureAwait(false);
            return result.ThrowOnError();
        }
    }

}
