using System.Collections.Immutable;
using System.Diagnostics;

namespace ErrorOrResult
{
    /// <summary>
    /// Provides async extension methods for working with <see cref="Result{TOutput}"/> instances.
    /// These methods operate on Task&lt;Result&lt;T&gt;&gt; and should be used for asynchronous operations.
    /// </summary>
    public static class ResultExtensions
    {
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
                await action(result.Value).ConfigureAwait(false);
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
