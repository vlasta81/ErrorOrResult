## Result\.TryAsync\<TOutput\>\(Func\<Task\<TOutput\>\>\) Method

Executes an asynchronous function and captures any exceptions as errors\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> TryAsync<TOutput>(System.Func<System.Threading.Tasks.Task<TOutput>> func);
```
#### Type parameters

<a name='ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__).TOutput'></a>

`TOutput`

The type of the function's return value\.
#### Parameters

<a name='ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](Result.TryAsync.6HIRWBMFRGN25909M4YTIZ701.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__).TOutput 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The asynchronous function to execute\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.TryAsync.6HIRWBMFRGN25909M4YTIZ701.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__).TOutput 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing a successful result with the function's return value, or a failed result if an exception occurred\.