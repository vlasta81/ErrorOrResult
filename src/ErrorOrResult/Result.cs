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
        private readonly ErrorInfo? _errorInfo;

        private Result(TOutput? value, ErrorInfo? errorInfo)
        {
            _value = value;
            _errorInfo = errorInfo;
        }

        /// <summary>
        /// Gets a value indicating whether the result represents a successful operation.
        /// </summary>
        public bool IsSuccess => _errorInfo is null && _value is not null;

        /// <summary>
        /// Gets a value indicating whether the result represents a failed operation.
        /// </summary>
        public bool IsError => _errorInfo is not null;

        /// <summary>
        /// Gets the success value. Throws an exception if the result is in an error state.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when accessing value in error state.</exception>
        public TOutput Value => IsSuccess ? _value! : throw new InvalidOperationException($"Cannot access value when in error state: {_errorInfo}");

        /// <summary>
        /// Gets the error information. Throws an exception if the result is in a success state.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when accessing error info in success state.</exception>
        public ErrorInfo ErrorInfo => IsError ? _errorInfo!.Value : throw new InvalidOperationException("Cannot access error info when in success state");

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
        public static Result<TOutput> Success(TOutput value) => new Result<TOutput>(value, null);

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
            return new Result<TOutput>(default, new ErrorInfo(errors.ToArray()));
        }

        //public static Result<TOutput> Failure(Error error) => new Result<TOutput>(default, new ErrorInfo(error));
        //public static Result<TOutput> Failure(Error[] errors) => new Result<TOutput>(default, new ErrorInfo(errors));
        //public static Result<TOutput> Failure(List<Error> errors) => new Result<TOutput>(default, new ErrorInfo(errors));

        /// <summary>
        /// Creates a failed result with the specified error information.
        /// </summary>
        /// <param name="errorInfo">The error information.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
        public static Result<TOutput> Failure(ErrorInfo errorInfo) => new Result<TOutput>(default, errorInfo);

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
            return IsSuccess ? Result.Success(selector(_value!)) : Result.Failure<TResult>(_errorInfo!.Value);
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
            return IsSuccess ? binder(_value!) : Result.Failure<TResult>(_errorInfo!.Value);
        }

        /// <summary>
        /// Pattern matches on the result, executing one of two functions based on success or error state.
        /// </summary>
        /// <typeparam name="TResult">The type of the return value.</typeparam>
        /// <param name="onSuccess">The function to execute if the result is successful.</param>
        /// <param name="onFailure">The function to execute if the result is in error state.</param>
        /// <returns>The value returned by either onSuccess or onFailure.</returns>
        public TResult Match<TResult>(Func<TOutput, TResult> onSuccess, Func<ErrorInfo, TResult> onFailure) => IsSuccess ? onSuccess(_value!) : onFailure(_errorInfo!.Value);

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
                action(_errorInfo!.Value);
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
            if (!IsError)
            {
                return this;
            }
            ErrorInfo errorInfo = _errorInfo!.Value;
            if (errorInfo.Count == 1)
            {
                return Result.Failure<TOutput>(mapper(errorInfo.FirstError));
            }
            return Result.Failure<TOutput>(errorInfo.AllErrors.Select(mapper).ToArray());
        }

        /// <summary>
        /// Executes one of two actions based on whether the result is successful or in error state.
        /// Similar to Match but returns void.
        /// </summary>
        /// <param name="onSuccess">The action to execute if the result is successful.</param>
        /// <param name="onFailure">The action to execute if the result is in error state.</param>
        public void Switch(Action<TOutput> onSuccess, Action<ErrorInfo> onFailure)
        {
            if (IsSuccess)
            {
                onSuccess(_value!);
            }
            else
            {
                onFailure(_errorInfo!.Value);
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
                Error error = _errorInfo!.Value.FirstError;
                throw new InvalidOperationException($"Error: {error.Code} - {error.Description}");
            }
            return _value!;
        }

        /// <summary>
        /// Combines this result with another result into a single result containing a tuple of both values.
        /// If either result is in error state, all errors are combined.
        /// </summary>
        /// <typeparam name="TOther">The type of the other result value.</typeparam>
        /// <param name="other">The other result to combine with.</param>
        /// <returns>A result containing a tuple of both values if both are successful, otherwise a combined error result.</returns>
        public Result<(TOutput, TOther)> Combine<TOther>(Result<TOther> other)
        {
            if (IsSuccess && other.IsSuccess)
            {
                return Result.Success((_value!, other._value!));
            }
            var errors = ImmutableArray.CreateBuilder<Error>();
            if (IsError) errors.AddRange(_errorInfo!.Value.AllErrors);
            if (other.IsError) errors.AddRange(other._errorInfo!.Value.AllErrors);
            return Result.Failure<(TOutput, TOther)>(errors.ToArray());
        }
    }

    /// <summary>
    /// Provides static factory methods for creating <see cref="Result{TOutput}"/> instances.
    /// </summary>
    public static class Result
    {
        /// <summary>
        /// Creates a successful result with no value (using <see cref="None"/>).
        /// </summary>
        /// <returns>A successful result with no value.</returns>
        public static Result<None> Success() => Result<None>.Success(default(None));

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
        public static Result<TOutput> Failure<TOutput>(Error[] errors) => Result<TOutput>.Failure(errors);

        /// <summary>
        /// Creates a failed result with a list of errors.
        /// </summary>
        /// <typeparam name="TOutput">The type of the success value.</typeparam>
        /// <param name="errors">The errors that occurred.</param>
        /// <returns>A failed <see cref="Result{TOutput}"/>.</returns>
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
        public static Result<None> Failure(Error[] errors) => Result<None>.Failure(errors);

        /// <summary>
        /// Creates a failed result with no value and a list of errors.
        /// </summary>
        /// <param name="errors">The errors that occurred.</param>
        /// <returns>A failed result with no value.</returns>
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
            try
            {
                return Success(func());
            }
            catch (Exception ex)
            {
                return Failure<TOutput>(Error.Unexpected("Exception.Caught", ex.Message));
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
            try
            {
                return Success(await func().ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return Failure<TOutput>(Error.Unexpected("Exception.Caught", ex.Message));
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
