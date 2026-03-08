
namespace ErrorOrResult
{
    /// <summary>
    /// Provides extension methods for working with <see cref="Error"/> instances.
    /// </summary>
    public static class ErrorExtensions
    {
        /// <summary>
        /// Creates a new error with the specified description, keeping the original code and type.
        /// </summary>
        /// <param name="error">The original error.</param>
        /// <param name="newDescription">The new description to apply to the error.</param>
        /// <returns>A new <see cref="Error"/> with the updated description.</returns>
        public static Error WithDescription(this Error error, string newDescription) => error with { Description = newDescription };
    }
}
