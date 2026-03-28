# ErrorOrResult

[CZECH](https://github.com/vlasta81/ErrorOrResult/blob/master/README_CZ.md)

[![NuGet](https://img.shields.io/nuget/v/ErrorOrResult.svg)](https://www.nuget.org/packages/ErrorOrResult/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A lightweight, functional .NET library for handling operation results with explicit success and error states. Inspired by the Result pattern, this library helps you write more robust and maintainable code by making error handling explicit and type-safe.

## Features

- ✨ **Type-Safe Error Handling** - Explicit success and error states with compile-time safety
- 🔗 **Fluent API** - Chainable operations with `Map`, `Bind`, and `Match` methods
- 🌐 **HTTP Integration** - Built-in extensions for ASP.NET Core with automatic HTTP status code mapping
- 📝 **Multiple Error Support** - Handle single or multiple errors in a single result
- 🎯 **Rich Error Types** - Pre-defined error types mapped to HTTP status codes (400, 401, 403, 404, 409, 422, 500, 520)
- ⚡ **Async Support** - Full support for async/await patterns with `Task<Result<T>>` extensions
- 🔍 **LINQ Integration** - Query and filter results using familiar LINQ-style syntax

## Documentation

[Documentation](https://github.com/vlasta81/ErrorOrResult/blob/master/docs/api-generated/index.md)

> **Note**: API documentation is auto-generated using [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation). After making code changes, run `GenerateDefaultDocumentation.bat` to update the documentation files in the `docs/api-generated` folder.

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package ErrorOrResult
```

Or via Package Manager Console:

```powershell
Install-Package ErrorOrResult
```

## Quick Start

### Creating Results

```csharp
using ErrorOrResult;

// Success result
var successResult = Result<int>.Success(42);

// Error result with single error
var errorResult = Result<int>.Failure(
    Error.NotFound("User.NotFound", "User not found")
);

// Error result with multiple errors
var multiErrorResult = Result<User>.Failure(
    Error.Validation("User.Name", "Name is required"),
    Error.Validation("User.Email", "Email is invalid")
);
```

### Checking Results

```csharp
if (result.IsSuccess)
{
    Console.WriteLine($"Value: {result.Value}");
}
else
{
    Console.WriteLine($"Error: {result.Error.Description}");
}
```

### Pattern Matching

```csharp
var message = result.Match(
    onSuccess: value => $"Success: {value}",
    onFailure: errors => $"Failed: {errors.FirstError.Description}"
);
```

### Chaining Operations

```csharp
var result = GetUser(userId)
    .Map(user => user.Email)           // Instance method - maps success value
    .Map(email => email.ToLower())
    .Bind(email => SendNotification(email));  // Instance method - chains result-returning operations
```

## Error Types

The library provides pre-defined error types mapped to HTTP status codes:

| Error Type | HTTP Status | Description |
|------------|-------------|-------------|
| `BadRequest` | 400 | Invalid request parameters |
| `Unauthorized` | 401 | Authentication required |
| `Forbidden` | 403 | Access denied |
| `NotFound` | 404 | Resource not found |
| `Conflict` | 409 | Resource conflict |
| `Validation` | 422 | Validation errors |
| `Failure` | 500 | General failure |
| `Unexpected` | 520 | Unexpected error |

### Creating Errors

```csharp
// Pre-defined error factory methods
var notFoundError = Error.NotFound("Product.NotFound", "Product with ID 123 not found");
var validationError = Error.Validation("Email.Invalid", "Email format is invalid");
var unauthorizedError = Error.Unauthorized("Auth.Required", "Authentication required");

// Custom error with specific type
var customError = new Error("Custom.Code", "Custom description", ErrorType.Conflict);
```

## ASP.NET Core Integration

Convert results directly to HTTP responses using extension methods:

```csharp
using ErrorOrResult;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        // Use ToHttpResult extension method for automatic HTTP response conversion
        return result.ToHttpResult(user => Ok(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var result = await _userService.CreateUserAsync(request);
        return result.ToHttpResult(user => CreatedAtAction(
            nameof(GetUser), 
            new { id = user.Id }, 
            user
        ));
    }
}
```

## Advanced Usage

### Async Operations

```csharp
Task<Result<User>> GetUserAsync(int id);

// MapAsync - extension method for Task<Result<T>>
var emailResult = await GetUserAsync(id)
    .MapAsync(user => user.Email);

// BindAsync - extension method for Task<Result<T>>
var result = await GetUserAsync(id)
    .BindAsync(user => SendEmailAsync(user.Email));

// Note: For synchronous Result<T> operations, use instance methods:
// result.Map(...), result.Bind(...), result.Match(...), etc.
```

### LINQ Query Syntax

```csharp
// Using LINQ query syntax with results
var result = from user in GetUser(userId)
             from email in ValidateEmail(user.Email)
             select email.ToLower();

// Chaining multiple operations
var processedResult = 
    from user in GetUser(userId)
    from validation in ValidateUser(user)
    from saved in SaveUser(user)
    select saved;
```

### Multiple Errors

Create results with multiple errors:

```csharp
// Using array of errors
var errors = new[]
{
    Error.Validation("Name", "Name is required"),
    Error.Validation("Email", "Email is invalid")
};

var result = Result<User>.Failure(errors);

// Or using ErrorInfo directly
var errorInfo = new ErrorInfo(new[]
{
    Error.Validation("Name", "Name is required"),
    Error.Validation("Email", "Email is invalid")
});

var result = Result<User>.Failure(errorInfo);
```

## Requirements

- .NET 10.0 or higher
- C# 12.0 or higher (for record structs and nullable reference types)

## API Design Notes

### Instance Methods vs Extension Methods

This library uses a hybrid approach for method organization:

**Instance Methods** (called directly on `Result<T>`):
- `Map<TResult>(...)` - Transform success value
- `Bind<TResult>(...)` - Chain result-returning operations  
- `Match<TResult>(...)` - Pattern matching on result state
- `Tap(...)`, `TapError(...)` - Execute side effects
- `Ensure(...)` - Validate with predicate
- `MapError(...)` - Transform errors
- `Switch(...)` - Execute actions based on state
- `ThrowOnError()` - Throw exception if error state
- `Combine<TOther>(Result<TOther>)` - Combine with another result into tuple
- `WithDescription(...)` - On `Error` struct, create modified copy

**Extension Methods** (for async operations and special cases):
- `MapAsync`, `BindAsync`, `MatchAsync`, `TapAsync`, `EnsureAsync`, `ThrowOnErrorAsync` - Async variants for `Task<Result<T>>` (cannot be instance methods because they operate on `Task<Result<T>>`, not `Result<T>` itself - following standard .NET pattern like LINQ's `ToListAsync()`)
- `ResultHttpExtensions.*` - ASP.NET Core HTTP response conversion
- `ResultLinqExtensions.*` - LINQ query syntax support (`Select`, `SelectMany`)
- `TaskExtensions.*` - Convert `Task<T>` to `Result<T>`

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Author

**vlasta81**

## Support

If you encounter any issues or have questions, please file an issue on the [GitHub repository](https://github.com/vlasta81/ErrorOrResult/issues).
