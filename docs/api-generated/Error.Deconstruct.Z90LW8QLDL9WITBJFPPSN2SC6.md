## Error\.Deconstruct\(string, string, ErrorType\) Method

Deconstructs the error into its components\.

```csharp
public void Deconstruct(out string code, out string description, out ErrorOrResult.ErrorType type);
```
#### Parameters

<a name='ErrorOrResult.Error.Deconstruct(string,string,ErrorOrResult.ErrorType).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code\.

<a name='ErrorOrResult.Error.Deconstruct(string,string,ErrorOrResult.ErrorType).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error description\.

<a name='ErrorOrResult.Error.Deconstruct(string,string,ErrorOrResult.ErrorType).type'></a>

`type` [ErrorType](ErrorType.md 'ErrorOrResult\.ErrorType')

The error type\.