## Result\<TOutput\>\.Tap\(Action\<TOutput\>\) Method

Executes a side\-effect action on the success value without modifying the result\.
Useful for logging or other side effects\.

```csharp
public ErrorOrResult.Result<TOutput> Tap(System.Action<TOutput> action);
```
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Tap(System.Action_TOutput_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute on the success value\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result unchanged\.