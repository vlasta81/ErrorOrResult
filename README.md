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
var errorResult = Result<int>.Error(
    Error.NotFound("User.NotFound", "User not found")
);

// Error result with multiple errors
var multiErrorResult = Result<User>.Error(
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
    onError: errors => $"Failed: {errors.FirstError.Description}"
);
```

### Chaining Operations

```csharp
var result = GetUser(userId)
    .Map(user => user.Email)
    .Map(email => email.ToLower())
    .Bind(email => SendNotification(email));
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

Convert results directly to HTTP responses:

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
        return result.ToActionResult(user => Ok(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var result = await _userService.CreateUserAsync(request);
        return result.ToActionResult(user => CreatedAtAction(
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

// Map async
var emailResult = await GetUserAsync(id)
    .MapAsync(user => user.Email);

// Bind async
var result = await GetUserAsync(id)
    .BindAsync(user => SendEmailAsync(user.Email));
```

### LINQ-Style Queries

```csharp
var results = new[]
{
    Result<int>.Success(1),
    Result<int>.Error(Error.NotFound()),
    Result<int>.Success(3)
};

// Get only successful results
var successfulValues = results.SuccessValues(); // [1, 3]

// Get only errors
var errors = results.Errors(); // [Error.NotFound()]
```

### Error Info Builder

Build complex error information:

```csharp
var errorInfo = ErrorInfo.Builder()
    .Add(Error.Validation("Name", "Name is required"))
    .Add(Error.Validation("Email", "Email is invalid"))
    .Build();

var result = Result<User>.Error(errorInfo);
```

## Requirements

- .NET 10.0 or higher
- C# 12.0 or higher (for record structs and nullable reference types)

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Author

**vlasta81**

## Support

If you encounter any issues or have questions, please file an issue on the [GitHub repository](https://github.com/vlasta81/ErrorOrResult/issues).
