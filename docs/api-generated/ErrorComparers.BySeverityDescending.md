## ErrorComparers\.BySeverityDescending Property

Orders errors so that the most client\-actionable categories come first
\(validation and request\-shape issues before infrastructure failures\)\.

```csharp
public static System.Collections.Generic.IComparer<ErrorOrResult.Error> BySeverityDescending { get; }
```

#### Property Value
[System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

### Remarks
Severity ranking \(higher comes first\):
- [Validation](ErrorType.md#ErrorOrResult.ErrorType.Validation 'ErrorOrResult\.ErrorType\.Validation') (100)
- [BadRequest](ErrorType.md#ErrorOrResult.ErrorType.BadRequest 'ErrorOrResult\.ErrorType\.BadRequest') (90)
- [Conflict](ErrorType.md#ErrorOrResult.ErrorType.Conflict 'ErrorOrResult\.ErrorType\.Conflict') (80)
- [Unauthorized](ErrorType.md#ErrorOrResult.ErrorType.Unauthorized 'ErrorOrResult\.ErrorType\.Unauthorized') (70)
- [Forbidden](ErrorType.md#ErrorOrResult.ErrorType.Forbidden 'ErrorOrResult\.ErrorType\.Forbidden') (60)
- [NotFound](ErrorType.md#ErrorOrResult.ErrorType.NotFound 'ErrorOrResult\.ErrorType\.NotFound') (50)
- [Failure](ErrorType.md#ErrorOrResult.ErrorType.Failure 'ErrorOrResult\.ErrorType\.Failure') (20)
- [Unexpected](ErrorType.md#ErrorOrResult.ErrorType.Unexpected 'ErrorOrResult\.ErrorType\.Unexpected') (10)