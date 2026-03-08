# ErrorOrResult - Tests

[CZECH](https://github.com/vlasta81/ErrorOrResult/README_CZ.md)

This project contains a comprehensive test suite for the ErrorOrResult library using xUnit.

## Test Coverage

### ErrorTests.cs
- Creating different error types (Failure, Unexpected, Validation, Conflict, NotFound, Unauthorized, Forbidden, BadRequest)
- Custom errors using `Error.Custom`
- NumericType mapping to HTTP status codes
- Error deconstruction and equality

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
- `Map` - value transformation
- `Bind` - operation chaining
- `Match` - pattern matching
- `Switch` - action execution based on state
- `Tap` / `TapError` - side effects without changing result
- `ThrowOnError` - throwing exception on error
- Asynchronous variants of all methods

### ResultAdvancedExtensionsTests.cs
- `Ensure` - validation with predicate
- `MapError` - error transformation
- `Combine` - combining multiple results
- Chaining multiple operations together

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

## Statistics

- **Total Tests**: 120
- **Passed**: 120
- **Failed**: 0
- **Skipped**: 0

## Technologies

- **.NET 10.0**
- **xUnit 2.9.3**
- **Microsoft.NET.Test.Sdk 17.14.1**
