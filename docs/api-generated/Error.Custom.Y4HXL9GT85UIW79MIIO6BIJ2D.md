## Error\.Custom\(string, string, ErrorType\) Method

Creates a custom error with a specified type\.

```csharp
public static ErrorOrResult.Error Custom(string code, string description, ErrorOrResult.ErrorType type);
```
#### Parameters

<a name='ErrorOrResult.Error.Custom(string,string,ErrorOrResult.ErrorType).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\.

<a name='ErrorOrResult.Error.Custom(string,string,ErrorOrResult.ErrorType).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\.

<a name='ErrorOrResult.Error.Custom(string,string,ErrorOrResult.ErrorType).type'></a>

`type` [ErrorType](ErrorType.md 'ErrorOrResult\.ErrorType')

The error type\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
An [Error](Error.md 'ErrorOrResult\.Error') instance with custom values\.