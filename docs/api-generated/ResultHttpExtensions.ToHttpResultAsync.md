#### [ErrorOrResult](index.md 'index')
### [ErrorOrResult](ErrorOrResult.md 'ErrorOrResult').[ResultHttpExtensions](ResultHttpExtensions.md 'ErrorOrResult\.ResultHttpExtensions')

## ResultHttpExtensions\.ToHttpResultAsync Method

| Overloads | |
| :--- | :--- |
| [ToHttpResultAsync\(this Task&lt;Result&lt;None&gt;&gt;\)](ResultHttpExtensions.ToHttpResultAsync.md#ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_ErrorOrResult.None__) 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResultAsync\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<ErrorOrResult\.None\>\>\)') | Asynchronously converts a result with no value to an HTTP response\. |
| [ToHttpResultAsync&lt;TOutput&gt;\(this Task&lt;Result&lt;TOutput&gt;&gt;, Func&lt;TOutput,IResult&gt;\)](ResultHttpExtensions.ToHttpResultAsync.md#ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_) 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>\)') | Asynchronously converts a result to an HTTP response\. |

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_ErrorOrResult.None__)'></a>

## ResultHttpExtensions\.ToHttpResultAsync\(this Task\<Result\<None\>\>\) Method

Asynchronously converts a result with no value to an HTTP response\.

```csharp
public static System.Threading.Tasks.Task<Microsoft.AspNetCore.Http.IResult> ToHttpResultAsync(this System.Threading.Tasks.Task<ErrorOrResult.Result<ErrorOrResult.None>> resultTask);
```
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_ErrorOrResult.None__).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[None](None.md 'ErrorOrResult\.None')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to convert\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing an [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') HTTP response\.

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_)'></a>

## ResultHttpExtensions\.ToHttpResultAsync\<TOutput\>\(this Task\<Result\<TOutput\>\>, Func\<TOutput,IResult\>\) Method

Asynchronously converts a result to an HTTP response\.

```csharp
public static System.Threading.Tasks.Task<Microsoft.AspNetCore.Http.IResult> ToHttpResultAsync<TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> resultTask, System.Func<TOutput,Microsoft.AspNetCore.Http.IResult>? onSuccess=null);
```
#### Type parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultHttpExtensions.md#ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to convert\.

<a name='ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).onSuccess'></a>

`onSuccess` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultHttpExtensions.md#ErrorOrResult.ResultHttpExtensions.ToHttpResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,Microsoft.AspNetCore.Http.IResult_).TOutput 'ErrorOrResult\.ResultHttpExtensions\.ToHttpResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,Microsoft\.AspNetCore\.Http\.IResult\>\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Optional custom function to create the success response\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing an [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') HTTP response\.

---
Generated by [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation 'https://github\.com/Doraku/DefaultDocumentation')