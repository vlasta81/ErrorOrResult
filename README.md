# ErrorOrResult

[![NuGet](https://img.shields.io/nuget/v/ErrorOrResult.svg)](https://www.nuget.org/packages/ErrorOrResult/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A lightweight, functional .NET library for handling operation results with explicit success and error states. Inspired by the Result pattern, this library helps you write more robust and maintainable code by making error handling explicit and type-safe.

> **✨ What's New in v1.1.0**: Security hardening of `Try`/`TryAsync`/`ToResultAsync` (exception messages no longer leaked by default — opt-in via new mapper overloads), internal `Result<T>` layout optimization (~50% smaller struct), new `Combine(other, IComparer<Error>?)` overload with built-in `ErrorComparers.BySeverityDescending`, stricter argument validation, `ToString` fix, LINQ-free HTTP mapping, and expanded regression tests. See [CHANGELOG.md](CHANGELOG.md) for details.

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

Convert results directly to HTTP responses using extension methods. `ToHttpResult()` returns `IResult` and is designed for **Minimal API** endpoints:

```csharp
using ErrorOrResult;

app.MapGet("/users/{id}", async (int id, IUserService userService) =>
{
    var result = await userService.GetUserByIdAsync(id);
    // Returns 200 OK with value on success, or Problem Details on error
    return result.ToHttpResult();
});

app.MapPost("/users", async (CreateUserRequest request, IUserService userService) =>
{
    var result = await userService.CreateUserAsync(request);
    // Custom success handler: returns 201 Created, errors produce Problem Details
    return result.ToHttpResult(user => Results.Created($"/users/{user.Id}", user));
});

app.MapDelete("/users/{id}", async (int id, IUserService userService) =>
{
    Result<None> result = await userService.DeleteUserAsync(id);
    // Result<None> success → 204 No Content
    return result.ToHttpResult();
});
```

### Typed HTTP results

For endpoints that need typed results (e.g. for OpenAPI schema inference):

```csharp
app.MapGet("/users/{id}", (int id, IUserService userService) =>
{
    var result = userService.GetUser(id);
    return result.ToOk();              // -> Ok<User> (200)
});

app.MapPost("/users", (CreateUserRequest req, IUserService svc) =>
{
    var result = svc.CreateUser(req);
    return result.ToCreated($"/users/{result.Value.Id}");  // -> Created<User> (201)
    // or: result.ToCreatedAtRoute("GetUser", new { id = result.Value.Id });
    // or: result.ToAccepted("/api/status/123");           // -> Accepted<User> (202)
    // or: result.ToNoContent();                           // -> NoContent (204), Result<None> only
});
```

### Pattern matching to HTTP responses

```csharp
app.MapGet("/users/{id}", async (int id, IUserService svc) =>
{
    return await svc.GetUserByIdAsync(id)
        .MatchHttpAsync(
            onSuccess: user => Results.Ok(user),
            onFailure: errors => Results.Problem(title: "Custom error", statusCode: 400));
});
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

## Combining Results

`Combine` merges two results into a tuple. If either fails, all errors are concatenated (left-first by default):

```csharp
Result<User> userResult = GetUser(id);
Result<Order> orderResult = GetOrder(id);

Result<(User, Order)> combined = userResult.Combine(orderResult);
// If both succeed: combined.Value = (user, order)
// If either (or both) fail: combined.ErrorInfo contains all errors, left-first
```

### Ordering combined errors by severity

Use the opt-in overload to reorder combined errors — useful when the first error drives the HTTP status via `ToProblem()`:

```csharp
// Most client-actionable first (Validation > BadRequest > Conflict > Unauthorized > Forbidden > NotFound > Failure > Unexpected)
Result<(User, Order)> combined = userResult.Combine(orderResult, ErrorComparers.BySeverityDescending);
return combined.ToProblem(); // HTTP status is derived from the highest-severity error

// Custom order: pass any IComparer<Error>
var byCode = Comparer<Error>.Create((a, b) => string.Compare(a.Code, b.Code, StringComparison.Ordinal));
var combined = userResult.Combine(orderResult, byCode);
```

Passing `null` keeps the default left-first ordering.

## Exception Capture (`Try` / `TryAsync` / `ToResultAsync`)

By default, captured exceptions are mapped to a generic `Error.Unexpected` — the exception `Message` is **intentionally not leaked** (avoids exposing internal details, stack hints or PII in error responses):

```csharp
Result<User> result = Result.Try(() => LoadUser(id));
// On failure: Error.Unexpected("Exception.Caught", "An exception was thrown during execution.")
```

For custom diagnostics, use the opt-in overload that accepts a mapper:

```csharp
Result<User> result = Result.Try(
    () => LoadUser(id),
    ex => ex switch
    {
        FileNotFoundException fnf => Error.NotFound("User.File.Missing", fnf.FileName ?? "unknown"),
        UnauthorizedAccessException      => Error.Forbidden("User.Access.Denied", "Access denied."),
        _                                 => Error.Failure("User.Load.Failed", "Could not load user."),
    });

// Async variant
Result<User> result = await Result.TryAsync(
    () => LoadUserAsync(id),
    ex => Error.Failure("User.Load", ex.GetType().Name));

// Task<T>.ToResultAsync also supports an exception mapper
Result<User> result = await LoadUserAsync(id).ToResultAsync(
    ex => Error.Failure("User.Load", "Load failed"));
```

`OperationCanceledException` is always re-thrown (never captured) so cooperative cancellation works as expected.

## Requirements

- .NET 10.0 or higher
- C# 12.0 or higher (for record structs and nullable reference types)

## API Design Notes

### Instance Methods vs Extension Methods

This library uses a hybrid approach for method organization:

**Instance Methods** (called directly on `Result<T>`):
- `Map<TResult>(Func<TOutput, TResult>)` - Transform success value
- `Bind<TResult>(Func<TOutput, Result<TResult>>)` - Chain result-returning operations  
- `Match<TResult>(onSuccess, onFailure)` - Pattern matching on result state; throws on uninitialized result
- `Tap(Action<TOutput>)` - Execute side effect on success, returns original result unchanged
- `TapError(Action<ErrorInfo>)` - Execute side effect on error, returns original result unchanged
- `Ensure(Func<TOutput, bool>, Error)` - Validate success value with predicate
- `MapError(Func<Error, Error>)` - Transform all errors in a failed result
- `Switch(Action<TOutput>, Action<ErrorInfo>)` - Execute actions based on state; throws on uninitialized result
- `ThrowOnError()` - Throw `InvalidOperationException` if in error state, otherwise return value
- `GetValueOrDefault(TOutput defaultValue)` - Return success value or the provided default
- `GetValueOrThrow()` - Return success value or throw `InvalidOperationException`
- `Combine<TOther>(Result<TOther>)` - Combine with another result into a `(TOutput, TOther)` tuple; combines all errors if either fails
- `WithDescription(string)` - On `Error` struct, create a copy with updated description

**Extension Methods** (for async operations and special cases):
- `MapAsync`, `BindAsync`, `MatchAsync`, `TapAsync`, `EnsureAsync`, `ThrowOnErrorAsync` - Async variants for `Task<Result<T>>` (cannot be instance methods because they operate on `Task<Result<T>>`, not `Result<T>` itself - following standard .NET pattern like LINQ's `ToListAsync()`)
- `ResultHttpExtensions.*` — ASP.NET Core Minimal API HTTP response conversion:
  - `ToHttpResult(onSuccess?)` → `IResult` (200 OK / Problem Details)
  - `ToHttpResultAsync(onSuccess?)` → `Task<IResult>`
  - `ToOk()` → `Ok<TOutput>` (200)
  - `ToCreated(uri)` → `Created<TOutput>` (201)
  - `ToCreatedAtRoute(routeName, routeValues?)` → `CreatedAtRoute<TOutput>` (201)
  - `ToAccepted(uri?)` → `Accepted<TOutput>` (202)
  - `ToNoContent()` → `NoContent` (204), only for `Result<None>`
  - `MatchHttp(onSuccess, onFailure?)` → `IResult`
  - `MatchHttpAsync(onSuccess, onFailure?)` → `Task<IResult>`
  - `ToProblem()` — on `ErrorInfo`, maps to RFC 7807 Problem Details
  - `ToValidationProblem()` — on `ErrorInfo`, maps to HTTP 422 with grouped errors
- `ResultLinqExtensions.*` - LINQ query syntax support (`Select`, `SelectMany`)
- `TaskExtensions.*` - Convert `Task<T>` to `Result<T>`

**Static Factory Methods** (on `Result` class):
- `Result.Success<TOutput>(value)` — creates a successful result
- `Result.Success()` — creates a successful `Result<None>` (no return value)
- `Result.Failure<TOutput>(Error|Error[]|List<Error>|ErrorInfo)` — creates a failed result
- `Result.Failure(Error|Error[]|List<Error>|ErrorInfo)` — creates a failed `Result<None>`
- `Result.Try<TOutput>(Func<TOutput>)` — executes a function, catches exceptions as a generic `Error.Unexpected` (exception message is **not** leaked by default); re-throws `OperationCanceledException`
- `Result.Try<TOutput>(Func<TOutput>, Func<Exception, Error>)` — opt-in overload: maps caught exceptions to a caller-defined `Error`
- `Result.TryAsync<TOutput>(Func<Task<TOutput>>)` — async version of `Try`
- `Result.TryAsync<TOutput>(Func<Task<TOutput>>, Func<Exception, Error>)` — async `Try` with exception mapper
- `Result.Create<TOutput>(value, error?)` — wraps nullable reference or value type; returns error if null
- `Result.Ensure<TOutput>(value, predicate, error)` — returns success if predicate passes, otherwise error
- `Result.Of<TOutput>(Func<Result<TOutput>>)` — executes and returns the function's result
- `Result.OfAsync<TOutput>(Func<Task<Result<TOutput>>>)` — async version of `Of`

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Author

**vlasta81**

## Support

If you encounter any issues or have questions, please file an issue on the [GitHub repository](https://github.com/vlasta81/ErrorOrResult/issues).
