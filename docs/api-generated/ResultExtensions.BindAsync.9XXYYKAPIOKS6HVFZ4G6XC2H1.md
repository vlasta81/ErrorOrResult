## ResultExtensions\.BindAsync\<TInput,TOutput\>\(this Task\<Result\<TInput\>\>, Func\<TInput,Task\<Result\<TOutput\>\>\>\) Method

Asynchronously chains a result with another asynchronous operation that returns a result\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> BindAsync<TInput,TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TInput>> resultTask, System.Func<TInput,System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>>> binder);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TInput'></a>

`TInput`

The type of the input result value\.

<a name='ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TOutput'></a>

`TOutput`

The type of the output result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TInput](ResultExtensions.BindAsync.9XXYYKAPIOKS6HVFZ4G6XC2H1.md#ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TInput 'ErrorOrResult\.ResultExtensions\.BindAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)\.TInput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to bind\.

<a name='ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).binder'></a>

`binder` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](ResultExtensions.BindAsync.9XXYYKAPIOKS6HVFZ4G6XC2H1.md#ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TInput 'ErrorOrResult\.ResultExtensions\.BindAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)\.TInput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.BindAsync.9XXYYKAPIOKS6HVFZ4G6XC2H1.md#ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TOutput 'ErrorOrResult\.ResultExtensions\.BindAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The asynchronous function that takes the success value and returns a new result\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.BindAsync.9XXYYKAPIOKS6HVFZ4G6XC2H1.md#ErrorOrResult.ResultExtensions.BindAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TOutput 'ErrorOrResult\.ResultExtensions\.BindAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the result returned by the binder or the original error\.