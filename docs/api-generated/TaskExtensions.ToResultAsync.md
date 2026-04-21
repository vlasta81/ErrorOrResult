#### [ErrorOrResult](index.md 'index')
### [ErrorOrResult](ErrorOrResult.md 'ErrorOrResult').[TaskExtensions](TaskExtensions.md 'ErrorOrResult\.TaskExtensions')

## TaskExtensions\.ToResultAsync Method

| Overloads | |
| :--- | :--- |
| [ToResultAsync&lt;TOutput&gt;\(this Task&lt;Nullable&lt;TOutput&gt;&gt;, Error\)](TaskExtensions.ToResultAsync.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error) 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<System\.Nullable\<TOutput\>\>, ErrorOrResult\.Error\)') | Converts a task that returns a nullable value type to a result\. Returns an error if the value is null or if an exception occurs\. |
| [ToResultAsync&lt;TOutput&gt;\(this Task&lt;TOutput&gt;\)](TaskExtensions.ToResultAsync.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_) 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>\)') | Converts a task to a result, catching any exceptions as errors\. |
| [ToResultAsync&lt;TOutput&gt;\(this Task&lt;TOutput&gt;, Error\)](TaskExtensions.ToResultAsync.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error) 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>, ErrorOrResult\.Error\)') | Converts a task that returns a nullable reference type to a result\. Returns an error if the value is null or if an exception occurs\. |
| [ToResultAsync&lt;TOutput&gt;\(this Task&lt;TOutput&gt;, Func&lt;Exception,Error&gt;\)](TaskExtensions.ToResultAsync.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_) 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)') | Converts a task to a result, letting the caller map captured exceptions to a custom [Error](Error.md 'ErrorOrResult\.Error')\. |

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error)'></a>

## TaskExtensions\.ToResultAsync\<TOutput\>\(this Task\<Nullable\<TOutput\>\>, Error\) Method

Converts a task that returns a nullable value type to a result\.
Returns an error if the value is null or if an exception occurs\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> ToResultAsync<TOutput>(this System.Threading.Tasks.Task<System.Nullable<TOutput>> task, ErrorOrResult.Error error)
    where TOutput : struct;
```
#### Type parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error).TOutput'></a>

`TOutput`

The value type of the task result\.
#### Parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error).task'></a>

`task` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<System\.Nullable\<TOutput\>\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task to convert\.

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error to use if the value is null\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<System\.Nullable\<TOutput\>\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A successful result if the value has a value, otherwise a failed result\.

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_)'></a>

## TaskExtensions\.ToResultAsync\<TOutput\>\(this Task\<TOutput\>\) Method

Converts a task to a result, catching any exceptions as errors\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> ToResultAsync<TOutput>(this System.Threading.Tasks.Task<TOutput> task);
```
#### Type parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_).TOutput'></a>

`TOutput`

The type of the task result\.
#### Parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_).task'></a>

`task` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task to convert\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A successful result with the task's value, or a failed result if an exception occurred\.

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error)'></a>

## TaskExtensions\.ToResultAsync\<TOutput\>\(this Task\<TOutput\>, Error\) Method

Converts a task that returns a nullable reference type to a result\.
Returns an error if the value is null or if an exception occurs\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> ToResultAsync<TOutput>(this System.Threading.Tasks.Task<TOutput?> task, ErrorOrResult.Error error)
    where TOutput : class;
```
#### Type parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error).TOutput'></a>

`TOutput`

The reference type of the task result\.
#### Parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error).task'></a>

`task` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task to convert\.

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error to use if the value is null\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A successful result if the value is not null, otherwise a failed result\.

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_)'></a>

## TaskExtensions\.ToResultAsync\<TOutput\>\(this Task\<TOutput\>, Func\<Exception,Error\>\) Method

Converts a task to a result, letting the caller map captured exceptions to a custom [Error](Error.md 'ErrorOrResult\.Error')\.

```csharp
public static System.Threading.Tasks.Task<ErrorOrResult.Result<TOutput>> ToResultAsync<TOutput>(this System.Threading.Tasks.Task<TOutput> task, System.Func<System.Exception,ErrorOrResult.Error> exceptionMapper);
```
#### Type parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_).TOutput'></a>

`TOutput`

The type of the task result\.
#### Parameters

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_).task'></a>

`task` [System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

The task to convert\.

<a name='ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_).exceptionMapper'></a>

`exceptionMapper` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

A function that converts a caught exception into an [Error](Error.md 'ErrorOrResult\.Error')\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](TaskExtensions.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_).TOutput 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A successful result with the task's value, or a failed result if an exception occurred\.

---
Generated by [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation 'https://github\.com/Doraku/DefaultDocumentation')