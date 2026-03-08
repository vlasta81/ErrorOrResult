## ResultExtensions\.ThrowOnError\<TOutput\>\(this Result\<TOutput\>\) Method

Throws an exception if the result is in error state, otherwise returns the success value\.

```csharp
public static TOutput ThrowOnError<TOutput>(this ErrorOrResult.Result<TOutput> result);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.ThrowOnError_TOutput_(thisErrorOrResult.Result_TOutput_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.ThrowOnError_TOutput_(thisErrorOrResult.Result_TOutput_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.ThrowOnError.RKOPO0DQVV82KIP9XAEFVZRR5.md#ErrorOrResult.ResultExtensions.ThrowOnError_TOutput_(thisErrorOrResult.Result_TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.ThrowOnError\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result to check\.

#### Returns
[TOutput](ResultExtensions.ThrowOnError.RKOPO0DQVV82KIP9XAEFVZRR5.md#ErrorOrResult.ResultExtensions.ThrowOnError_TOutput_(thisErrorOrResult.Result_TOutput_).TOutput 'ErrorOrResult\.ResultExtensions\.ThrowOnError\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>\)\.TOutput')  
The success value if the result is successful\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.