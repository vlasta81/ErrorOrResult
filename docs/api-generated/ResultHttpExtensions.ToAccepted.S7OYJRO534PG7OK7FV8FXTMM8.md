## ResultHttpExtensions\.ToAccepted\<TOutput\>\(this Result\<TOutput\>, string\) Method

Converts a successful result to a typed Accepted \(202\) response\.
Throws an exception if the result is in error state\.

```csharp
public static Microsoft.AspNetCore.Http.HttpResults.Accepted<TOutput> ToAccepted<TOutput>(this ErrorOrResult.Result<TOutput> result, string? uri=null);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToAccepted_TOutput_(thisErrorOrResult.Result_TOutput_,string).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToAccepted_TOutput_(thisErrorOrResult.Result_TOutput_,string).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.ToAccepted.S7OYJRO534PG7OK7FV8FXTMM8.md#ErrorOrResult.ResultHttpExtensions.ToAccepted_TOutput_(thisErrorOrResult.Result_TOutput_,string).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToAccepted\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, string\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to convert\.

<a name='ErrorOrResult.ResultHttpExtensions.ToAccepted_TOutput_(thisErrorOrResult.Result_TOutput_,string).uri'></a>

`uri` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Optional location URI where the status of the operation can be monitored\.

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.Accepted&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.accepted-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.Accepted\`1')[TOutput](ResultHttpExtensions.ToAccepted.S7OYJRO534PG7OK7FV8FXTMM8.md#ErrorOrResult.ResultHttpExtensions.ToAccepted_TOutput_(thisErrorOrResult.Result_TOutput_,string).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToAccepted\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, string\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.accepted-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.Accepted\`1')  
A typed Accepted response with the value\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.