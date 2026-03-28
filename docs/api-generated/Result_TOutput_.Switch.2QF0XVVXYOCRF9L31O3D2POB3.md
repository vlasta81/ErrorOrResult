## Result\<TOutput\>\.Switch\(Action\<TOutput\>, Action\<ErrorInfo\>\) Method

Executes one of two actions based on whether the result is successful or in error state\.
Similar to Match but returns void\.

```csharp
public void Switch(System.Action<TOutput> onSuccess, System.Action<ErrorOrResult.ErrorInfo> onFailure);
```
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Switch(System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).onSuccess'></a>

`onSuccess` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute if the result is successful\.

<a name='ErrorOrResult.Result_TOutput_.Switch(System.Action_TOutput_,System.Action_ErrorOrResult.ErrorInfo_).onFailure'></a>

`onFailure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute if the result is in error state\.