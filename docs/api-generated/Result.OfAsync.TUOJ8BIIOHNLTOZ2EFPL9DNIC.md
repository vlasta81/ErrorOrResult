## Result\.OfAsync\<TOutput\>\(Func\<Task\<Result\<TOutput\>\>\>\) Method

Executes an asynchronous function that returns a result\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> OfAsync<TOutput>(System.Func<System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>>> func);
```
#### Type parameters

<a name='ErrorOrResult.Result.OfAsync_TOutput_(System.Func_System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.Result.OfAsync_TOutput_(System.Func_System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.OfAsync.TUOJ8BIIOHNLTOZ2EFPL9DNIC.md#ErrorOrResult.Result.OfAsync_TOutput_(System.Func_System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TOutput 'ErrorOrResult\.Result\.OfAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The asynchronous function to execute\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.OfAsync.TUOJ8BIIOHNLTOZ2EFPL9DNIC.md#ErrorOrResult.Result.OfAsync_TOutput_(System.Func_System.Threading.Tasks.Task_ErrorOrResult.Result_TOutput___).TOutput 'ErrorOrResult\.Result\.OfAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the result returned by the function\.