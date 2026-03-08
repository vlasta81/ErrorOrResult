## ResultExtensions\.ThrowOnErrorAsync\<TOutput\>\(this Task\<Result\<TOutput\>\>\) Method

Asynchronously throws an exception if the result is in error state, otherwise returns the success value\.

```csharp
public static System.Threading.Tasks.Task<TOutput> ThrowOnErrorAsync<TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> resultTask);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.ThrowOnErrorAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.ThrowOnErrorAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.ThrowOnErrorAsync.N2BT5J95XF2E2H7IUIF38K6G1.md#ErrorOrResult.ResultExtensions.ThrowOnErrorAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.ResultExtensions\.ThrowOnErrorAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to check\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](ResultExtensions.ThrowOnErrorAsync.N2BT5J95XF2E2H7IUIF38K6G1.md#ErrorOrResult.ResultExtensions.ThrowOnErrorAsync_TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.ResultExtensions\.ThrowOnErrorAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the success value if the result is successful\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.