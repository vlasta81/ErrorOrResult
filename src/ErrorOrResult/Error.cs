
namespace ErrorOrResult
{
    /// <summary>
    /// Represents an error with a code, description, and type.
    /// </summary>
    /// <param name="Code">The error code that uniquely identifies the error type.</param>
    /// <param name="Description">A human-readable description of the error.</param>
    /// <param name="Type">The type/category of the error.</param>
    public readonly record struct Error(string Code, string Description, ErrorType Type)
    {
        /// <summary>
        /// Gets the numeric representation of the error type (HTTP status code).
        /// </summary>
        public int NumericType => (int)Type;

        /// <summary>
        /// Creates a general failure error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.Failure".</param>
        /// <param name="description">The error description. Defaults to "A failure has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing a failure.</returns>
        public static Error Failure(string code = "General.Failure", string description = "A failure has occurred!") => new Error(code, description, ErrorType.Failure);

        /// <summary>
        /// Creates an unexpected error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.Unexpected".</param>
        /// <param name="description">The error description. Defaults to "An unexpected error has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing an unexpected error.</returns>
        public static Error Unexpected(string code = "General.Unexpected", string description = "An unexpected error has occurred!") => new Error(code, description, ErrorType.Unexpected);

        /// <summary>
        /// Creates a validation error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.Validation".</param>
        /// <param name="description">The error description. Defaults to "A validation error has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing a validation error.</returns>
        public static Error Validation(string code = "General.Validation", string description = "A validation error has occurred!") => new Error(code, description, ErrorType.Validation);

        /// <summary>
        /// Creates a conflict error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.Conflict".</param>
        /// <param name="description">The error description. Defaults to "A conflict error has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing a conflict error.</returns>
        public static Error Conflict(string code = "General.Conflict", string description = "A conflict error has occurred!") => new Error(code, description, ErrorType.Conflict);

        /// <summary>
        /// Creates a not found error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.NotFound".</param>
        /// <param name="description">The error description. Defaults to "A 'Not Found' error has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing a not found error.</returns>
        public static Error NotFound(string code = "General.NotFound", string description = "A 'Not Found' error has occurred!") => new Error(code, description, ErrorType.NotFound);

        /// <summary>
        /// Creates an unauthorized error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.Unauthorized".</param>
        /// <param name="description">The error description. Defaults to "An 'Unauthorized' error has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing an unauthorized error.</returns>
        public static Error Unauthorized(string code = "General.Unauthorized", string description = "An 'Unauthorized' error has occurred!") => new Error(code, description, ErrorType.Unauthorized);

        /// <summary>
        /// Creates a forbidden error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.Forbidden".</param>
        /// <param name="description">The error description. Defaults to "A 'Forbidden' error has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing a forbidden error.</returns>
        public static Error Forbidden(string code = "General.Forbidden", string description = "A 'Forbidden' error has occurred!") => new Error(code, description, ErrorType.Forbidden);

        /// <summary>
        /// Creates a bad request error.
        /// </summary>
        /// <param name="code">The error code. Defaults to "General.BadRequest".</param>
        /// <param name="description">The error description. Defaults to "A 'BadRequest' error has occurred!".</param>
        /// <returns>An <see cref="Error"/> instance representing a bad request error.</returns>
        public static Error BadRequest(string code = "General.BadRequest", string description = "A 'BadRequest' error has occurred!") => new Error(code, description, ErrorType.BadRequest);

        /// <summary>
        /// Creates a custom error with a specified type.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="description">The error description.</param>
        /// <param name="type">The error type.</param>
        /// <returns>An <see cref="Error"/> instance with custom values.</returns>
        public static Error Custom(string code, string description, ErrorType type) => new Error(code, description, type);

        /// <summary>
        /// Deconstructs the error into its components.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="description">The error description.</param>
        /// <param name="type">The error type.</param>
        public void Deconstruct(out string code, out string description, out ErrorType type)
        {
            code = Code;
            description = Description;
            type = Type;
        }
    }

}
