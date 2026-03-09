# ErrorOrResult

[ENGLISH](https://github.com/vlasta81/ErrorOrResult/)

[![NuGet](https://img.shields.io/nuget/v/ErrorOrResult.svg)](https://www.nuget.org/packages/ErrorOrResult/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Lehká, funkcionální .NET knihovna pro zpracování výsledků operací s explicitními stavy úspěchu a chyb. Inspirována vzorem Result, tato knihovna vám pomůže psát robustnější a udržitelnější kód tím, že zpracování chyb je explicitní a typově bezpečné.

## Vlastnosti

- ✨ **Typově bezpečné zpracování chyb** - Explicitní stavy úspěchu a chyb s bezpečností při kompilaci
- 🔗 **Fluent API** - Řetězitelné operace s metodami `Map`, `Bind` a `Match`
- 🌐 **HTTP integrace** - Vestavěná rozšíření pro ASP.NET Core s automatickým mapováním HTTP stavových kódů
- 📝 **Podpora více chyb** - Zpracování jedné nebo více chyb v jednom výsledku
- 🎯 **Bohaté typy chyb** - Předefinované typy chyb mapované na HTTP stavové kódy (400, 401, 403, 404, 409, 422, 500, 520)
- ⚡ **Async podpora** - Plná podpora pro async/await vzory s rozšířeními `Task<Result<T>>`
- 🔍 **LINQ integrace** - Dotazování a filtrování výsledků pomocí známé LINQ syntaxe

## Dokumentace

[Dokumentace](https://github.com/vlasta81/ErrorOrResult/blob/master/docs/api-generated/index.md)

## Instalace

Instalace přes NuGet Package Manager:

```bash
dotnet add package ErrorOrResult
```

Nebo přes Package Manager Console:

```powershell
Install-Package ErrorOrResult
```

## Rychlý start

### Vytváření výsledků

```csharp
using ErrorOrResult;

// Úspěšný výsledek
var successResult = Result<int>.Success(42);

// Chybový výsledek s jednou chybou
var errorResult = Result<int>.Failure(
    Error.NotFound("User.NotFound", "Uživatel nenalezen")
);

// Chybový výsledek s více chybami
var multiErrorResult = Result<User>.Failure(
    Error.Validation("User.Name", "Jméno je povinné"),
    Error.Validation("User.Email", "Email je neplatný")
);
```

### Kontrola výsledků

```csharp
if (result.IsSuccess)
{
    Console.WriteLine($"Hodnota: {result.Value}");
}
else
{
    Console.WriteLine($"Chyba: {result.Error.Description}");
}
```

### Pattern Matching

```csharp
var message = result.Match(
    onSuccess: value => $"Úspěch: {value}",
    onFailure: errors => $"Selhalo: {errors.FirstError.Description}"
);
```

### Řetězení operací

```csharp
var result = GetUser(userId)
    .Map(user => user.Email)
    .Map(email => email.ToLower())
    .Bind(email => SendNotification(email));
```

## Typy chyb

Knihovna poskytuje předefinované typy chyb mapované na HTTP stavové kódy:

| Typ chyby | HTTP Status | Popis |
|------------|-------------|-------------|
| `BadRequest` | 400 | Neplatné parametry požadavku |
| `Unauthorized` | 401 | Vyžadována autentizace |
| `Forbidden` | 403 | Přístup zamítnut |
| `NotFound` | 404 | Zdroj nenalezen |
| `Conflict` | 409 | Konflikt zdrojů |
| `Validation` | 422 | Validační chyby |
| `Failure` | 500 | Obecné selhání |
| `Unexpected` | 520 | Neočekávaná chyba |

### Vytváření chyb

```csharp
// Předefinované tovární metody pro chyby
var notFoundError = Error.NotFound("Product.NotFound", "Produkt s ID 123 nenalezen");
var validationError = Error.Validation("Email.Invalid", "Formát emailu je neplatný");
var unauthorizedError = Error.Unauthorized("Auth.Required", "Vyžadována autentizace");

// Vlastní chyba se specifickým typem
var customError = new Error("Custom.Code", "Vlastní popis", ErrorType.Conflict);
```

## ASP.NET Core integrace

Převod výsledků přímo na HTTP odpovědi:

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

## Pokročilé použití

### Asynchronní operace

```csharp
Task<Result<User>> GetUserAsync(int id);

// Map async
var emailResult = await GetUserAsync(id)
    .MapAsync(user => user.Email);

// Bind async
var result = await GetUserAsync(id)
    .BindAsync(user => SendEmailAsync(user.Email));
```

### LINQ syntaxe dotazů

```csharp
// Použití LINQ syntaxe dotazů s výsledky
var result = from user in GetUser(userId)
             from email in ValidateEmail(user.Email)
             select email.ToLower();

// Řetězení více operací
var processedResult = 
    from user in GetUser(userId)
    from validation in ValidateUser(user)
    from saved in SaveUser(user)
    select saved;
```

### Více chyb

Vytváření výsledků s více chybami:

```csharp
// Použití pole chyb
var errors = new[]
{
    Error.Validation("Name", "Jméno je povinné"),
    Error.Validation("Email", "Email je neplatný")
};

var result = Result<User>.Failure(errors);

// Nebo pomocí ErrorInfo přímo
var errorInfo = new ErrorInfo(new[]
{
    Error.Validation("Name", "Jméno je povinné"),
    Error.Validation("Email", "Email je neplatný")
});

var result = Result<User>.Failure(errorInfo);
```

## Požadavky

- .NET 10.0 nebo vyšší
- C# 12.0 nebo vyšší (pro record struktury a nullable reference typy)

## Licence

Tento projekt je licencován pod licencí MIT - viz soubor LICENSE pro podrobnosti.

## Autor

**vlasta81**

## Podpora

Pokud narazíte na jakékoli problémy nebo máte dotazy, prosím založte issue na [GitHub repozitáři](https://github.com/vlasta81/ErrorOrResult/issues).

### LINQ syntaxe dotazů

```csharp
// Použití LINQ syntaxe dotazů s výsledky
var result = from user in GetUser(userId)
             from email in ValidateEmail(user.Email)
             select email.ToLower();

// Řetězení více operací
var processedResult = 
    from user in GetUser(userId)
    from validation in ValidateUser(user)
    from saved in SaveUser(user)
    select saved;
```

### Více chyb

Vytváření výsledků s více chybami:

```csharp
// Použití pole chyb
var errors = new[]
{
    Error.Validation("Name", "Jméno je povinné"),
    Error.Validation("Email", "Email je neplatný")
};

var result = Result<User>.Failure(errors);

// Nebo pomocí ErrorInfo přímo
var errorInfo = new ErrorInfo(new[]
{
    Error.Validation("Name", "Jméno je povinné"),
    Error.Validation("Email", "Email je neplatný")
});

var result = Result<User>.Failure(errorInfo);
```

## Požadavky

- .NET 10.0 nebo vyšší
- C# 12.0 nebo vyšší (pro record struktury a nullable reference typy)

## Licence

Tento projekt je licencován pod licencí MIT - viz soubor LICENSE pro podrobnosti.

## Autor

**vlasta81**

## Podpora

Pokud narazíte na jakékoli problémy nebo máte dotazy, prosím založte issue na [GitHub repozitáři](https://github.com/vlasta81/ErrorOrResult/issues).
