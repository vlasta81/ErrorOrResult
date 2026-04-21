# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Quick Navigation

- [Latest: v1.1.0](#110---2026-04-10) – Security hardening, layout optimization, severity comparer
- [Previous: v1.0.4](#104---2026-04-10) – Bug Fixes, Performance & Tests
- [v1.0.3](#103---2026-04-07) – Bug Fixes & Performance Optimizations
- [v1.0.2](#102---2026-03-29) – Major refactoring: instance methods
- [Migration Guide](#migration-guide) – Upgrading from v1.0.1
- [Oldest: v1.0.1](#101---previous-release) – Initial stable release

---

## [1.1.0] - 2026-04-10

### Security

- **`Try` / `TryAsync` / `ToResultAsync` no longer expose `Exception.Message` by default.** Previously the captured exception message became part of the returned `Error.Description`, which could leak internal paths, PII, database schema hints or stack context into error responses (especially when mapped through `ToProblem()` to an HTTP body). The default description is now a fixed, non-sensitive string: `"An exception was thrown during execution."` and the code is `"Exception.Caught"`.
- For diagnostics, a new opt-in overload accepts a caller-supplied `Func<Exception, Error>` mapper:
  - `Result.Try<T>(Func<T>, Func<Exception, Error> exceptionMapper)`
  - `Result.TryAsync<T>(Func<Task<T>>, Func<Exception, Error> exceptionMapper)`
  - `Task<T>.ToResultAsync(Func<Exception, Error> exceptionMapper)` (on `TaskExtensions`)
- `OperationCanceledException` continues to be re-thrown and is never captured.

### Added

- **`ErrorComparers.BySeverityDescending`** — new public `IComparer<Error>` that orders errors by client-actionability (Validation=100, BadRequest=90, Conflict=80, Unauthorized=70, Forbidden=60, NotFound=50, Failure=20, Unexpected=10). Descending rank ensures the most actionable error comes first — which in turn drives the HTTP status returned by `ToProblem()`.
- **`Result<T>.Combine<TOther>(Result<TOther> other, IComparer<Error>? errorComparer)`** — new overload that stable-sorts merged errors using the supplied comparer. When `errorComparer` is `null`, behaviour is identical to the existing `Combine(other)` (left-first ordering preserved, non-breaking).
- Opt-in exception-mapping overloads for `Try`, `TryAsync`, and `Task<T>.ToResultAsync` (see **Security** above).
- Internal `ErrorInfo.FromImmutable(ImmutableArray<Error>)` factory that wraps a pre-built array without re-validation or copying — used by `MapError` and both `Combine` overloads to avoid extra allocations.

### Changed

- **`Combine` public contract is now explicitly documented** (XML `<remarks>`): errors are concatenated left-first, and `FirstError.Type` determines the HTTP status code when converted via `ToProblem()`. No behavioural change; use the new `IComparer<Error>` overload to reorder.
- **`Error[]` / `List<Error>` static `Failure` factories now throw `ArgumentNullException` on null input** instead of `NullReferenceException` from the underlying `ErrorInfo` constructor.
- **`Result.Failure(ErrorInfo)` now throws `ArgumentException` when given `default(ErrorInfo)`** (`Count == 0`) instead of silently producing a "successful-but-error" inconsistent state.
- **`MapError(null)` now throws `ArgumentNullException`** (previously `NullReferenceException`).

### Fixed

- **`Result<T>.ToString()` on a failed result** now renders the actual `ErrorInfo` contents (`"Failure: [Code] Description ..."`) instead of the type name (`"Failure: ErrorOrResult.ErrorInfo"`) that leaked from the underlying `Nullable<ErrorInfo>.ToString()`.

### Performance

- **`Result<T>` struct layout reduced by ~50%** (e.g. `Result<int>` from 32 B → 16 B on 64-bit). The internal `Nullable<ErrorInfo>` wrapper was replaced with a plain `ErrorInfo` field; error-state detection now uses `_errorInfo.Count > 0`. Eliminates per-access `Nullable<T>.Value` copies in hot paths (`Map`, `Bind`, `Match`, `Combine`, `TapError`, `MapError`, `Switch`, `ThrowOnError`, `ErrorInfo` getter). **Public API is unchanged** — consumers need no code changes.
- **`MapError` and `Combine` now use `ImmutableArray.CreateBuilder(capacity) + MoveToImmutable()`** instead of intermediate arrays, avoiding one redundant copy per call.
- **`ToProblem()` / `ToValidationProblem()` (HTTP extensions) are now LINQ-free**, using direct `switch` on `FirstError.Type` and a plain `Dictionary<string, List<string>>` for grouping — removes ~3 LINQ allocations per HTTP response.
- **`Result.Success()` (the `Result<None>` overload)** now returns a cached static instance instead of constructing a new struct on each call.
- `ErrorInfo.ToString()` is now LINQ/StringBuilder-free for the single-error case and uses `string.Create` for multi-error formatting.

### Tests

- Added 14 regression tests in `AnalysisRegressionTests.cs` covering:
  - `default(ErrorInfo)` rejection in `Failure(ErrorInfo)`
  - Null-argument throws for array / list / mapper parameters
  - `ToString` regression guard (no more `ErrorOrResult.ErrorInfo` leak)
  - `Result.Success()` caching contract
  - `Combine` left-first ordering (regression guard)
  - `Combine` with severity comparer: validation placed before not-found regardless of operand order
  - `Combine` with `null` comparer preserves operand order
  - `ErrorComparers.BySeverityDescending` ranks all 8 `ErrorType` values correctly
  - `ErrorInfo` default/empty-span/empty-list validation
  - `ErrorInfo.ToString` with multiple errors
- Added `Result_TryAsync_WithExceptionMapper_ShouldUseMapperResult` and sibling sync tests for the new mapper overloads.
- Updated existing exception-capture tests to assert the secure default (mass `DoesNotContain("oops")`) rather than leaking the exception message.
- **Total test count: 210** (was 196) — all passing.

### Documentation

- Added full XML docs to `ErrorComparers`, `BySeverityDescending`, and both `Combine` overloads (including severity rank table in `<remarks>`).
- Documented the security rationale for the new exception-mapping overloads.
- README: new **"Combining Results"** and **"Exception Capture"** sections; `What's New` banner updated to v1.1.0; API Design Notes now list the new overloads.

### Migration

`v1.1.0` is a **minor, non-breaking release** for typical consumers:

- ✅ All existing public APIs preserve their signatures and behaviour.
- ✅ The internal `Result<T>` layout change is invisible to callers (public `Value`, `ErrorInfo`, `IsSuccess`, `IsError` are unchanged).
- ✅ The new `Combine(other, IComparer<Error>?)` overload is additive.
- ⚠️ **Behavioural tightening**: if your code relied on `Result.Try(...)` putting `ex.Message` into `Error.Description`, you must switch to the new mapper overload:
  ```csharp
  // Before (v1.0.x) — description was ex.Message
  var r = Result.Try(() => Risky());

  // After (v1.1.0) — default description is generic; use mapper for details
  var r = Result.Try(() => Risky(), ex => Error.Failure("Risky.Failed", ex.Message));
  ```
- ⚠️ `Result.Failure(default(ErrorInfo))` now throws `ArgumentException` instead of returning a broken result. If any code path produced this, it was already a latent bug.
- ⚠️ Passing `null` to the `Error[]` / `List<Error>` `Failure` overloads or to `MapError` now throws `ArgumentNullException` instead of `NullReferenceException`.

---

## [1.0.4] - 2026-04-10

### Fixed

- **Bug**: `Match` and `Switch` on an uninitialized `default(Result<T>)` now throw a clear `InvalidOperationException("Cannot match/switch uninitialized Result!")` instead of propagating an opaque `Nullable object must have a value` error from internal state access.
- **Bug**: `Combine` on a `default(Result<T>)` instance or when the `other` argument is `default` now throws a clear `InvalidOperationException("Cannot combine uninitialized Result!")` instead of producing an `ArgumentException` from inside `ErrorInfo` with no useful context.
- **Bug**: `ToValidationProblem()` (HTTP extension) was calling `Results.ValidationProblem()` without a `statusCode`, which defaults to HTTP 400 in ASP.NET Core — inconsistent with `ErrorType.Validation` mapping to 422. Fixed by explicitly passing `statusCode: 422`.
- **Bug**: `TapAsync` in `ResultExtensions` was missing `.ConfigureAwait(false)` on the user-supplied async action, which could cause deadlocks in synchronization-context environments (e.g. WinForms, classic ASP.NET).
- **Bug**: Duplicate `<PackageLicenseExpression>MIT</PackageLicenseExpression>` entry removed from `ErrorOrResult.csproj`.

### Optimized

- `MapError` for multi-error results no longer allocates an intermediate `Error[]` array. The mapper is now applied via `ImmutableArray.CreateRange(source, mapper)` and the result is passed directly as `ReadOnlySpan<Error>` to the `ErrorInfo` constructor, saving one GC allocation per call.

### Tests

- **New file `ResultHttpExtensionsTests.cs`**: Added ~35 unit tests covering the previously untested `ResultHttpExtensions` class:
  - `ToHttpResult<TOutput>` — success (200 OK), custom handler, all `ErrorType` variants (400–520)
  - `ToHttpResult(Result<None>)` — 204 No Content on success, Problem Details on error
  - `ToHttpResultAsync` — async success and error paths
  - `ToProblem` — per-type status codes, multi-error `extensions["errors"]` field, single-error without extension
  - `ToValidationProblem` — error grouping by code, descriptions per group
  - `ToOk`, `ToCreated`, `ToCreatedAtRoute`, `ToAccepted`, `ToNoContent` — success values and error throws
  - `MatchHttp` / `MatchHttpAsync` — success branch, default error handler, custom error handler
- **`ResultTests.cs`**: Added ~25 unit tests for previously uncovered `Result<T>` scenarios:
  - `default(Result<T>)` state (`IsSuccess`, `IsError`, `ToString`)
  - `default` + `Map`, `Bind`, `Match`, `Switch` — all throw `InvalidOperationException`
  - `Combine` with uninitialized `this` or `other` — throws `InvalidOperationException`
  - `Result.Try<T>` — success, exception capture, `OperationCanceledException` re-throw
  - `Result.TryAsync<T>` — async variants of the above
  - `Result.Create<T>` (class and struct) — null/non-null paths, custom error
  - `Result.Ensure<T>` (static) — predicate pass and fail
  - `Result.Of<T>` / `Result.OfAsync<T>` — success and error delegation
- **`ErrorInfoTests.cs`**: Added ~6 unit tests:
  - `ToString()` — single-error and multi-error format
  - `default(ErrorInfo)` — `Count=0`, `AllErrors` empty, `FirstError` throws, `ToString` returns "No errors"
  - Empty `ReadOnlySpan<Error>` and empty `List<Error>` constructors throw `ArgumentException`

### Documentation

- Added `<exception cref="InvalidOperationException">` XML doc to `Match` and `Switch` for the uninitialized-result case.
- Updated README `What's New` banner to v1.0.4.
- Corrected README ASP.NET Core example from MVC `IActionResult`/`ControllerBase` to Minimal API `IResult`/`Results.*` (the original example would not compile since `ToHttpResult()` returns `IResult`, not `IActionResult`).
- Expanded README API Design Notes: documented all instance methods (`Tap`, `TapError`, `Switch`, `ThrowOnError`, `GetValueOrDefault`, `GetValueOrThrow`), all static factory methods (`Try`, `TryAsync`, `Create`, `Ensure`, `Of`, `OfAsync`, `Success()` no-value overload), and all HTTP extension methods (`ToOk`, `ToCreated`, `ToCreatedAtRoute`, `ToAccepted`, `ToNoContent`, `MatchHttp`, `MatchHttpAsync`, `ToProblem`, `ToValidationProblem`).

---

## [1.0.3] - 2026-04-07

### Fixed

- **Critical Bug**: Fixed an issue where `Result<T>.IsSuccess` would improperly return `false` on success states carrying a valid `null` value for nullable generic outputs. Added internal `_isSuccess` tracking.
- Protected `ErrorInfo` struct methods (`Count`, `FirstError`, `ToString()`) from throwing `NullReferenceException` when triggered against a `default(ErrorInfo)` state.
- Prevented wrapping `OperationCanceledException` into `Error.Unexpected` block in `TaskExtensions`, releasing standard async cancellation execution flows.

### Optimized

- Reduced internal object memory allocations. `ErrorInfo` object constructors no longer redundantly cycle through `.ToArray()` when handling `ReadOnlySpan<Error>` or generic configurations, directly utilizing optimized `ImmutableArray`.

## [1.0.2] - 2026-03-29

### Changed

- **Breaking**: Moved core functional methods from extension classes to instance methods on `Result<TOutput>` struct for better discoverability and IntelliSense support:
  - `Map<TResult>(...)`, `Bind<TResult>(...)`, `Match<TResult>(...)`, `Tap(...)`, `TapError(...)`, `Ensure(...)`, `MapError(...)`, `Switch(...)`, `ThrowOnError()`, `Combine<TOther>(...)`
- **Breaking**: Moved `Error.WithDescription(...)` from `ErrorExtensions` to `Error` record struct as an instance method
- Renamed `ResultExtensions` class to focus only on async extension methods for `Task<Result<T>>`
- Updated XML documentation comments throughout the codebase for clarity and consistency
- **Test Updates**: Updated test files to reflect new method signatures (reduced explicit generic type parameters where type inference handles them)

### Added

- New section in README.md: "API Design Notes" explaining the hybrid approach of instance vs extension methods
- Clear documentation distinguishing between:
  - Instance methods for synchronous `Result<T>` operations
  - Extension methods for async `Task<Result<T>>` operations and special cases (LINQ, HTTP, Task conversion)

### Removed

- `ErrorExtensions.cs` file (functionality moved to `Error` struct)
- Redundant synchronous extension methods from `ResultExtensions.cs` (moved to `Result<TOutput>` struct)

### Added (Tests)

- New test cases for `Error.WithDescription()` instance method in `ErrorTests.cs`
- Verification that all existing tests pass with refactored method locations

### Fixed

- Improved generic type parameter naming in `Result<TOutput>` instance methods (`TResult` instead of reusing `TOutput`)
- Updated README.md examples to reflect new API usage patterns

### Migration Guide

If you're upgrading from 1.0.1:

**Before (v1.0.1):**
```csharp
// Using extension methods
var result = GetUser(1)
    .Map(user => user.Email)  // Extension method
    .Bind(email => SendEmail(email))  // Extension method
    .Combine(GetEmailTemplate(1));  // Extension method

var error = someError.WithDescription("New description");  // Extension method
```

**After (v1.0.2):**
```csharp
// Using instance methods (same syntax, better discoverability)
var result = GetUser(1)
    .Map(user => user.Email)  // Instance method on Result<T>
    .Bind(email => SendEmail(email))  // Instance method on Result<T>
    .Combine(GetEmailTemplate(1));  // Instance method on Result<T>

var error = someError.WithDescription("New description");  // Instance method on Error
```

*Note: The calling syntax remains the same, but methods are now discovered as instance methods rather than extension methods. This provides better IntelliSense support and clearer API documentation.*

**Async operations remain unchanged** (cannot be instance methods because they operate on `Task<Result<T>>`, not `Result<T>` itself - following standard .NET pattern like LINQ's `ToListAsync()`):
```csharp
// Async extension methods still work the same way
var result = await GetUserAsync(1)
    .MapAsync(user => user.Email)  // Extension method for Task<Result<T>>
    .BindAsync(email => SendEmailAsync(email));
```

## [1.0.1] - Previous Release

- Initial stable release with Result pattern implementation
- Support for single and multiple errors via `ErrorInfo`
- ASP.NET Core HTTP response integration
- LINQ query syntax support
- Full async/await support

---

> **Adding New Entries**: When adding future changelog entries, follow the [Keep a Changelog](https://keepachangelog.com/) format and place new versions at the top of this file under the "Unreleased" or next version section.
