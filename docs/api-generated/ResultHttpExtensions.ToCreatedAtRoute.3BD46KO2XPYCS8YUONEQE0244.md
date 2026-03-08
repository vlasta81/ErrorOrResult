## ResultHttpExtensions\.ToCreatedAtRoute\<TOutput\>\(this Result\<TOutput\>, string, object\) Method

Converts a successful result to a typed CreatedAtRoute \(201\) response\.
Throws an exception if the result is in error state\.

```csharp
public static Microsoft.AspNetCore.Http.HttpResults.CreatedAtRoute<TOutput> ToCreatedAtRoute<TOutput>(this ErrorOrResult.Result<TOutput> result, string routeName, object? routeValues=null);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToCreatedAtRoute_TOutput_(thisErrorOrResult.Result_TOutput_,string,object).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToCreatedAtRoute_TOutput_(thisErrorOrResult.Result_TOutput_,string,object).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.ToCreatedAtRoute.3BD46KO2XPYCS8YUONEQE0244.md#ErrorOrResult.ResultHttpExtensions.ToCreatedAtRoute_TOutput_(thisErrorOrResult.Result_TOutput_,string,object).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToCreatedAtRoute\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, string, object\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to convert\.

<a name='ErrorOrResult.ResultHttpExtensions.ToCreatedAtRoute_TOutput_(thisErrorOrResult.Result_TOutput_,string,object).routeName'></a>

`routeName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the route to use for generating the location URI\.

<a name='ErrorOrResult.ResultHttpExtensions.ToCreatedAtRoute_TOutput_(thisErrorOrResult.Result_TOutput_,string,object).routeValues'></a>

`routeValues` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The route values to use for generating the location URI\.

#### Returns
[Microsoft\.AspNetCore\.Http\.HttpResults\.CreatedAtRoute&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.createdatroute-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.CreatedAtRoute\`1')[TOutput](ResultHttpExtensions.ToCreatedAtRoute.3BD46KO2XPYCS8YUONEQE0244.md#ErrorOrResult.ResultHttpExtensions.ToCreatedAtRoute_TOutput_(thisErrorOrResult.Result_TOutput_,string,object).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToCreatedAtRoute\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, string, object\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresults.createdatroute-1 'Microsoft\.AspNetCore\.Http\.HttpResults\.CreatedAtRoute\`1')  
A typed CreatedAtRoute response with the value\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.