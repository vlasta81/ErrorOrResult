## ResultExtensions\.Map\<TInput,TOutput\>\(this Result\<TInput\>, Func\<TInput,TOutput\>\) Method

Maps the success value of a result to a new value using the specified selector function\.
If the result is in error state, the error is propagated\.

```csharp
public static ErrorOrResult.Result<TOutput> Map<TInput,TOutput>(this ErrorOrResult.Result<TInput> result, System.Func<TInput,TOutput> selector);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).TInput'></a>

`TInput`

The type of the input result value\.

<a name='ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).TOutput'></a>

`TOutput`

The type of the output result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TInput](ResultExtensions.Map.BJHXT2CPKH205HWCT9GQ6VEM8.md#ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.Map\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>\)\.TInput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to map\.

<a name='ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).selector'></a>

`selector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](ResultExtensions.Map.BJHXT2CPKH205HWCT9GQ6VEM8.md#ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.Map\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>\)\.TInput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.Map.BJHXT2CPKH205HWCT9GQ6VEM8.md#ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Map\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to apply to the success value\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Map.BJHXT2CPKH205HWCT9GQ6VEM8.md#ErrorOrResult.ResultExtensions.Map_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Map\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result containing the mapped value or the original error\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is uninitialized\.