using System.Collections.Immutable;
using System.Diagnostics;

namespace ErrorOrResult
{
    /// <summary>
    /// Represents the result of an operation that can either succeed with a value or fail with error information.
    /// </summary>
    /// <typeparam name="TOutput">The type of the success value.</typeparam>
    public readonly struct Result<TOutput>
    {
        private readonly TOutput? _value;
        private readonly ErrorInfo _errorInfo;
        private readonly bool _isSuccess;

        private Result(bool isSuccess, TOutput? value, ErrorInfo errorInfo)
        {
            _isSuccess = isSuccess;
            _value = value;
            _errorInfo = errorInfo;
        }

        /// <summary>
        /// Gets a value indicating whether the result represents a successful operation.
        /// </summary>
        public bool IsSuccess => _isSuccess;

        /// <summary>
        /// Gets a value indicating whether the result represents a failed operation.
        /// </summary>
        public bool IsError => _errorInfo.Count > 0;

        /// <summary>
        /// Gets the success value. Throws an exception if the result is in an error state.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when accessing value in error state.</exception>
        public TOutput Value => IsSuccess ? _value! : throw new InvalidOperationException($"Cannot access value when in error state: {_errorInfo}");

        /// <summary>
        /// Gets the error information. Throws an exception if the result is in a success state.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when accessing error info in success state.</exception>
        public ErrorInfo ErrorInfo => IsError ? _errorInfo : throw new InvalidOperationException("Cannot access error info when in success state");

        /// <summary>
        /// Gets the first error. Throws an exception if the result is in a success state.
        /// </summary>
        public Error Error => ErrorInfo.FirstError;

        /// <summary>
        /// Gets all errors as an immutable array. Throws an exception if the result is in a success state.
        /// </summary>
        public ImmutableArray<Error> Errors => ErrorInfo.AllErrors;

        /// <summary>
        /// Creates a successful result with the specified value.
        /// </summary>
        /// <param name="value">The success value.</param>
        /// <returns>A successful <see cref="Result{TOutput}"/>.</returns>
        public static Result<TOutput> Success(TOutput value) => new Result<TOutput>(true, value, default);

        /// <summary>
        /// Creates a failed result with the specified errors.
        /// </summary>
        /// <param name="errors">The errors that occurred.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when no errors are provided.</exception>
        public static Result<TOutput> Failure(params ReadOnlySpan<Error> errors)
        {
            if (errors.IsEmpty)
            {
                throw new ArgumentException("At least one error required!", nameof(errors));
            }
            return new Result<TOutput>(false, default, new ErrorInfo(errors));
        }

        //public static Result<TOutput> Failure(Error error) => new Result<TOutput>(default, new ErrorInfo(error));
        //public static Result<TOutput> Failure(Error[] errors) => new Result<TOutput>(default, new ErrorInfo(errors));
        //public static Result<TOutput> Failure(List<Error> errors) => new Result<TOutput>(default, new ErrorInfo(errors));

        /// <summary>
        /// Creates a failed result with the specified error information.
        /// </summary>
        /// <param name="errorInfo">The error information. Must not be <c>default</c>.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="errorInfo"/> is <c>default</c> (uninitialized).</exception>
        public static Result<TOutput> Failure(ErrorInfo errorInfo)
        {
            if (errorInfo.Count == 0)
            {
                throw new ArgumentException("ErrorInfo must contain at least one error.", nameof(errorInfo));
            }
            return new Result<TOutput>(false, default, errorInfo);
        }

        /// <summary>
        /// Implicitly converts a value to a successful result.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        public static implicit operator Result<TOutput>(TOutput value) => Success(value);

        /// <summary>
        /// Implicitly converts an error to a failed result.
        /// </summary>
        /// <param name="error">The error to convert.</param>
        public static implicit operator Result<TOutput>(Error error) => Failure(error);

        /// <summary>
        /// Implicitly converts error information to a failed result.
        /// </summary>
        /// <param name="errorInfo">The error information to convert.</param>
        public static implicit operator Result<TOutput>(ErrorInfo errorInfo) => Failure(errorInfo);

        /// <summary>
        /// Gets the success value or returns the specified default value if the result is in an error state.
        /// </summary>
        /// <param name="defaultValue">The default value to return if in error state.</param>
        /// <returns>The success value or the default value.</returns>
        public TOutput GetValueOrDefault(TOutput defaultValue = default!) => IsSuccess ? _value! : defaultValue;

        /// <summary>
        /// Gets the success value or throws an exception if the result is in an error state.
        /// </summary>
        /// <returns>The success value.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in an error state.</exception>
        [StackTraceHidden]
        public TOutput GetValueOrThrow()
        {
            if (!IsSuccess)
            {
                throw new InvalidOperationException($"Result is in error state: {_errorInfo}!");
            }
            return _value!;
        }

        /// <summary>
        /// Returns a string representation of the result.
        /// </summary>
        /// <returns>A string describing the result state and value or error.</returns>
        public override string ToString() => !IsSuccess && !IsError ? "Uninitialized Result!" : IsSuccess ? $"Success: {_value}" : $"Failure: {_errorInfo}";


        /// <summary>
        /// Maps the success value of a result to a new value using the specified selector function.
        /// If the result is in error state, the error is propagated.
        /// </summary>
        /// <typeparam name="TResult">The type of the output result value.</typeparam>
        /// <param name="selector">The function to apply to the success value.</param>
        /// <returns>A result containing the mapped value or the original error.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is uninitialized.</exception>
        public Result<TResult> Map<TResult>(Func<TOutput, TResult> selector)
        {
            if (!IsSuccess && !IsError)
            {
                throw new InvalidOperationException("Cannot map uninitialized Result!");
            }
            return IsSuccess ? Result.Success(selector(_value!)) : Result.Failure<TResult>(_errorInfo);
        }

        /// <summary>
        /// Chains a result with another operation that returns a result (flatMap/bind operation).
        /// If the first result is in error state, the error is propagated without executing the binder.
        /// </summary>
        /// <typeparam name="TResult">The type of the output result value.</typeparam>
        /// <param name="binder">The function that takes the success value and returns a new result.</param>
        /// <returns>The result returned by the binder or the original error.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is uninitialized.</exception>
        public Result<TResult> Bind<TResult>(Func<TOutput, Result<TResult>> binder)
        {
            if (!IsSuccess && !IsError)
            {
                throw new InvalidOperationException("Cannot bind uninitialized Result!");
            }
            return IsSuccess ? binder(_value!) : Result.Failure<TResult>(_errorInfo);
        }

        /// <summary>
        /// Pattern matches on the result, executing one of two functions based on success or error state.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="onSuccess">The function to execute if the result is successful.</param>
        /// <param name="onFailure">The function to execute if the result is in error state.</param>
        /// <returns>The value returned by either onSuccess or onFailure.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is uninitialized.</exception>
        public TResult Match<TResult>(Func<TOutput, TResult> onSuccess, Func<ErrorInfo, TResult> onFailure)
        {
            if (!IsSuccess && !IsError)
            {
                throw new InvalidOperationException("Cannot match uninitialized Result!");
            }
            return IsSuccess ? onSuccess(_value!) : onFailure(_errorInfo);
        }

        /// <summary>
        /// Executes a side-effect action on the success value without modifying the result.
        /// Useful for logging or other side effects.
        /// </summary>
        /// <param name="action">The action to execute on the success value.</param>
        /// <returns>The original result unchanged.</returns>
        public Result<TOutput> Tap(Action<TOutput> action)
        {
            if (IsSuccess)
            {
                action(_value!);
            }
            return this;
        }

        /// <summary>
        /// Executes a side-effect action on the error information without modifying the result.
        /// Useful for logging errors.
        /// </summary>
        /// <param name="action">The action to execute on the error information.</param>
        /// <returns>The original result unchanged.</returns>
        public Result<TOutput> TapError(Action<ErrorInfo> action)
        {
            if (IsError)
            {
                action(_errorInfo);
            }
            return this;
        }

        /// <summary>
        /// Validates the success value using a predicate. If the predicate fails, converts to an error result.
        /// </summary>
        /// <param name="predicate">The predicate to test the success value against.</param>
        /// <param name="error">The error to use if the predicate fails.</param>
        /// <returns>The original result if successful and predicate passes, otherwise a failed result.</returns>
        public Result<TOutput> Ensure(Func<TOutput, bool> predicate, Error error)
        {
            if (IsSuccess && !predicate(_value!))
            {
                return Result.Failure<TOutput>(error);
            }
            return this;
        }

        /// <summary>
        /// Transforms all errors in a result using the specified mapper function.
        /// </summary>
        /// <param name="mapper">The function to transform each error.</param>
        /// <returns>The original result if successful, otherwise a result with transformed errors.</returns>
        public Result<TOutput> MapError(Func<Error, Error> mapper)
        {
            ArgumentNullException.ThrowIfNull(mapper);
            if (!IsError)
            {
                return this;
            }
            ErrorInfo errorInfo = _errorInfo;
            if (errorInfo.Count == 1)
            {
                return Result.Failure<TOutput>(mapper(errorInfo.FirstError));
            }
            ImmutableArray<Error> mapped = ImmutableArray.CreateRange(errorInfo.AllErrors, mapper);
            return Result.Failure<TOutput>(ErrorInfo.FromImmutable(mapped));
        }

        /// <summary>
        /// Executes one of two actions based on whether the result is successful or in error state.
        /// Similar to Match but returns void.
        /// </summary>
        /// <param name="onSuccess">The action to execute if the result is successful.</param>
        /// <param name="onFailure">The action to execute if the result is in error state.</param>
        /// <exception cref="InvalidOperationException">Thrown when the result is uninitialized.</exception>
        public void Switch(Action<TOutput> onSuccess, Action<ErrorInfo> onFailure)
        {
            if (!IsSuccess && !IsError)
            {
                throw new InvalidOperationException("Cannot switch uninitialized Result!");
            }
            if (IsSuccess)
            {
                onSuccess(_value!);
            }
            else
            {
                onFailure(_errorInfo);
            }
        }

        /// <summary>
        /// Throws an exception if the result is in error state, otherwise returns the success value.
        /// </summary>
        /// <returns>The success value if the result is successful.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the result is in error state.</exception>
        [StackTraceHidden]
        public TOutput ThrowOnError()
        {
            if (IsError)
            {
                Error error = _errorInfo.FirstError;
                throw new InvalidOperationException($"Error: {error.Code} - {error.Description}");
            }
            return _value!;
        }

        /// <summary>
        /// Combines this result with another result into a single result containing a tuple of both values.
        /// If either result is in error state, all errors are combined (errors from <c>this</c> first, then from <paramref name="other"/>).
        /// </summary>
        /// <remarks>
        /// Errors are concatenated in the order of operands. The first error determines the resulting HTTP status code
        /// when converted via <c>ToProblem</c>. If different <see cref="ErrorType"/> values are combined, callers should
        /// be aware that the representative type is <c>FirstError.Type</c>.
        /// </remarks>
        /// <typeparam name="TOther">The type of the other result value.</typeparam>
        /// <param name="other">The other result to combine with.</param>
        /// <returns>A result containing a tuple of both values if both are successful, otherwise a combined error result.</returns>
        public Result<(TOutput, TOther)> Combine<TOther>(Result<TOther> other)
        {
            if ((!IsSuccess && !IsError) || (!other.IsSuccess && !other.IsError))
            {
                throw new InvalidOperationException("Cannot combine uninitialized Result!");
            }
            if (IsSuccess && other.IsSuccess)
            {
                return Result.Success((_value!, other._value!));
            }
            int thisCount = IsError ? _errorInfo.Count : 0;
            int otherCount = other.IsError ? other._errorInfo.Count : 0;
            ImmutableArray<Error>.Builder builder = ImmutableArray.CreateBuilder<Error>(thisCount + otherCount);
            if (IsError) builder.AddRange(_errorInfo.AllErrors);
            if (other.IsError) builder.AddRange(other._errorInfo.AllErrors);
            return Result.Failure<(TOutput, TOther)>(ErrorInfo.FromImmutable(builder.MoveToImmutable()));
        }

        /// <summary>
        /// Combines this result with another result into a single result containing a tuple of both values,
        /// optionally reordering combined errors using the specified comparer.
        /// </summary>
        /// <remarks>
        /// When <paramref name="errorComparer"/> is <c>null</c>, behaves identically to <see cref="Combine{TOther}(Result{TOther})"/>
        /// (errors from <c>this</c> first, then from <paramref name="other"/>). When a comparer is supplied, errors are
        /// stable-sorted by it &#8212; useful for placing the most actionable error first (e.g. <see cref="ErrorComparers.BySeverityDescending"/>),
        /// which then determines the HTTP status code produced by <c>ToProblem</c>.
        /// </remarks>
        /// <typeparam name="TOther">The type of the other result value.</typeparam>
        /// <param name="other">The other result to combine with.</param>
        /// <param name="errorComparer">Optional comparer used to stable-sort combined errors. When <c>null</c>, operand order is preserved.</param>
        /// <returns>A result containing a tuple of both values if both are successful, otherwise a combined error result.</returns>
        public Result<(TOutput, TOther)> Combine<TOther>(Result<TOther> other, IComparer<Error>? errorComparer)
        {
            Result<(TOutput, TOther)> combined = Combine(other);
            if (errorComparer is null || !combined.IsError || combined._errorInfo.Count < 2)
            {
                return combined;
            }
            Error[] sorted = combined._errorInfo.AllErrors.ToArray();
            Array.Sort(sorted, errorComparer);
            return Result.Failure<(TOutput, TOther)>(ErrorInfo.FromImmutable(ImmutableArray.Create(sorted)));
        }
    }

