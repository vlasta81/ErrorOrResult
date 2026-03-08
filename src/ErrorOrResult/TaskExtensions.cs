
namespace ErrorOrResult
{
    /// <summary>
    /// Provides extension methods for converting <see cref="Task{TResult}"/> to <see cref="Result{TOutput}"/>.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Converts a task to a result, catching any exceptions as errors.
        /// </summary>
        /// <typeparam name="TOutput">The type of the task result.</typeparam>
        /// <param name="task">The task to convert.</param>
        /// <returns>A successful result with the task's value, or a failed result if an exception occurred.</returns>
        public static async Task<Result<TOutput>> ToResultAsync<TOutput>(this Task<TOutput> task)
        {
            try
            {
                return Result.Success(await task.ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return Result.Failure<TOutput>(Error.Unexpected("Exception.Caught", ex.Message));
            }
        }

        /// <summary>
        /// Converts a task that returns a nullable reference type to a result.
        /// Returns an error if the value is null or if an exception occurs.
        /// </summary>
        /// <typeparam name="TOutput">The reference type of the task result.</typeparam>
        /// <param name="task">The task to convert.</param>
        /// <param name="error">The error to use if the value is null.</param>
        /// <returns>A successful result if the value is not null, otherwise a failed result.</returns>
        public static async Task<Result<TOutput>> ToResultAsync<TOutput>(this Task<TOutput?> task, Error error) where TOutput : class
        {
            try
            {
                TOutput? value = await task.ConfigureAwait(false);
                return value is not null ? Result.Success(value) : Result.Failure<TOutput>(error);
            }
            catch (Exception ex)
            {
                return Result.Failure<TOutput>(Error.Unexpected("Exception.Caught", ex.Message));
            }
        }

        /// <summary>
        /// Converts a task that returns a nullable value type to a result.
        /// Returns an error if the value is null or if an exception occurs.
        /// </summary>
        /// <typeparam name="TOutput">The value type of the task result.</typeparam>
        /// <param name="task">The task to convert.</param>
        /// <param name="error">The error to use if the value is null.</param>
        /// <returns>A successful result if the value has a value, otherwise a failed result.</returns>
        public static async Task<Result<TOutput>> ToResultAsync<TOutput>(this Task<TOutput?> task, Error error) where TOutput : struct
        {
            try
            {
                TOutput? value = await task.ConfigureAwait(false);
                return value.HasValue ? Result.Success(value.Value) : Result.Failure<TOutput>(error);
            }
            catch (Exception ex)
            {
                return Result.Failure<TOutput>(Error.Unexpected("Exception.Caught", ex.Message));
            }
        }
    }

}
