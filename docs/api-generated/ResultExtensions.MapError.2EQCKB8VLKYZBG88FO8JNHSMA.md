## ResultExtensions\.MapError\<TOutput\>\(this Result\<TOutput\>, Func\<Error,Error\>\) Method

Transforms all errors in a result using the specified mapper function\.

```csharp
public static ErrorOrResult.Result<TOutput> MapError<TOutput>(this ErrorOrResult.Result<TOutput> result, System.Func<ErrorOrResult.Error,ErrorOrResult.Error> mapper);
```
#### Type parameters

<a name='ErrorOrResult.ResultExtensions.MapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_ErrorOrResult.Error,ErrorOrResult.Error_).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.ResultExtensions.MapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_ErrorOrResult.Error,ErrorOrResult.Error_).result'></a>

`result` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.MapError.2EQCKB8VLKYZBG88FO8JNHSMA.md#ErrorOrResult.ResultExtensions.MapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_ErrorOrResult.Error,ErrorOrResult.Error_).TOutput 'ErrorOrResult\.ResultExtensions\.MapError\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<ErrorOrResult\.Error,ErrorOrResult\.Error\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The result whose errors to transform\.

<a name='ErrorOrResult.ResultExtensions.MapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_ErrorOrResult.Error,ErrorOrResult.Error_).mapper'></a>

`mapper` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Error](Error.md 'ErrorOrResult\.Error')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to transform each error\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultExtensions.MapError.2EQCKB8VLKYZBG88FO8JNHSMA.md#ErrorOrResult.ResultExtensions.MapError_TOutput_(thisErrorOrResult.Result_TOutput_,System.Func_ErrorOrResult.Error,ErrorOrResult.Error_).TOutput 'ErrorOrResult\.ResultExtensions\.MapError\<TOutput\>\(this ErrorOrResult\.Result\<TOutput\>, System\.Func\<ErrorOrResult\.Error,ErrorOrResult\.Error\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result if successful, otherwise a result with transformed errors\.