    /// <summary>
    /// Provides static factory methods for creating <see cref="Result{TOutput}"/> instances.
    /// </summary>
    public static class Result
    {
        private static readonly Result<None> _successNone = Result<None>.Success(default);

        /// <summary>
        /// Default generic description used when an exception is captured by <c>Try</c>/<c>TryAsync</c>.
        /// The exception message is intentionally omitted to avoid leaking sensitive information.
        /// </summary>
        internal const string DefaultExceptionDescription = "An exception was thrown during execution.";

        /// <summary>
        /// Creates a successful result with no value (using <see cref="None"/>).
        /// </summary>
        /// <returns>A successful result with no value.</returns>
        public static Result<None> Success() => _successNone;

        /// <summary>
        /// Creates a successful result with the specified value.
        /// </summary>
        /// <typeparam name="TOutput">The type of the success value.</typeparam>
        /// <param name="value">The success value.</param>
        /// <returns>A successful <see cref="Result{TOutput}"/>.</returns>
        public static Result<TOutput> Success<TOutput>(TOutput value) => Result<TOutput>.Success(value);

        /// <summary>
        /// Creates a failed result with a single error.
        /// </summary>
        /// <typeparam name="TOutput">The type of the success value.</typeparam>
        /// <param name="error">The error that occurred.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
        public static Result<TOutput> Failure<TOutput>(Error error) => Result<TOutput>.Failure(error);

