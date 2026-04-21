#### [ErrorOrResult](index.md 'index')
### [ErrorOrResult](ErrorOrResult.md 'ErrorOrResult').[Result](Result.md 'ErrorOrResult\.Result')

## Result\.TryAsync Method

| Overloads | |
| :--- | :--- |
| [TryAsync&lt;TOutput&gt;\(Func&lt;Task&lt;TOutput&gt;&gt;\)](Result.TryAsync.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__) 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>\)') | Executes an asynchronous function and captures any exceptions as errors\. |
| [TryAsync&lt;TOutput&gt;\(Func&lt;Task&lt;TOutput&gt;&gt;, Func&lt;Exception,Error&gt;\)](Result.TryAsync.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_) 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)') | Executes an asynchronous function and captures any exceptions using a caller\-supplied mapper\. |

<a name='ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__)'></a>

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

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](Result.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__).TOutput 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The asynchronous function to execute\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__).TOutput 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing a successful result with the function's return value, or a failed result if an exception occurred\.

<a name='ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_)'></a>

## Result\.TryAsync\<TOutput\>\(Func\<Task\<TOutput\>\>, Func\<Exception,Error\>\) Method

Executes an asynchronous function and captures any exceptions using a caller\-supplied mapper\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> TryAsync<TOutput>(System.Func<System.Threading.Tasks.Task<TOutput>> func, System.Func<System.Exception,ErrorOrResult.Error> exceptionMapper);
```
#### Type parameters

<a name='ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_).TOutput'></a>

`TOutput`

The type of the function's return value\.
#### Parameters

<a name='ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](Result.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_).TOutput 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The asynchronous function to execute\.

<a name='ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_).exceptionMapper'></a>

`exceptionMapper` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function that converts a caught exception into an [Error](Error.md 'ErrorOrResult\.Error')\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_).TOutput 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing a successful result with the function's return value, or a failed result mapped from the exception\.

---
Generated by [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation 'https://github\.com/Doraku/DefaultDocumentation')