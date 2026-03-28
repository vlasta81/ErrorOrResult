# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Quick Navigation

- [Latest: v1.0.2](#102---2026-03-29) – Major refactoring: instance methods
- [Migration Guide](#migration-guide) – Upgrading from v1.0.1
- [Previous: v1.0.1](#101---previous-release) – Initial stable release

---

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