        /// <summary>
        /// Creates a failed result with an array of errors.
        /// </summary>
        /// <typeparam name="TOutput">The type of the success value.</typeparam>
        /// <param name="errors">The errors that occurred.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="errors"/> is null.</exception>
        public static Result<TOutput> Failure<TOutput>(Error[] errors)
        {
            ArgumentNullException.ThrowIfNull(errors);
            return Result<TOutput>.Failure(errors);
        }

        /// <summary>
        /// Creates a failed result with a list of errors.
        /// </summary>
        /// <typeparam name="TOutput">The type of the success value.</typeparam>
        /// <param name="errors">The errors that occurred.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="errors"/> is null.</exception>
        public static Result<TOutput> Failure<TOutput>(List<Error> errors) => Result<TOutput>.Failure(errors);

        /// <summary>
        /// Creates a failed result with error information.
        /// </summary>
        /// <typeparam name="TOutput">The type of the success value.</typeparam>
        /// <param name="errorInfo">The error information.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
        public static Result<TOutput> Failure<TOutput>(ErrorInfo errorInfo) => Result<TOutput>.Failure(errorInfo);

        /// <summary>
        /// Creates a failed result with no value and a single error.
        /// </summary>
        /// <param name="error">The error that occurred.</param>
        /// <returns>A failed result with no value.</returns>
        public static Result<None> Failure(Error error) => Result<None>.Failure(error);

