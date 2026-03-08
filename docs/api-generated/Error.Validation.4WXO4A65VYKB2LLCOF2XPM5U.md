## Error\.Validation\(string, string\) Method

Creates a validation error\.

```csharp
public static ErrorOrResult.Error Validation(string code="General.Validation", string description="A validation error has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.Validation(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.Validation"\.

<a name='ErrorOrResult.Error.Validation(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "A validation error has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing a validation error\.