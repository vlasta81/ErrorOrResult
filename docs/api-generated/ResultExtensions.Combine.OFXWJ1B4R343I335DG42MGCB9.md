## ResultExtensions\.Combine\<TOutput1,TOutput2\>\(this Result\<TOutput1\>, Result\<TOutput2\>\) Method

Combines two results into a single result containing a tuple of both values\.
If either result is in error state, all errors are combined\.

```csharp
public static ErrorOrResult.Result<(TOutput1,TOutput2)> Combine<TOutput1,TOutput2>(this ErrorOrResult.Result<TOutput1> result1, ErrorOrResult.Result<TOutput2> result2);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).TOutput1'></a>

`TOutput1`

The type of the first result value\.

<a name='ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).TOutput2'></a>

`TOutput2`

The type of the second result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).result1'></a>

`result1` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput1](ResultExtensions.Combine.OFXWJ1B4R343I335DG42MGCB9.md#ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).TOutput1 'ErrorOrResult\.ResultExtensions\.Combine\<TOutput1,TOutput2\>\(this ErrorOrResult\.Result\<TOutput1\>, ErrorOrResult\.Result\<TOutput2\>\)\.TOutput1')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The first result\.

<a name='ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).result2'></a>

`result2` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput2](ResultExtensions.Combine.OFXWJ1B4R343I335DG42MGCB9.md#ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).TOutput2 'ErrorOrResult\.ResultExtensions\.Combine\<TOutput1,TOutput2\>\(this ErrorOrResult\.Result\<TOutput1\>, ErrorOrResult\.Result\<TOutput2\>\)\.TOutput2')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The second result\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOutput1](ResultExtensions.Combine.OFXWJ1B4R343I335DG42MGCB9.md#ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).TOutput1 'ErrorOrResult\.ResultExtensions\.Combine\<TOutput1,TOutput2\>\(this ErrorOrResult\.Result\<TOutput1\>, ErrorOrResult\.Result\<TOutput2\>\)\.TOutput1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOutput2](ResultExtensions.Combine.OFXWJ1B4R343I335DG42MGCB9.md#ErrorOrResult.ResultExtensions.Combine_TOutput1,TOutput2_(thisErrorOrResult.Result_TOutput1_,ErrorOrResult.Result_TOutput2_).TOutput2 'ErrorOrResult\.ResultExtensions\.Combine\<TOutput1,TOutput2\>\(this ErrorOrResult\.Result\<TOutput1\>, ErrorOrResult\.Result\<TOutput2\>\)\.TOutput2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result containing a tuple of both values if both are successful, otherwise a combined error result\.