        /// <summary>
        /// Creates a failed result with no value and an array of errors.
        /// </summary>
        /// <param name="errors">The errors that occurred.</param>
        /// <returns>A failed result with no value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="errors"/> is null.</exception>
        public static Result<None> Failure(Error[] errors)
        {
            ArgumentNullException.ThrowIfNull(errors);
            return Result<None>.Failure(errors);
        }

        /// <summary>
        /// Creates a failed result with no value and a list of errors.
        /// </summary>
        /// <param name="errors">The errors that occurred.</param>
        /// <returns>A failed result with no value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="errors"/> is null.</exception>
        public static Result<None> Failure(List<Error> errors) => Result<None>.Failure(errors);

        /// <summary>
        /// Creates a failed result with no value and error information.
        /// </summary>
        /// <param name="errorInfo">The error information.</param>
        /// <returns>A failed result with no value.</returns>
        public static Result<None> Failure(ErrorInfo errorInfo) => Result<None>.Failure(errorInfo);

        /// <summary>
        /// Executes a function and captures any exceptions as errors.
        /// </summary>
        /// <typeparam name="TOutput">The type of the function's return value.</typeparam>
        /// <param name="func">The function to execute.</param>
        /// <returns>A successful result with the function's return value, or a failed result if an exception occurred.</returns>
        public static Result<TOutput> Try<TOutput>(Func<TOutput> func)
        {
            ArgumentNullException.ThrowIfNull(func);
            try
            {
                return Success(func());
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception)
            {
                return Failure<TOutput>(Error.Unexpected("Exception.Caught", DefaultExceptionDescription));
            }
        }

