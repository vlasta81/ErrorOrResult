## Result\<TOutput\>\.Bind\<TResult\>\(Func\<TOutput,Result\<TResult\>\>\) Method

Chains a result with another operation that returns a result \(flatMap/bind operation\)\.
If the first result is in error state, the error is propagated without executing the binder\.

```csharp
public ErrorOrResult.Result<TResult> Bind<TResult>(System.Func<TOutput,ErrorOrResult.Result<TResult>> binder);
```
#### Type parameters

<a name='ErrorOrResult.Result_TOutput_.Bind_TResult_(System.Func_TOutput,ErrorOrResult.Result_TResult__).TResult'></a>

`TResult`

The type of the output result value\.
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Bind_TResult_(System.Func_TOutput,ErrorOrResult.Result_TResult__).binder'></a>

`binder` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TResult](Result_TOutput_.Bind.N8RZNUZ5VSZM0NWXH9RH8X4L3.md#ErrorOrResult.Result_TOutput_.Bind_TResult_(System.Func_TOutput,ErrorOrResult.Result_TResult__).TResult 'ErrorOrResult\.Result\<TOutput\>\.Bind\<TResult\>\(System\.Func\<TOutput,ErrorOrResult\.Result\<TResult\>\>\)\.TResult')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function that takes the success value and returns a new result\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TResult](Result_TOutput_.Bind.N8RZNUZ5VSZM0NWXH9RH8X4L3.md#ErrorOrResult.Result_TOutput_.Bind_TResult_(System.Func_TOutput,ErrorOrResult.Result_TResult__).TResult 'ErrorOrResult\.Result\<TOutput\>\.Bind\<TResult\>\(System\.Func\<TOutput,ErrorOrResult\.Result\<TResult\>\>\)\.TResult')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The result returned by the binder or the original error\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is uninitialized\.