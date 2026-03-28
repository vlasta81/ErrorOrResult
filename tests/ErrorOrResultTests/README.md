# ErrorOrResult - Tests

This project contains a comprehensive test suite for the ErrorOrResult library using xUnit.

> **Note**: This test suite was updated for version 1.0.2 to reflect the refactoring that moved core functional methods from extension classes to instance methods on `Result<TOutput>` and `Error` structs. See [Migration Guide](../../CHANGELOG.md#migration-guide) for details.

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

### ResultTests.cs
- Creating successful and failed results
- Implicit conversions from value, error, and ErrorInfo
- Access to value and errors
- `GetValueOrDefault` and `GetValueOrThrow` methods
- ToString representation
- Static factory methods from `Result` class

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

### TaskExtensionsTests.cs
- `ToResultAsync` for Task<T>
- `ToResultAsync` for nullable reference types
- `ToResultAsync` for nullable value types
- Exception handling in asynchronous operations

### NoneTests.cs
- Using `None` as generic parameter
- `None` for operations without return value
- Chaining operations with `None`

## Running Tests

```bash
dotnet test
```

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

- **Total Tests**: 122 (added 2 new tests for `Error.WithDescription`)
- **Passed**: 122
- **Failed**: 0
- **Skipped**: 0

## Technologies

- **.NET 10.0**
- **xUnit 2.9.3**
- **Microsoft.NET.Test.Sdk 17.14.1**
