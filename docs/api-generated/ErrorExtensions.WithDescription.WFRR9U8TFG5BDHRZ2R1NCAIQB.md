## ErrorExtensions\.WithDescription\(this Error, string\) Method

Creates a new error with the specified description, keeping the original code and type\.

```csharp
public static ErrorOrResult.Error WithDescription(this ErrorOrResult.Error error, string newDescription);
```
#### Parameters

<a name='ErrorOrResult.ErrorExtensions.WithDescription(thisErrorOrResult.Error,string).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The original error\.

<a name='ErrorOrResult.ErrorExtensions.WithDescription(thisErrorOrResult.Error,string).newDescription'></a>

`newDescription` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new description to apply to the error\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
A new [Error](Error.md 'ErrorOrResult\.Error') with the updated description\.