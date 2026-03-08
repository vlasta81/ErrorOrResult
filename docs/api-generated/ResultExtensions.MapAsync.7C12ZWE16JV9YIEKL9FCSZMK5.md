## ResultExtensions\.MapAsync\<TInput,TOutput\>\(this Task\<Result\<TInput\>\>, Func\<TInput,TOutput\>\) Method

Asynchronously maps the success value of a result to a new value using the specified selector function\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> MapAsync<TInput,TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TInput>> resultTask, System.Func<TInput,TOutput> selector);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).TInput'></a>

`TInput`

The type of the input result value\.

<a name='ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).TOutput'></a>

`TOutput`

The type of the output result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TInput](ResultExtensions.MapAsync.7C12ZWE16JV9YIEKL9FCSZMK5.md#ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.MapAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>\)\.TInput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to map\.

<a name='ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).selector'></a>

`selector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](ResultExtensions.MapAsync.7C12ZWE16JV9YIEKL9FCSZMK5.md#ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.MapAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>\)\.TInput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.MapAsync.7C12ZWE16JV9YIEKL9FCSZMK5.md#ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.MapAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to apply to the success value\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.MapAsync.7C12ZWE16JV9YIEKL9FCSZMK5.md#ErrorOrResult.ResultExtensions.MapAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.MapAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing a result containing the mapped value or the original error\.