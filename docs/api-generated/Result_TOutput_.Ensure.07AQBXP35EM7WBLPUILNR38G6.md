## Result\<TOutput\>\.Ensure\(Func\<TOutput,bool\>, Error\) Method

Validates the success value using a predicate\. If the predicate fails, converts to an error result\.

```csharp
public ErrorOrResult.Result<TOutput> Ensure(System.Func<TOutput,bool> predicate, ErrorOrResult.Error error);
```
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Ensure(System.Func_TOutput,bool_,ErrorOrResult.Error).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The predicate to test the success value against\.

<a name='ErrorOrResult.Result_TOutput_.Ensure(System.Func_TOutput,bool_,ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error to use if the predicate fails\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result if successful and predicate passes, otherwise a failed result\.