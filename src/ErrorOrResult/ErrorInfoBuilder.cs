
namespace ErrorOrResult
{
    /// <summary>
    /// Internal builder for creating <see cref="ErrorInfo"/> instances from collections.
    /// </summary>
    internal static class ErrorInfoBuilder
    {
        /// <summary>
        /// Creates an <see cref="ErrorInfo"/> from a read-only span of errors.
        /// </summary>
        /// <param name="errors">The span of errors.</param>
        /// <returns>An <see cref="ErrorInfo"/> instance.</returns>
        internal static ErrorInfo Create(ReadOnlySpan<Error> errors) => new ErrorInfo(errors.ToArray());
    }

}
