## None Struct

Represents the absence of a value, similar to void but usable as a generic type parameter\.
Used with [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>') when no return value is needed\.

```csharp
public readonly record struct None : System.IEquatable<ErrorOrResult.None>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[None](None.md 'ErrorOrResult\.None')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')