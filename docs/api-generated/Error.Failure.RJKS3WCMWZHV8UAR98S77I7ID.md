## Error\.Failure\(string, string\) Method

Creates a general failure error\.

```csharp
public static ErrorOrResult.Error Failure(string code="General.Failure", string description="A failure has occurred!");
```
#### Parameters

<a name='ErrorOrResult.Error.Failure(string,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\. Defaults to "General\.Failure"\.

<a name='ErrorOrResult.Error.Failure(string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\. Defaults to "A failure has occurred\!"\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance representing a failure\.