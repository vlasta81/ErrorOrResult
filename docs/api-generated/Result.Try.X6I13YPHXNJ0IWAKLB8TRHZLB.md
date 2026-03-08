## Result\.Try\<TOutput\>\(Func\<TOutput\>\) Method

Executes a function and captures any exceptions as errors\.

```csharp
public static ErrorOrResult.Result<TOutput> Try<TOutput>(System.Func<TOutput> func);
```
#### Type parameters

<a name='ErrorOrResult.Result.Try_TOutput_(System.Func_TOutput_).TOutput'></a>

`TOutput`

The type of the function's return value\.
#### Parameters

<a name='ErrorOrResult.Result.Try_TOutput_(System.Func_TOutput_).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[TOutput](Result.Try.X6I13YPHXNJ0IWAKLB8TRHZLB.md#ErrorOrResult.Result.Try_TOutput_(System.Func_TOutput_).TOutput 'ErrorOrResult\.Result\.Try\<TOutput\>\(System\.Func\<TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The function to execute\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.Try.X6I13YPHXNJ0IWAKLB8TRHZLB.md#ErrorOrResult.Result.Try_TOutput_(System.Func_TOutput_).TOutput 'ErrorOrResult\.Result\.Try\<TOutput\>\(System\.Func\<TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A successful result with the function's return value, or a failed result if an exception occurred\.