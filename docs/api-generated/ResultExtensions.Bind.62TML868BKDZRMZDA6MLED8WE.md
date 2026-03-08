## ResultExtensions\.Bind\<TInput,TOutput\>\(this Result\<TInput\>, Func\<TInput,Result\<TOutput\>\>\) Method

Chains a result with another operation that returns a result \(flatMap/bind operation\)\.
If the first result is in error state, the error is propagated without executing the binder\.

```csharp
public static ErrorOrResult.Result<TOutput> Bind<TInput,TOutput>(this ErrorOrResult.Result<TInput> result, System.Func<TInput,ErrorOrResult.Result<TOutput>> binder);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).TInput'></a>

`TInput`

The type of the input result value\.

<a name='ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).TOutput'></a>

`TOutput`

The type of the output result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TInput](ResultExtensions.Bind.62TML868BKDZRMZDA6MLED8WE.md#ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).TInput 'ErrorOrResult\.ResultExtensions\.Bind\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,ErrorOrResult\.Result\<TOutput\>\>\)\.TInput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to bind\.

<a name='ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).binder'></a>

`binder` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](ResultExtensions.Bind.62TML868BKDZRMZDA6MLED8WE.md#ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).TInput 'ErrorOrResult\.ResultExtensions\.Bind\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,ErrorOrResult\.Result\<TOutput\>\>\)\.TInput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Bind.62TML868BKDZRMZDA6MLED8WE.md#ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.ResultExtensions\.Bind\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function that takes the success value and returns a new result\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Bind.62TML868BKDZRMZDA6MLED8WE.md#ErrorOrResult.ResultExtensions.Bind_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.ResultExtensions\.Bind\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The result returned by the binder or the original error\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is uninitialized\.