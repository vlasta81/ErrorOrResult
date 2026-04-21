## ErrorComparers Class

Provides reusable [System\.Collections\.Generic\.IComparer&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1') implementations for ordering [Error](Error.md 'ErrorOrResult\.Error') instances\.

```csharp
public static class ErrorComparers
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ErrorComparers

| Properties | |
| :--- | :--- |
| [BySeverityDescending](ErrorComparers.BySeverityDescending.md 'ErrorOrResult\.ErrorComparers\.BySeverityDescending') | Orders errors so that the most client\-actionable categories come first \(validation and request\-shape issues before infrastructure failures\)\. |
