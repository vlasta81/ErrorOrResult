## ResultExtensions\.TapError\<TOutput\>\(this Result\<TOutput\>, Action\<ErrorInfo\>\) Method

Executes a side\-effect action on the error information without modifying the result\.
Useful for logging errors\.

```csharp
public static ErrorOrResult.Result<TOutput> TapError<TOutput>(this ErrorOrResult.Result<TOutput> result, System.Action<ErrorOrResult.ErrorInfo> action);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.TapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.TapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.TapError.MWH05R2LSGULNUD3OO4V3K1W5.md#ErrorOrResult.ResultExtensions.TapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).TOutput 'ErrorOrResult\.ResultExtensions\.TapError\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Action\<ErrorOrResult\.ErrorInfo\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to tap\.

<a name='ErrorOrResult.ResultExtensions.TapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute on the error information\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.TapError.MWH05R2LSGULNUD3OO4V3K1W5.md#ErrorOrResult.ResultExtensions.TapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).TOutput 'ErrorOrResult\.ResultExtensions\.TapError\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Action\<ErrorOrResult\.ErrorInfo\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result unchanged\.