        /// <summary>
        /// Executes a function and captures any exceptions using a caller-supplied mapper.
        /// </summary>
        /// <typeparam name="TOutput">The type of the function's return value.</typeparam>
        /// <param name="func">The function to execute.</param>
        /// <param name="exceptionMapper">A function that converts a caught exception into an <see cref="Error"/>.</param>
        /// <returns>A successful result with the function's return value, or a failed result mapped from the exception.</returns>
        public static Result<TOutput> Try<TOutput>(Func<TOutput> func, Func<Exception, Error> exceptionMapper)
        {
            ArgumentNullException.ThrowIfNull(func);
            ArgumentNullException.ThrowIfNull(exceptionMapper);
            try
            {
                return Success(func());
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return Failure<TOutput>(exceptionMapper(ex));
            }
        }

        /// <summary>
        /// Executes an asynchronous function and captures any exceptions as errors.
        /// </summary>
        /// <typeparam name="TOutput">The type of the function's return value.</typeparam>
        /// <param name="func">The asynchronous function to execute.</param>
        /// <returns>A task representing a successful result with the function's return value, or a failed result if an exception occurred.</returns>
        public static async Task<Result<TOutput>> TryAsync<TOutput>(Func<Task<TOutput>> func)
        {
            ArgumentNullException.ThrowIfNull(func);
            try
            {
                return Success(await func().ConfigureAwait(false));
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception)
            {
                return Failure<TOutput>(Error.Unexpected("Exception.Caught", DefaultExceptionDescription));
            }
        }

