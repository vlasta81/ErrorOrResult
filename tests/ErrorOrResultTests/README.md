# ErrorOrResult - Tests

This project contains a comprehensive test suite for the ErrorOrResult library using xUnit.

> **Note**: This test suite covers through version **1.1.0** (security hardening of `Try`/`TryAsync`/`ToResultAsync`, internal `Result<T>` layout optimization, and the new severity-based error comparer). For the prior v1.0.2 API refactor that moved functional methods to instance methods, see [Migration Guide](../../CHANGELOG.md#migration-guide).

## Test Coverage

### ErrorTests.cs
- Creating different error types (Failure, Unexpected, Validation, Conflict, NotFound, Unauthorized, Forbidden, BadRequest)
- Custom errors using `Error.Custom`
- NumericType mapping to HTTP status codes
- Error deconstruction and equality
- **`WithDescription()`** - Instance method for creating modified error copies (v1.0.2+)

### ErrorInfoTests.cs
- Initialization with single error, error array, error list
- Input validation (null, empty collections)
- Access to first error and all errors
- ErrorInfo instance equality
- `default(ErrorInfo)` behavior (`Count`, `AllErrors`, `FirstError`, `ToString`)
- Single-error and multi-error `ToString` formatting

### ResultTests.cs
- Creating successful and failed results
- Implicit conversions from value, error, and ErrorInfo
- Access to value and errors
- `GetValueOrDefault` and `GetValueOrThrow` methods
- ToString representation
- Static factory methods from `Result` class
- `default(Result<T>)` state + throwing behavior of `Map` / `Bind` / `Match` / `Switch` / `Combine` on uninitialized results
- `Result.Try` / `Result.TryAsync` success, exception capture, and `OperationCanceledException` re-throw
- **`Result.TryAsync(..., exceptionMapper)` — opt-in mapper overload (v1.1.0+)**
- `Result.Create` / `Result.Ensure` / `Result.Of` / `Result.OfAsync`

### ResultExtensionsTests.cs
- **Instance Methods** (called directly on `Result<T>`):
  - `Map` - value transformation
  - `Bind` - operation chaining (note: signature changed in v1.0.2, now `Bind<TResult>(...)` instead of `Bind<TInput, TOutput>(...)`)
  - `Match` - pattern matching
  - `Switch` - action execution based on state
  - `Tap` / `TapError` - side effects without changing result
  - `ThrowOnError` - throwing exception on error
- **Async Extension Methods** (called on `Task<Result<T>>`):
  - `MapAsync`, `BindAsync`, `MatchAsync`, `TapAsync`, `ThrowOnErrorAsync`

### ResultAdvancedExtensionsTests.cs
- **Instance Methods** (called directly on `Result<T>`):
  - `Ensure` - validation with predicate
  - `MapError` - error transformation
  - `Combine<TOther>` - combining with another result into tuple (moved from extension to instance method in v1.0.2)
- Chaining multiple operations together using instance methods

### ResultLinqExtensionsTests.cs
- LINQ query syntax support (`select`, `from`)
- `SelectMany` for operation chaining
- Complex LINQ queries with multiple clauses
- Combining LINQ with other methods

### ResultHttpExtensionsTests.cs *(added in v1.0.4)*
- `ToHttpResult<TOutput>` — success (200 OK), custom handler, all `ErrorType` variants (400–520)
- `ToHttpResult(Result<None>)` — 204 No Content on success, Problem Details on error
- `ToHttpResultAsync` — async success and error paths
- `ToProblem` — per-type status codes, multi-error `extensions["errors"]` field, single-error without extension
- `ToValidationProblem` — error grouping by code, descriptions per group
- `ToOk`, `ToCreated`, `ToCreatedAtRoute`, `ToAccepted`, `ToNoContent` — success values and error throws
- `MatchHttp` / `MatchHttpAsync` — success branch, default error handler, custom error handler

### TaskExtensionsTests.cs
- `ToResultAsync` for Task<T>
- `ToResultAsync` for nullable reference types
- `ToResultAsync` for nullable value types
- Exception handling in asynchronous operations (asserts the **secure default** — exception message is not leaked, v1.1.0+)

### NoneTests.cs
- Using `None` as generic parameter
- `None` for operations without return value
- Chaining operations with `None`

### AnalysisRegressionTests.cs *(added in v1.1.0)*

Regression tests covering fixes and additions from the library code analysis:

- **Argument validation**:
  - `Failure(default(ErrorInfo))` throws `ArgumentException`
  - `Failure((Error[])null)` / `Failure((List<Error>)null)` throw `ArgumentNullException`
  - `MapError(null)` throws `ArgumentNullException`
  - `ErrorInfo(Array.Empty<Error>())` / `ErrorInfo(new List<Error>())` throw `ArgumentException`
- **`ToString` formatting**:
  - Failed `Result<T>.ToString()` renders inner `ErrorInfo` (regression guard — no more `ErrorOrResult.ErrorInfo` leak from `Nullable<T>.ToString()`)
  - `ErrorInfo.ToString()` with multiple errors lists all codes
- **Caching contract**:
  - `Result.Success()` reuses the cached `Result<None>` instance
- **Default state**:
  - `default(ErrorInfo).FirstError` throws; `Count == 0`; `AllErrors` empty
- **`Combine` ordering**:
  - Two errors: left-first ordering preserved (documented contract)
  - One error each: `FirstError.Type` reflects the left operand
  - **With `ErrorComparers.BySeverityDescending`**: validation placed before not-found regardless of operand order
  - **With `null` comparer**: operand order preserved (backward compatibility)
- **`ErrorComparers.BySeverityDescending`**:
  - Ranks all 8 `ErrorType` values in the documented order
    (Validation > BadRequest > Conflict > Unauthorized > Forbidden > NotFound > Failure > Unexpected)

## Running Tests

```bash
dotnet test
```

With code coverage (Cobertura):

```bash
dotnet tool install -g dotnet-coverage
dotnet-coverage collect -f cobertura -o coverage.cobertura.xml dotnet test
```

## API Changes in v1.1.0

### Security (behavioural)

`Result.Try` / `Result.TryAsync` / `Task<T>.ToResultAsync` no longer include the captured `Exception.Message` in the returned `Error.Description` by default — it could leak internal paths, PII, or stack hints into HTTP responses. The default description is now a fixed `"An exception was thrown during execution."` string with code `"Exception.Caught"`.

For diagnostics, use the new opt-in mapper overloads:

```csharp
// Synchronous
var r1 = Result.Try(() => Risky(), ex => Error.Failure("Risky.Failed", ex.GetType().Name));

// Asynchronous
var r2 = await Result.TryAsync(() => RiskyAsync(), ex => Error.Failure("Risky.Failed", "…"));

// Task<T>.ToResultAsync
var r3 = await LoadAsync().ToResultAsync(ex => Error.Failure("Load.Failed", "…"));
```

Test suite was updated accordingly — exception-capture tests now assert that the exception message is **not** present in the default result (`Assert.DoesNotContain("oops", …)`), plus new tests verify the mapper overloads propagate the caller-supplied `Error`.

### Additions

- `Result<T>.Combine<TOther>(Result<TOther>, IComparer<Error>?)` — new overload that stable-sorts merged errors using the supplied comparer. Pass `null` for the default left-first behaviour.
- `ErrorComparers.BySeverityDescending` — built-in `IComparer<Error>` that orders errors by client-actionability (Validation=100 … Unexpected=10).

### Internal (no public API change)

- `Result<T>` struct layout reduced by ~50 % (plain `ErrorInfo` field instead of `Nullable<ErrorInfo>`). All tests pass unchanged.

## API Changes in v1.0.2

### Methods Moved to Instance Methods

The following methods were moved from extension classes to instance methods on `Result<TOutput>`:

| Method | Previous Location | New Location | Notes |
|--------|------------------|--------------|-------|
| `Map<TResult>` | `ResultExtensions` | `Result<T>` | Same call syntax |
| `Bind<TResult>` | `ResultExtensions` | `Result<T>` | Signature: `Bind<TResult>(...)` instead of `Bind<TInput, TOutput>(...)` |
| `Match<TResult>` | `ResultExtensions` | `Result<T>` | Same call syntax |
| `Tap`, `TapError` | `ResultExtensions` | `Result<T>` | Same call syntax |
| `Ensure` | `ResultExtensions` | `Result<T>` | Same call syntax |
| `MapError` | `ResultExtensions` | `Result<T>` | Same call syntax |
| `Switch` | `ResultExtensions` | `Result<T>` | Same call syntax |
| `ThrowOnError` | `ResultExtensions` | `Result<T>` | Same call syntax |
| `Combine<TOther>` | `ResultExtensions` | `Result<T>` | Now called as `result1.Combine(result2)` |

### Methods Remaining as Extension Methods

| Method | Location | Reason |
|--------|----------|--------|
| `MapAsync`, `BindAsync`, etc. | `ResultExtensions` | Operate on `Task<Result<T>>`, following .NET async pattern |
| `Select`, `SelectMany` | `ResultLinqExtensions` | Required for LINQ query syntax support |
| `ToHttpResult`, `ToProblem`, etc. | `ResultHttpExtensions` | ASP.NET Core specific functionality |
| `ToResultAsync` | `TaskExtensions` | Converts `Task<T>` to `Result<T>` |

### Error Struct Changes

| Method | Previous Location | New Location |
|--------|------------------|--------------|
| `WithDescription` | `ErrorExtensions` | `Error` | Instance method for immutable error modification |

## Statistics

- **Total Tests**: 210
- **Passed**: 210
- **Failed**: 0
- **Skipped**: 0

### Growth by version

| Version | Total | Added |
|---------|-------|-------|
| v1.0.2  | 122   | +2 (`Error.WithDescription`) |
| v1.0.4  | 196   | +74 (HTTP extensions, uninitialized-state guards, `Result.Try`, `ErrorInfo` defaults) |
| v1.1.0  | 210   | +14 (analysis regression suite: security mapper overload, severity comparer, `Combine` ordering contract, `ToString` regression guard, null-argument guards) |

## Technologies

- **.NET 10.0**
- **xUnit 2.9.3**
- **Microsoft.NET.Test.Sdk 17.14.1**

