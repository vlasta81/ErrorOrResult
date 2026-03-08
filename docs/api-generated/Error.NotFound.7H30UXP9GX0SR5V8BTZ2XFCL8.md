## Error\.NotFound\(string, string\) Method

Creates a not found error\.

```csharp
public static ErrorOrResult.Error NotFound(string code="General.NotFound", string description="A 'Not Found' error has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.NotFound(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.NotFound"\.

<a name='ErrorOrResult.Error.NotFound(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "A 'Not Found' error has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing a not found error\.