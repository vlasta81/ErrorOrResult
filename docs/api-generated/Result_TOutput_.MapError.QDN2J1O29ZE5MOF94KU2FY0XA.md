## Result\<TOutput\>\.MapError\(Func\<Error,Error\>\) Method

Transforms all errors in a result using the specified mapper function\.

```csharp
public ErrorOrResult.Result<TOutput> MapError(System.Func<ErrorOrResult.Error,ErrorOrResult.Error> mapper);
```
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.MapError(System.Func_ErrorOrResult.Error,ErrorOrResult.Error_).mapper'></a>

`mapper` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Error](Error.md 'ErrorOrResult\.Error')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function to transform each error\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The original result if successful, otherwise a result with transformed errors\.