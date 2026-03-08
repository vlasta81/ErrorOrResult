## ResultHttpExtensions\.ToCreated\<TOutput\>\(this Result\<TOutput\>, string\) Method

Converts a successful result to a typed Created \(201\) response\.
Throws an exception if the result is in error state\.

```csharp
public static Microsoft.AspNetCore.Http.HttpResults.Created<TOutput> ToCreated<TOutput>(this ErrorOrResult.Result<TOutput> result, string uri);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToCreated_TOutput_(thisErrorOrResult.Result_TOutput_,string).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToCreated_TOutput_(thisErrorOrResult.Result_TOutput_,string).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.ToCreated.JXUBI6AECUD9BU6O1Q1MIMY68.md#ErrorOrResult.ResultHttpExtensions.ToCreated_TOutput_(thisErrorOrResult.Result_TOutput_,string).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToCreated\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, string\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to convert\.

<a name='ErrorOrResult.ResultHttpExtensions.ToCreated_TOutput_(thisErrorOrResult.Result_TOutput_,string).uri'></a>

`uri` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The location URI for the created resource\.

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.Created&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.created-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.Created\`1')[TOutput](ResultHttpExtensions.ToCreated.JXUBI6AECUD9BU6O1Q1MIMY68.md#ErrorOrResult.ResultHttpExtensions.ToCreated_TOutput_(thisErrorOrResult.Result_TOutput_,string).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToCreated\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, string\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.created-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.Created\`1')  
A typed Created response with the value\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.