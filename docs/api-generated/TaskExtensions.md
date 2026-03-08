## TaskExtensions Class

Provides extension methods for converting [System\.Threading\.Tasks\.Task&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1') to [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')\.

```csharp
public static class TaskExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; TaskExtensions

| Methods | |
| :--- | :--- |
| [ToResultAsync&lt;TOutput&gt;\(this Task&lt;Nullable&lt;TOutput&gt;&gt;, Error\)](TaskExtensions.ToResultAsync.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_System.Nullable_TOutput__,ErrorOrResult.Error) 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<System\.Nullable\<TOutput\>\>, ErrorOrResult\.Error\)') | Converts a task that returns a nullable value type to a result\. Returns an error if the value is null or if an exception occurs\. |
| [ToResultAsync&lt;TOutput&gt;\(this Task&lt;TOutput&gt;\)](TaskExtensions.ToResultAsync.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_) 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>\)') | Converts a task to a result, catching any exceptions as errors\. |
| [ToResultAsync&lt;TOutput&gt;\(this Task&lt;TOutput&gt;, Error\)](TaskExtensions.ToResultAsync.md#ErrorOrResult.TaskExtensions.ToResultAsync_TOutput_(thisSystem.Threading.Tasks.Task_TOutput_,ErrorOrResult.Error) 'ErrorOrResult\.TaskExtensions\.ToResultAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<TOutput\>, ErrorOrResult\.Error\)') | Converts a task that returns a nullable reference type to a result\. Returns an error if the value is null or if an exception occurs\. |
