## Error\.BadRequest\(string, string\) Method

Creates a bad request error\.

```csharp
public static ErrorOrResult.Error BadRequest(string code="General.BadRequest", string description="A 'BadRequest' error has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.BadRequest(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.BadRequest"\.

<a name='ErrorOrResult.Error.BadRequest(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "A 'BadRequest' error has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing a bad request error\.