## Result\<TOutput\>\.Map\<TResult\>\(Func\<TOutput,TResult\>\) Method

Maps the success value of a result to a new value using the specified selector function\.
If the result is in error state, the error is propagated\.

```csharp
public ErrorOrResult.Result<TResult> Map<TResult>(System.Func<TOutput,TResult> selector);
```
#### Type parameters

<a name='ErrorOrResult.Result_TOutput_.Map_TResult_(System.Func_TOutput,TResult_).TResult'></a>

`TResult`

The type of the output result value\.
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Map_TResult_(System.Func_TOutput,TResult_).selector'></a>

`selector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResult](Result_TOutput_.Map.F8O6RAW33TJ1Q4SER87CLGRB3.md#ErrorOrResult.Result_TOutput_.Map_TResult_(System.Func_TOutput,TResult_).TResult 'ErrorOrResult\.Result\<TOutput\>\.Map\<TResult\>\(System\.Func\<TOutput,TResult\>\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to apply to the success value\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TResult](Result_TOutput_.Map.F8O6RAW33TJ1Q4SER87CLGRB3.md#ErrorOrResult.Result_TOutput_.Map_TResult_(System.Func_TOutput,TResult_).TResult 'ErrorOrResult\.Result\<TOutput\>\.Map\<TResult\>\(System\.Func\<TOutput,TResult\>\)\.TResult')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result containing the mapped value or the original error\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is uninitialized\.