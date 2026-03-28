## Result\<TOutput\>\.TapError\(Action\<ErrorInfo\>\) Method

Executes a side\-effect action on the error information without modifying the result\.
Useful for logging errors\.

```csharp
public ErrorOrResult.Result<TOutput> TapError(System.Action<ErrorOrResult.ErrorInfo> action);
```
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.TapError(System.Action_ErrorOrResult.ErrorInfo_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute on the error information\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result unchanged\.