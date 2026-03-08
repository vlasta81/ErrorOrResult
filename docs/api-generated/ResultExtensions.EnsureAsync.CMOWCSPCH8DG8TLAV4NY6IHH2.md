## ResultExtensions\.EnsureAsync\<TOutput\>\(this Task\<Result\<TOutput\>\>, Func\<TOutput,bool\>, Error\) Method

Asynchronously validates the success value using a predicate\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> EnsureAsync<TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> resultTask, System.Func<TOutput,bool> predicate, ErrorOrResult.Error error);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.EnsureAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.EnsureAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,bool_,ErrorOrResult.Error).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.EnsureAsync.CMOWCSPCH8DG8TLAV4NY6IHH2.md#ErrorOrResult.ResultExtensions.EnsureAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.ResultExtensions\.EnsureAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to validate\.

<a name='ErrorOrResult.ResultExtensions.EnsureAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,bool_,ErrorOrResult.Error).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.EnsureAsync.CMOWCSPCH8DG8TLAV4NY6IHH2.md#ErrorOrResult.ResultExtensions.EnsureAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.ResultExtensions\.EnsureAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The predicate to test the success value against\.

<a name='ErrorOrResult.ResultExtensions.EnsureAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,bool_,ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error to use if the predicate fails\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.EnsureAsync.CMOWCSPCH8DG8TLAV4NY6IHH2.md#ErrorOrResult.ResultExtensions.EnsureAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.ResultExtensions\.EnsureAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the validated result\.