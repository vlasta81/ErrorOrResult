# ErrorOrResult - Testy

[ENGLISH](https://github.com/vlasta81/ErrorOrResult/README.md)

Tento projekt obsahuje kompletní sadu testů pro knihovnu ErrorOrResult pomocí xUnit.

## Pokrytí testů

### ErrorTests.cs
- Vytváření různých typů chyb (Failure, Unexpected, Validation, Conflict, NotFound, Unauthorized, Forbidden, BadRequest)
- Vlastní chyby pomocí `Error.Custom`
- NumericType mapování na HTTP status kódy
- Deconstruction a rovnost chyb

### ErrorInfoTests.cs
- Inicializace s jednou chybou, polem chyb, seznamem chyb
- Validace vstupů (null, prázdné kolekce)
- Přístup k první chybě a všem chybám
- Rovnost ErrorInfo instancí

### ResultTests.cs
- Vytváření úspěšných a neúspěšných výsledků
- Implicitní konverze z hodnoty, chyby a ErrorInfo
- Přístup k hodnotě a chybám
- Metody `GetValueOrDefault` a `GetValueOrThrow`
- ToString reprezentace
- Statické factory metody z třídy `Result`

### ResultExtensionsTests.cs
- `Map` - transformace hodnoty
- `Bind` - řetězení operací
- `Match` - pattern matching
- `Switch` - vykonání akce podle stavu
- `Tap` / `TapError` - vedlejší efekty bez změny výsledku
- `ThrowOnError` - vyvolání výjimky při chybě
- Asynchronní varianty všech metod

### ResultAdvancedExtensionsTests.cs
- `Ensure` - validace s predikatem
- `MapError` - transformace chyb
- `Combine` - kombinování více výsledků
- Řetězení více operací dohromady

### ResultLinqExtensionsTests.cs
- LINQ query syntax podpora (`select`, `from`)
- `SelectMany` pro řetězení operací
- Komplexní LINQ dotazy s více klauzulemi
- Kombinace LINQ s ostatními metodami

### TaskExtensionsTests.cs
- `ToResultAsync` pro Task<T>
- `ToResultAsync` pro nullable reference types
- `ToResultAsync` pro nullable value types
- Ošetření výjimek v asynchronních operacích

### NoneTests.cs
- Použití `None` jako generického parametru
- `None` pro operace bez návratové hodnoty
- Řetězení operací s `None`

## Spuštění testů

```bash
dotnet test
```

## Statistiky

- **Celkem testů**: 120
- **Úspěšných**: 120
- **Neúspěšných**: 0
- **Přeskočených**: 0

## Technologie

- **.NET 10.0**
- **xUnit 2.9.3**
- **Microsoft.NET.Test.Sdk 17.14.1**
