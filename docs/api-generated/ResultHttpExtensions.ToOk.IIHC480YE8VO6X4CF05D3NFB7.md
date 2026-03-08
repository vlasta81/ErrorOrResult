## ResultHttpExtensions\.ToOk\<TOutput\>\(this Result\<TOutput\>\) Method

Converts a successful result to a typed OK \(200\) response\.
Throws an exception if the result is in error state\.

```csharp
public static Microsoft.AspNetCore.Http.HttpResults.Ok<TOutput> ToOk<TOutput>(this ErrorOrResult.Result<TOutput> result);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToOk_TOutput_(thisErrorOrResult.Result_TOutput_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToOk_TOutput_(thisErrorOrResult.Result_TOutput_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.ToOk.IIHC480YE8VO6X4CF05D3NFB7.md#ErrorOrResult.ResultHttpExtensions.ToOk_TOutput_(thisErrorOrResult.Result_TOutput_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToOk\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to convert\.

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.Ok&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.ok-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.Ok\`1')[TOutput](ResultHttpExtensions.ToOk.IIHC480YE8VO6X4CF05D3NFB7.md#ErrorOrResult.ResultHttpExtensions.ToOk_TOutput_(thisErrorOrResult.Result_TOutput_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToOk\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.ok-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.Ok\`1')  
A typed OK response with the value\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.