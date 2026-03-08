## ResultHttpExtensions\.ToNoContent\(this Result\<None\>\) Method

Converts a successful result with no value to a typed NoContent \(204\) response\.
Throws an exception if the result is in error state\.

```csharp
public static Microsoft.AspNetCore.Http.HttpResults.NoContent ToNoContent(this ErrorOrResult.Result<ErrorOrResult.None> result);
```
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToNoContent(thisErrorOrResult.Result_ErrorOrResult.None_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[None](None.md 'ErrorOrResult\.None')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to convert\.

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.NoContent](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.nocontent 'Microsoft\.AspNetCore\.Http\.HttpResults\.NoContent')  
A typed NoContent response\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.