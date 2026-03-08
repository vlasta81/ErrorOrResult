## ErrorInfo Struct

Represents information about one or more errors\.
Can hold a single error or a collection of errors\.

```csharp
public readonly record struct ErrorInfo : System.IEquatable<ErrorOrResult.ErrorInfo>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [ErrorInfo\(Error\)](ErrorInfo.ErrorInfo.md#ErrorOrResult.ErrorInfo.ErrorInfo(ErrorOrResult.Error) 'ErrorOrResult\.ErrorInfo\.ErrorInfo\(ErrorOrResult\.Error\)') | Initializes a new instance of [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo') with a single error\. |
| [ErrorInfo\(Error\[\]\)](ErrorInfo.ErrorInfo.md#ErrorOrResult.ErrorInfo.ErrorInfo(ErrorOrResult.Error[]) 'ErrorOrResult\.ErrorInfo\.ErrorInfo\(ErrorOrResult\.Error\[\]\)') | Initializes a new instance of [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo') with an array of errors\. |
| [ErrorInfo\(List&lt;Error&gt;\)](ErrorInfo.ErrorInfo.md#ErrorOrResult.ErrorInfo.ErrorInfo(System.Collections.Generic.List_ErrorOrResult.Error_) 'ErrorOrResult\.ErrorInfo\.ErrorInfo\(System\.Collections\.Generic\.List\<ErrorOrResult\.Error\>\)') | Initializes a new instance of [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo') with a list of errors\. |

| Properties | |
| :--- | :--- |
| [AllErrors](ErrorInfo.AllErrors.md 'ErrorOrResult\.ErrorInfo\.AllErrors') | Gets all errors as an immutable array\. |
| [Count](ErrorInfo.Count.md 'ErrorOrResult\.ErrorInfo\.Count') | Gets the number of errors in this instance\. |
| [FirstError](ErrorInfo.FirstError.md 'ErrorOrResult\.ErrorInfo\.FirstError') | Gets the first error in the collection\. |

| Methods | |
| :--- | :--- |
| [ToString\(\)](ErrorInfo.ToString().md 'ErrorOrResult\.ErrorInfo\.ToString\(\)') | Returns a string representation of the error information\. |

| Operators | |
| :--- | :--- |
| [implicit operator ErrorInfo\(Error\)](ErrorInfo.op_Implicit.P2AEI6JVK573GO7SQV7M46LM1.md 'ErrorOrResult\.ErrorInfo\.op\_Implicit ErrorOrResult\.ErrorInfo\(ErrorOrResult\.Error\)') | Implicitly converts an [Error](Error.md 'ErrorOrResult\.Error') to [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')\. |
| [implicit operator ErrorInfo\(Error\[\]\)](ErrorInfo.op_Implicit.JVG3DKXTU88AS9B6QAFCRTNNC.md 'ErrorOrResult\.ErrorInfo\.op\_Implicit ErrorOrResult\.ErrorInfo\(ErrorOrResult\.Error\[\]\)') | Implicitly converts an array of [Error](Error.md 'ErrorOrResult\.Error') to [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')\. |
| [implicit operator ErrorInfo\(List&lt;Error&gt;\)](ErrorInfo.op_Implicit.K3T0KLS9217KPX3ABVW3S2FO3.md 'ErrorOrResult\.ErrorInfo\.op\_Implicit ErrorOrResult\.ErrorInfo\(System\.Collections\.Generic\.List\<ErrorOrResult\.Error\>\)') | Implicitly converts a list of [Error](Error.md 'ErrorOrResult\.Error') to [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')\. |
