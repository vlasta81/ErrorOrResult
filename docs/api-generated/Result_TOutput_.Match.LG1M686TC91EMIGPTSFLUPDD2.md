## Result\<TOutput\>\.Match\<TResult\>\(Func\<TOutput,TResult\>, Func\<ErrorInfo,TResult\>\) Method

Pattern matches on the result, executing one of two functions based on success or error state\.

```csharp
public TResult Match<TResult>(System.Func<TOutput,TResult> onSuccess, System.Func<ErrorOrResult.ErrorInfo,TResult> onFailure);
```
#### Type parameters

<a name='ErrorOrResult.Result_TOutput_.Match_TResult_(System.Func_TOutput,TResult_,System.Func_ErrorOrResult.ErrorInfo,TResult_).TResult'></a>

`TResult`

The type of the return value\.
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Match_TResult_(System.Func_TOutput,TResult_,System.Func_ErrorOrResult.ErrorInfo,TResult_).onSuccess'></a>

`onSuccess` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResult](Result_TOutput_.Match.LG1M686TC91EMIGPTSFLUPDD2.md#ErrorOrResult.Result_TOutput_.Match_TResult_(System.Func_TOutput,TResult_,System.Func_ErrorOrResult.ErrorInfo,TResult_).TResult 'ErrorOrResult\.Result\<TOutput\>\.Match\<TResult\>\(System\.Func\<TOutput,TResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,TResult\>\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is successful\.

<a name='ErrorOrResult.Result_TOutput_.Match_TResult_(System.Func_TOutput,TResult_,System.Func_ErrorOrResult.ErrorInfo,TResult_).onFailure'></a>

`onFailure` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TResult](Result_TOutput_.Match.LG1M686TC91EMIGPTSFLUPDD2.md#ErrorOrResult.Result_TOutput_.Match_TResult_(System.Func_TOutput,TResult_,System.Func_ErrorOrResult.ErrorInfo,TResult_).TResult 'ErrorOrResult\.Result\<TOutput\>\.Match\<TResult\>\(System\.Func\<TOutput,TResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,TResult\>\)\.TResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is in error state\.

#### Returns
[TResult](Result_TOutput_.Match.LG1M686TC91EMIGPTSFLUPDD2.md#ErrorOrResult.Result_TOutput_.Match_TResult_(System.Func_TOutput,TResult_,System.Func_ErrorOrResult.ErrorInfo,TResult_).TResult 'ErrorOrResult\.Result\<TOutput\>\.Match\<TResult\>\(System\.Func\<TOutput,TResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,TResult\>\)\.TResult')  
The value returned by either onSuccess or onFailure\.