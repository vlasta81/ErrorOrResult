## ResultHttpExtensions\.MatchHttpAsync\<TOutput\>\(this Task\<Result\<TOutput\>\>, Func\<TOutput,IResult\>, Func\<ErrorInfo,IResult\>\) Method

Asynchronously pattern matches on a result and executes one of two functions to create an HTTP response\.

```csharp
public static System.Threading.Tasks.Task<Microsoft.AspNetCore.Http.IResult> MatchHttpAsync<TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> resultTask, System.Func<TOutput,Microsoft.AspNetCore.Http.IResult> onSuccess, System.Func<ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult>? onFailure=null);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttpAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttpAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.MatchHttpAsync.ND0UDR769ASI5MST7OZAWZ424.md#ErrorOrResult.ResultHttpExtensions.MatchHttpAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.MatchHttpAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to match on\.

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttpAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).onSuccess'></a>

`onSuccess` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultHttpExtensions.MatchHttpAsync.ND0UDR769ASI5MST7OZAWZ424.md#ErrorOrResult.ResultHttpExtensions.MatchHttpAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.MatchHttpAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is successful\.

<a name='ErrorOrResult.ResultHttpExtensions.MatchHttpAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_,System.Func_ErrorOrResult.ErrorInfo,Microsoft.AspNetCore.Http.IResult_).onFailure'></a>

`onFailure` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Optional function to execute if the result is in error state\. If not provided, uses default error handling\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing an [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') HTTP response\.