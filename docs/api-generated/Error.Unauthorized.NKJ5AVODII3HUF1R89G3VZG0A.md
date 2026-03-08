## Error\.Unauthorized\(string, string\) Method

Creates an unauthorized error\.

```csharp
public static ErrorOrResult.Error Unauthorized(string code="General.Unauthorized", string description="An 'Unauthorized' error has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.Unauthorized(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.Unauthorized"\.

<a name='ErrorOrResult.Error.Unauthorized(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "An 'Unauthorized' error has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing an unauthorized error\.