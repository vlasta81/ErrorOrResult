## Result\.Ensure\<TOutput\>\(TOutput, Func\<TOutput,bool\>, Error\) Method

Creates a result based on a predicate check\.

```csharp
public static ErrorOrResult.Result<TOutput> Ensure<TOutput>(TOutput value, System.Func<TOutput,bool> predicate, ErrorOrResult.Error error);
```
#### Type parameters

<a name='ErrorOrResult.Result.Ensure_TOutput_(TOutput,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput'></a>

`TOutput`

The type of the value\.
#### Parameters

<a name='ErrorOrResult.Result.Ensure_TOutput_(TOutput,System.Func_TOutput,bool_,ErrorOrResult.Error).value'></a>

`value` [TOutput](Result.Ensure.PDSAUZYTSY5BGDQ5WQARZU1VC.md#ErrorOrResult.Result.Ensure_TOutput_(TOutput,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.Result\.Ensure\<TOutput\>\(TOutput, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')

The value to check\.

<a name='ErrorOrResult.Result.Ensure_TOutput_(TOutput,System.Func_TOutput,bool_,ErrorOrResult.Error).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](Result.Ensure.PDSAUZYTSY5BGDQ5WQARZU1VC.md#ErrorOrResult.Result.Ensure_TOutput_(TOutput,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.Result\.Ensure\<TOutput\>\(TOutput, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The predicate to test the value against\.

<a name='ErrorOrResult.Result.Ensure_TOutput_(TOutput,System.Func_TOutput,bool_,ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error to use if the predicate fails\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.Ensure.PDSAUZYTSY5BGDQ5WQARZU1VC.md#ErrorOrResult.Result.Ensure_TOutput_(TOutput,System.Func_TOutput,bool_,ErrorOrResult.Error).TOutput 'ErrorOrResult\.Result\.Ensure\<TOutput\>\(TOutput, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A successful result if the predicate passes, otherwise a failed result\.