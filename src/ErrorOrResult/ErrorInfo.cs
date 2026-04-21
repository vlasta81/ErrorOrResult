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
        /// Creates an <see cref="ErrorInfo"/> from an already-constructed <see cref="ImmutableArray{Error}"/>
        /// without performing a defensive copy. The array must be non-default and non-empty.
        /// </summary>
        /// <param name="errors">A populated immutable array of errors.</param>
        /// <returns>A new <see cref="ErrorInfo"/> instance wrapping the provided array.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="errors"/> is default or empty.</exception>
        internal static ErrorInfo FromImmutable(ImmutableArray<Error> errors) => new ErrorInfo(errors);

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
        /// <exception cref="ArgumentException">Thrown when errors is empty.</exception>
        public ErrorInfo(Error[] errors)
        {
            ArgumentNullException.ThrowIfNull(errors);
            if (errors.Length == 0) throw new ArgumentException("Errors collection cannot be empty!", nameof(errors));
            _errors = ImmutableArray.Create(errors);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ErrorInfo"/> with a list of errors.
        /// </summary>
        /// <param name="errors">The list of errors.</param>
        /// <exception cref="ArgumentNullException">Thrown when errors is null.</exception>
        /// <exception cref="ArgumentException">Thrown when errors is empty.</exception>
        public ErrorInfo(List<Error> errors)
        {
            ArgumentNullException.ThrowIfNull(errors);
            if (errors.Count == 0) throw new ArgumentException("Errors collection cannot be empty!", nameof(errors));
            _errors = ImmutableArray.CreateRange(errors);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ErrorInfo"/> with a span of errors.
        /// </summary>
        /// <param name="errors">The span of errors.</param>
        /// <exception cref="ArgumentException">Thrown when errors is empty.</exception>
        public ErrorInfo(ReadOnlySpan<Error> errors)
        {
            if (errors.IsEmpty) throw new ArgumentException("Errors collection cannot be empty!", nameof(errors));
            _errors = ImmutableArray.Create(errors);
        }

        /// <summary>
        /// Gets the first error in the collection.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the instance is uninitialized (default).</exception>
        public Error FirstError => _errors.IsDefaultOrEmpty ? throw new InvalidOperationException("ErrorInfo is uninitialized or empty.") : _errors[0];

        /// <summary>
        /// Gets all errors as an immutable array. Returns an empty array when the instance is uninitialized (default).
        /// </summary>
        public ImmutableArray<Error> AllErrors => _errors.IsDefault ? ImmutableArray<Error>.Empty : _errors;

        /// <summary>
        /// Gets the number of errors in this instance.
        /// </summary>
        public int Count => _errors.IsDefault ? 0 : _errors.Length;

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
        public override string ToString()
        {
            if (_errors.IsDefaultOrEmpty)
            {
                return "No errors";
            }
            if (_errors.Length == 1)
            {
                return $"Error: {_errors[0].Code}";
            }
            string[] codes = new string[_errors.Length];
            for (int i = 0; i < _errors.Length; i++)
            {
                codes[i] = _errors[i].Code;
            }
            return $"Errors ({_errors.Length}): {string.Join(", ", codes)}";
        }
    }

}
