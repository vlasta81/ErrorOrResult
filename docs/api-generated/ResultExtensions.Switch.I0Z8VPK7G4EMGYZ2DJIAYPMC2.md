## ResultExtensions\.Switch\<TOutput\>\(this Result\<TOutput\>, Action\<TOutput\>, Action\<ErrorInfo\>\) Method

Executes one of two actions based on whether the result is successful or in error state\.
Similar to Match but returns void\.

```csharp
public static void Switch<TOutput>(this ErrorOrResult.Result<TOutput> result, System.Action<TOutput> onSuccess, System.Action<ErrorOrResult.ErrorInfo> onFailure);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.Switch_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.Switch_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Switch.I0Z8VPK7G4EMGYZ2DJIAYPMC2.md#ErrorOrResult.ResultExtensions.Switch_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).TOutput 'ErrorOrResult\.ResultExtensions\.Switch\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Action\<TOutput\>, System\.Action\<ErrorOrResult\.ErrorInfo\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to switch on\.

<a name='ErrorOrResult.ResultExtensions.Switch_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).onSuccess'></a>

`onSuccess` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[TOutput](ResultExtensions.Switch.I0Z8VPK7G4EMGYZ2DJIAYPMC2.md#ErrorOrResult.ResultExtensions.Switch_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).TOutput 'ErrorOrResult\.ResultExtensions\.Switch\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Action\<TOutput\>, System\.Action\<ErrorOrResult\.ErrorInfo\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute if the result is successful\.

<a name='ErrorOrResult.ResultExtensions.Switch_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).onFailure'></a>

`onFailure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute if the result is in error state\.