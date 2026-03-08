## Error\.Conflict\(string, string\) Method

Creates a conflict error\.

```csharp
public static ErrorOrResult.Error Conflict(string code="General.Conflict", string description="A conflict error has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.Conflict(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.Conflict"\.

<a name='ErrorOrResult.Error.Conflict(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "A conflict error has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing a conflict error\.