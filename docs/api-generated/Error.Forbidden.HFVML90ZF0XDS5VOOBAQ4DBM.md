## Error\.Forbidden\(string, string\) Method

Creates a forbidden error\.

```csharp
public static ErrorOrResult.Error Forbidden(string code="General.Forbidden", string description="A 'Forbidden' error has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.Forbidden(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.Forbidden"\.

<a name='ErrorOrResult.Error.Forbidden(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "A 'Forbidden' error has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing a forbidden error\.