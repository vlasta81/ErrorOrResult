## ResultExtensions\.MatchAsync\<TInput,TOutput\>\(this Task\<Result\<TInput\>\>, Func\<TInput,TOutput\>, Func\<ErrorInfo,TOutput\>\) Method

Asynchronously pattern matches on a result\.

```csharp
public static System.Threading.Tasks.Task<TOutput> MatchAsync<TInput,TOutput>(this System.Threading.Tasks.Task<ErrorOrResult.Result<TInput>> resultTask, System.Func<TInput,TOutput> onSuccess, System.Func<ErrorOrResult.ErrorInfo,TOutput> onFailure);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TInput'></a>

`TInput`

The type of the input result value\.

<a name='ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput'></a>

`TOutput`

The type of the return value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).resultTask'></a>

`resultTask` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TInput](ResultExtensions.MatchAsync.TA88DFDTBKY4ZV0BHVJAWPPF6.md#ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.MatchAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TInput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task representing the result to match on\.

<a name='ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).onSuccess'></a>

`onSuccess` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](ResultExtensions.MatchAsync.TA88DFDTBKY4ZV0BHVJAWPPF6.md#ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.MatchAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TInput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.MatchAsync.TA88DFDTBKY4ZV0BHVJAWPPF6.md#ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.MatchAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is successful\.

<a name='ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).onFailure'></a>

`onFailure` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.MatchAsync.TA88DFDTBKY4ZV0BHVJAWPPF6.md#ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.MatchAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is in error state\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](ResultExtensions.MatchAsync.TA88DFDTBKY4ZV0BHVJAWPPF6.md#ErrorOrResult.ResultExtensions.MatchAsync_TInput,TOutput_(thisSystem.Threading.Tasks.Task_ErrorOrResult.Result_TInput__,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.MatchAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the value returned by either onSuccess or onFailure\.