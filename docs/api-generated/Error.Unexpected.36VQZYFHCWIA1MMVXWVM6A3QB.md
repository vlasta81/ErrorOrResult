## Error\.Unexpected\(string, string\) Method

Creates an unexpected error\.

```csharp
public static ErrorOrResult.Error Unexpected(string code="General.Unexpected", string description="An unexpected error has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.Unexpected(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.Unexpected"\.

<a name='ErrorOrResult.Error.Unexpected(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "An unexpected error has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing an unexpected error\.