        /// <summary>
        /// Executes an asynchronous function and captures any exceptions using a caller-supplied mapper.
        /// </summary>
        /// <typeparam name="TOutput">The type of the function's return value.</typeparam>
        /// <param name="func">The asynchronous function to execute.</param>
        /// <param name="exceptionMapper">A function that converts a caught exception into an <see cref="Error"/>.</param>
        /// <returns>A task representing a successful result with the function's return value, or a failed result mapped from the exception.</returns>
        public static async Task<Result<TOutput>> TryAsync<TOutput>(Func<Task<TOutput>> func, Func<Exception, Error> exceptionMapper)
        {
            ArgumentNullException.ThrowIfNull(func);
            ArgumentNullException.ThrowIfNull(exceptionMapper);
            try
            {
                return Success(await func().ConfigureAwait(false));
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                return Failure<TOutput>(exceptionMapper(ex));
            }
        }

        /// <summary>
        /// Creates a result from a nullable reference type value.
        /// </summary>
        /// <typeparam name="TOutput">The reference type.</typeparam>
        /// <param name="value">The value to wrap.</param>
        /// <param name="error">The error to use if the value is null.</param>
        /// <returns>A successful result if the value is not null, otherwise a failed result.</returns>
        public static Result<TOutput> Create<TOutput>(TOutput value, Error? error = null) where TOutput : class => value is not null ? Success(value) : Failure<TOutput>(error ?? Error.Failure("Value.Null", "Value cannot be null!"));

        /// <summary>
        /// Creates a result from a nullable value type.
        /// </summary>
        /// <typeparam name="TOutput">The value type.</typeparam>
        /// <param name="value">The nullable value to wrap.</param>
        /// <param name="error">The error to use if the value is null.</param>
        /// <returns>A successful result if the value has a value, otherwise a failed result.</returns>
        public static Result<TOutput> Create<TOutput>(TOutput? value, Error? error = null) where TOutput : struct => value.HasValue ? Success(value.Value) : Failure<TOutput>(error ?? Error.Failure("Value.Null", "Value cannot be null!"));

        /// <summary>
        /// Creates a result based on a predicate check.
        /// </summary>
        /// <typeparam name="TOutput">The type of the value.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="predicate">The predicate to test the value against.</param>
        /// <param name="error">The error to use if the predicate fails.</param>
        /// <returns>A successful result if the predicate passes, otherwise a failed result.</returns>
        public static Result<TOutput> Ensure<TOutput>(TOutput value, Func<TOutput, bool> predicate, Error error) => predicate(value) ? Success(value) : Failure<TOutput>(error);

        /// <summary>
        /// Executes a function that returns a result.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="func">The function to execute.</param>
        /// <returns>The result returned by the function.</returns>
        public static Result<TOutput> Of<TOutput>(Func<Result<TOutput>> func) => func();

        /// <summary>
        /// Executes an asynchronous function that returns a result.
        /// </summary>
        /// <typeparam name="TOutput">The type of the result value.</typeparam>
        /// <param name="func">The asynchronous function to execute.</param>
        /// <returns>A task representing the result returned by the function.</returns>
        public static async Task<Result<TOutput>> OfAsync<TOutput>(Func<Task<Result<TOutput>>> func) => await func().ConfigureAwait(false);

    }

}
