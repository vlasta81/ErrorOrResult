using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace ErrorOrResult
{
    /// <summary>
    /// Represents information about one or more errors.
    /// Can hold a single error or a collection of errors.
    /// </summary>
    [CollectionBuilder(typeof(ErrorInfoBuilder), nameof(ErrorInfoBuilder.Create))]
    public readonly record struct ErrorInfo
    {
        private readonly ImmutableArray<Error> _errors;

        private ErrorInfo(ImmutableArray<Error> errors)
        {
            if (errors.IsDefaultOrEmpty)
            {
                throw new ArgumentException("Errors collection cannot be empty or default!", nameof(errors));
            }
            _errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ErrorInfo"/> with a single error.
        /// </summary>
        /// <param name="error">The error to wrap.</param>
        public ErrorInfo(Error error) : this(ImmutableArray.Create(error)) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ErrorInfo"/> with an array of errors.
        /// </summary>
        /// <param name="errors">The array of errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when errors is null.</exception>
        public ErrorInfo(Error[] errors) : this(ImmutableArray.Create(errors ?? throw new ArgumentNullException(nameof(errors)))) { }

        /// <summary>
        /// Initializes a new instance of <see cref="ErrorInfo"/> with a list of errors.
        /// </summary>
        /// <param name="errors">The list of errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when errors is null.</exception>
        public ErrorInfo(List<Error> errors) : this(errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors))) { }

        /// <summary>
        /// Gets the first error in the collection.
        /// </summary>
        public Error FirstError => _errors[0];

        /// <summary>
        /// Gets all errors as an immutable array.
        /// </summary>
        public ImmutableArray<Error> AllErrors => _errors;

        /// <summary>
        /// Gets the number of errors in this instance.
        /// </summary>
        public int Count => _errors.Length;

        /// <summary>
        /// Implicitly converts an <see cref="Error"/> to <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="error">The error to convert.</param>
        public static implicit operator ErrorInfo(Error error) => new(error);

        /// <summary>
        /// Implicitly converts an array of <see cref="Error"/> to <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="errors">The array of errors to convert.</param>
        public static implicit operator ErrorInfo(Error[] errors) => new(errors);

        /// <summary>
        /// Implicitly converts a list of <see cref="Error"/> to <see cref="ErrorInfo"/>.
        /// </summary>
        /// <param name="errors">The list of errors to convert.</param>
        public static implicit operator ErrorInfo(List<Error> errors) => new(errors);

        /// <summary>
        /// Returns a string representation of the error information.
        /// </summary>
        /// <returns>A string describing the error(s).</returns>
        public override string ToString() => Count == 1 ? $"Error: {FirstError.Code}" : $"Errors ({Count}): {string.Join(", ", _errors.Select(e => e.Code))}";
    }

}
