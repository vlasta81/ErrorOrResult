## ResultExtensions\.Tap\<TOutput\>\(this Result\<TOutput\>, Action\<TOutput\>\) Method

Executes a side\-effect action on the success value without modifying the result\.
Useful for logging or other side effects\.

```csharp
public static ErrorOrResult.Result<TOutput> Tap<TOutput>(this ErrorOrResult.Result<TOutput> result, System.Action<TOutput> action);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.Tap_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.Tap_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Tap.TQHYW55JPJQAOFUKRV6GY1SGB.md#ErrorOrResult.ResultExtensions.Tap_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Tap\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Action\<TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to tap\.

<a name='ErrorOrResult.ResultExtensions.Tap_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_).action'></a>

`action` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[TOutput](ResultExtensions.Tap.TQHYW55JPJQAOFUKRV6GY1SGB.md#ErrorOrResult.ResultExtensions.Tap_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Tap\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Action\<TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

The action to execute on the success value\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.Tap.TQHYW55JPJQAOFUKRV6GY1SGB.md#ErrorOrResult.ResultExtensions.Tap_TOutput_(thisErrorOrResult.Result_TOutput_,System.Action_TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.Tap\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Action\<TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result unchanged\.