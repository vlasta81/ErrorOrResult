## Error\.WithDescription\(string\) Method

Creates a new error with the specified description, keeping the original code and type\.

```csharp
public ErrorOrResult.Error WithDescription(string newDescription);
```
#### Parameters

<a name='ErrorOrResult.Error.WithDescription(string).newDescription'></a>

`newDescription` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new description to apply to the error\.

#### Returns
[Error](Error.md 'ErrorOrResult\.Error')  
A new [Error](Error.md 'ErrorOrResult\.Error') with the updated description\.