## ResultHttpExtensions\.MatchHttp\<TOutput\>\(this Result\<TOutput\>, Func\<TOutput,IResult\>, Func\<ErrorInfo,IResult\>\) Method

Pattern matches on a result and executes one of two functions to create an HTTP response\.

```csharp
public static Microsoft.AspNetCore.Http.IResult MatchHttp<TOutput>(this ErrorOrResult.Result<TOutput> result, System.Func<TOutput,Microsoft.AspNetCore.Http.IResult> onSuccess, System.Func<ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult>? onFailure=null);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttp_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttp_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.MatchHttp.5C6XX6L3TO77HZBYTMPX8K63B.md#ErrorOrResult.ResultHttpExtensions.MatchHttp_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.MatchHttp\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to match on\.

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttp_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).onSuccess'></a>

`onSuccess` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultHttpExtensions.MatchHttp.5C6XX6L3TO77HZBYTMPX8K63B.md#ErrorOrResult.ResultHttpExtensions.MatchHttp_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.MatchHttp\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is successful\.

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttp_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).onFailure'></a>

`onFailure` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Optional function to execute if the result is in error state\. If not provided, uses default error handling\.

#### Returns
[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')  
An [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') representing the HTTP response\.