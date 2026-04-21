## Result Class

Provides static factory methods for creating [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>') instances\.

```csharp
public static class Result
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; Result

| Methods | |
| :--- | :--- |
| [Create&lt;TOutput&gt;\(Nullable&lt;TOutput&gt;, Nullable&lt;Error&gt;\)](Result.Create.md#ErrorOrResult.Result.Create_TOutput_(System.Nullable_TOutput_,System.Nullable_ErrorOrResult.Error_) 'ErrorOrResult\.Result\.Create\<TOutput\>\(System\.Nullable\<TOutput\>, System\.Nullable\<ErrorOrResult\.Error\>\)') | Creates a result from a nullable value type\. |
| [Create&lt;TOutput&gt;\(TOutput, Nullable&lt;Error&gt;\)](Result.Create.md#ErrorOrResult.Result.Create_TOutput_(TOutput,System.Nullable_ErrorOrResult.Error_) 'ErrorOrResult\.Result\.Create\<TOutput\>\(TOutput, System\.Nullable\<ErrorOrResult\.Error\>\)') | Creates a result from a nullable reference type value\. |
| [Ensure&lt;TOutput&gt;\(TOutput, Func&lt;TOutput,bool&gt;, Error\)](Result.Ensure.PDSAUZYTSY5BGDQ5WQARZU1VC.md 'ErrorOrResult\.Result\.Ensure\<TOutput\>\(TOutput, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)') | Creates a result based on a predicate check\. |
| [Failure\(Error\)](Result.Failure.md#ErrorOrResult.Result.Failure(ErrorOrResult.Error) 'ErrorOrResult\.Result\.Failure\(ErrorOrResult\.Error\)') | Creates a failed result with no value and a single error\. |
| [Failure\(ErrorInfo\)](Result.Failure.md#ErrorOrResult.Result.Failure(ErrorOrResult.ErrorInfo) 'ErrorOrResult\.Result\.Failure\(ErrorOrResult\.ErrorInfo\)') | Creates a failed result with no value and error information\. |
| [Failure\(Error\[\]\)](Result.Failure.md#ErrorOrResult.Result.Failure(ErrorOrResult.Error[]) 'ErrorOrResult\.Result\.Failure\(ErrorOrResult\.Error\[\]\)') | Creates a failed result with no value and an array of errors\. |
| [Failure\(List&lt;Error&gt;\)](Result.Failure.md#ErrorOrResult.Result.Failure(System.Collections.Generic.List_ErrorOrResult.Error_) 'ErrorOrResult\.Result\.Failure\(System\.Collections\.Generic\.List\<ErrorOrResult\.Error\>\)') | Creates a failed result with no value and a list of errors\. |
| [Failure&lt;TOutput&gt;\(Error\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.Error\)') | Creates a failed result with a single error\. |
| [Failure&lt;TOutput&gt;\(ErrorInfo\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.ErrorInfo) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.ErrorInfo\)') | Creates a failed result with error information\. |
| [Failure&lt;TOutput&gt;\(Error\[\]\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error[]) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.Error\[\]\)') | Creates a failed result with an array of errors\. |
| [Failure&lt;TOutput&gt;\(List&lt;Error&gt;\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(System.Collections.Generic.List_ErrorOrResult.Error_) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(System\.Collections\.Generic\.List\<ErrorOrResult\.Error\>\)') | Creates a failed result with a list of errors\. |
| [Of&lt;TOutput&gt;\(Func&lt;Result&lt;TOutput&gt;&gt;\)](Result.Of.6OZR9VPKH8BG1OOM1EUMXSR0D.md 'ErrorOrResult\.Result\.Of\<TOutput\>\(System\.Func\<ErrorOrResult\.Result\<TOutput\>\>\)') | Executes a function that returns a result\. |
| [OfAsync&lt;TOutput&gt;\(Func&lt;Task&lt;Result&lt;TOutput&gt;&gt;&gt;\)](Result.OfAsync.TUOJ8BIIOHNLTOZ2EFPL9DNIC.md 'ErrorOrResult\.Result\.OfAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)') | Executes an asynchronous function that returns a result\. |
| [Success\(\)](Result.Success.md#ErrorOrResult.Result.Success() 'ErrorOrResult\.Result\.Success\(\)') | Creates a successful result with no value \(using [None](None.md 'ErrorOrResult\.None')\)\. |
| [Success&lt;TOutput&gt;\(TOutput\)](Result.Success.md#ErrorOrResult.Result.Success_TOutput_(TOutput) 'ErrorOrResult\.Result\.Success\<TOutput\>\(TOutput\)') | Creates a successful result with the specified value\. |
| [Try&lt;TOutput&gt;\(Func&lt;TOutput&gt;\)](Result.Try.md#ErrorOrResult.Result.Try_TOutput_(System.Func_TOutput_) 'ErrorOrResult\.Result\.Try\<TOutput\>\(System\.Func\<TOutput\>\)') | Executes a function and captures any exceptions as errors\. |
| [Try&lt;TOutput&gt;\(Func&lt;TOutput&gt;, Func&lt;Exception,Error&gt;\)](Result.Try.md#ErrorOrResult.Result.Try_TOutput_(System.Func_TOutput_,System.Func_System.Exception,ErrorOrResult.Error_) 'ErrorOrResult\.Result\.Try\<TOutput\>\(System\.Func\<TOutput\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)') | Executes a function and captures any exceptions using a caller\-supplied mapper\. |
| [TryAsync&lt;TOutput&gt;\(Func&lt;Task&lt;TOutput&gt;&gt;\)](Result.TryAsync.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__) 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>\)') | Executes an asynchronous function and captures any exceptions as errors\. |
| [TryAsync&lt;TOutput&gt;\(Func&lt;Task&lt;TOutput&gt;&gt;, Func&lt;Exception,Error&gt;\)](Result.TryAsync.md#ErrorOrResult.Result.TryAsync_TOutput_(System.Func_System.Threading.Tasks.Task_TOutput__,System.Func_System.Exception,ErrorOrResult.Error_) 'ErrorOrResult\.Result\.TryAsync\<TOutput\>\(System\.Func\<System\.Threading\.Tasks\.Task\<TOutput\>\>, System\.Func\<System\.Exception,ErrorOrResult\.Error\>\)') | Executes an asynchronous function and captures any exceptions using a caller\-supplied mapper\. |
