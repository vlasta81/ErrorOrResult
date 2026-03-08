## ResultExtensions\.Match\<TInput,TOutput\>\(this Result\<TInput\>, Func\<TInput,TOutput\>, Func\<ErrorInfo,TOutput\>\) Method

Pattern matches on the result, executing one of two functions based on success or error state\.

```csharp
public static TOutput Match<TInput,TOutput>(this ErrorOrResult.Result<TInput> result, System.Func<TInput,TOutput> onSuccess, System.Func<ErrorOrResult.ErrorInfo,TOutput> onFailure);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TInput'></a>

`TInput`

The type of the input result value\.

<a name='ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput'></a>

`TOutput`

The type of the return value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TInput](ResultExtensions.Match.AKZA3GBW5SXVQ4JBA2EFPRDQ.md#ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.Match\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TInput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to match on\.

<a name='ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).onSuccess'></a>

`onSuccess` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TInput](ResultExtensions.Match.AKZA3GBW5SXVQ4JBA2EFPRDQ.md#ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TInput 'ErrorOrResult\.ResultExtensions\.Match\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TInput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.Match.AKZA3GBW5SXVQ4JBA2EFPRDQ.md#ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Match\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is successful\.

<a name='ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).onFailure'></a>

`onFailure` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultExtensions.Match.AKZA3GBW5SXVQ4JBA2EFPRDQ.md#ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Match\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to execute if the result is in error state\.

#### Returns
[TOutput](ResultExtensions.Match.AKZA3GBW5SXVQ4JBA2EFPRDQ.md#ErrorOrResult.ResultExtensions.Match_TInput,TOutput_(thisErrorOrResult.Result_TInput_,System.Func_TInput,TOutput_,System.Func_ErrorOrResult.ErrorInfo,TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Match\<TInput,TOutput\>\(this ErrorOrResult\.Result\<TInput\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)\.TOutput')  
The value returned by either onSuccess or onFailure\.