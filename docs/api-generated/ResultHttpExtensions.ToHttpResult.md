#### [ErrorOrResult](index.md 'index')
### [ErrorOrResult](ErrorOrResult.md 'ErrorOrResult').[ResultHttpExtensions](ResultHttpExtensions.md 'ErrorOrResult\.ResultHttpExtensions')

## ResultHttpExtensions\.ToHttpResult Method

| Overloads | |
| :--- | :--- |
| [ToHttpResult\(this Result&lt;None&gt;\)](ResultHttpExtensions.ToHttpResult.md#ErrorOrResult.ResultHttpExtensions.ToHttpResult(thisErrorOrResult.Result_ErrorOrResult.None_) 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResult\(this ErrorOrResult\.Result\<ErrorOrResult\.None\>\)') | Converts a result with no value to an HTTP response\. Returns NoContent \(204\) on success, or a problem details response on error\. |
| [ToHttpResult&lt;TOutput&gt;\(this Result&lt;TOutput&gt;, Func&lt;TOutput,IResult&gt;\)](ResultHttpExtensions.ToHttpResult.md#ErrorOrResult.ResultHttpExtensions.ToHttpResult_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_) 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResult\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>\)') | Converts a result to an HTTP response\. Returns OK \(200\) with the value on success, or a problem details response on error\. |

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResult(thisErrorOrResult.Result_ErrorOrResult.None_)'></a>

## ResultHttpExtensions\.ToHttpResult\(this Result\<None\>\) Method

Converts a result with no value to an HTTP response\.
Returns NoContent \(204\) on success, or a problem details response on error\.

```csharp
public static Microsoft.AspNetCore.Http.IResult ToHttpResult(this ErrorOrResult.Result<ErrorOrResult.None> result);
```
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResult(thisErrorOrResult.Result_ErrorOrResult.None_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[None](None.md 'ErrorOrResult\.None')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to convert\.

#### Returns
[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')  
An [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') representing the HTTP response\.

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResult_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_)'></a>

## ResultHttpExtensions\.ToHttpResult\<TOutput\>\(this Result\<TOutput\>, Func\<TOutput,IResult\>\) Method

Converts a result to an HTTP response\.
Returns OK \(200\) with the value on success, or a problem details response on error\.

```csharp
public static Microsoft.AspNetCore.Http.IResult ToHttpResult<TOutput>(this ErrorOrResult.Result<TOutput> result, System.Func<TOutput,Microsoft.AspNetCore.Http.IResult>? onSuccess=null);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResult_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResult_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.md#ErrorOrResult.ResultHttpExtensions.ToHttpResult_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResult\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to convert\.

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResult_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).onSuccess'></a>

`onSuccess` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultHttpExtensions.md#ErrorOrResult.ResultHttpExtensions.ToHttpResult_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResult\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Optional custom function to create the success response\.

#### Returns
[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')  
An [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') representing the HTTP response\.

---
Generated by [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation 'https://github\.com/Doraku/DefaultDocumentation')