## ResultExtensions\.Ensure\<TOutput\>\(this Result\<TOutput\>, Func\<TOutput,bool\>, Error\) Method

Validates the success value using a predicate\. If the predicate fails, converts to an error result\.

```csharp
public static ErrorOrResult.Result<TOutput> Ensure<TOutput>(this ErrorOrResult.Result<TOutput> result, System.Func<TOutput,bool> predicate, ErrorOrResult.Error error);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.Ensure_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.Ensure_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,bool_,ErrorOrResult.Error).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Ensure.1DPFLR10ZITUO9FVMQWNBC96.md#ErrorOrResult.ResultExtensions.Ensure_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.ResultExtensions\.Ensure\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to validate\.

<a name='ErrorOrResult.ResultExtensions.Ensure_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,bool_,ErrorOrResult.Error).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.Ensure.1DPFLR10ZITUO9FVMQWNBC96.md#ErrorOrResult.ResultExtensions.Ensure_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.ResultExtensions\.Ensure\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The predicate to test the success value against\.

<a name='ErrorOrResult.ResultExtensions.Ensure_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,bool_,ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error to use if the predicate fails\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Ensure.1DPFLR10ZITUO9FVMQWNBC96.md#ErrorOrResult.ResultExtensions.Ensure_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.ResultExtensions\.Ensure\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result if successful and predicate passes, otherwise a failed result\.