## ResultExtensions\.TapAsync\<TOutput\>\(this Task\<Result\<TOutput\>\>, Func\<TOutput,Task\>\) Method

Asynchronously executes a side\-effect action on the success value without modifying the result\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> TapAsync<TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> resultTask, System.Func<TOutput,System.Threading.Tasks.Task> action);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.TapAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,System.Threading.Tasks.Task_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.TapAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,System.Threading.Tasks.Task_).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.TapAsync.V8KT2PF87U7VYS82MBE3YMNHE.md#ErrorOrResult.ResultExtensions.TapAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,System.Threading.Tasks.Task_).TOutput 'ErrorOrResult\.ResultExtensions\.TapAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,System\.Threading\.Tasks\.Task\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to tap\.

<a name='ErrorOrResult.ResultExtensions.TapAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,System.Threading.Tasks.Task_).action'></a>

`action` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.TapAsync.V8KT2PF87U7VYS82MBE3YMNHE.md#ErrorOrResult.ResultExtensions.TapAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,System.Threading.Tasks.Task_).TOutput 'ErrorOrResult\.ResultExtensions\.TapAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,System\.Threading\.Tasks\.Task\>\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The asynchronous action to execute on the success value\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.TapAsync.V8KT2PF87U7VYS82MBE3YMNHE.md#ErrorOrResult.ResultExtensions.TapAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,System.Threading.Tasks.Task_).TOutput 'ErrorOrResult\.ResultExtensions\.TapAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,System\.Threading\.Tasks\.Task\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the original result unchanged\.