## Result\.Of\<TOutput\>\(Func\<Result\<TOutput\>\>\) Method

Executes a function that returns a result\.

```csharp
public static ErrorOrResult.Result<TOutput> Of<TOutput>(System.Func<ErrorOrResult.Result<TOutput>> func);
```
#### Type parameters

<a name='ErrorOrResult.Result.Of_TOutput_(System.Func_ErrorOrResult.Result_TOutput__).TOutput'></a>

`TOutput`

The type of the result value\.
#### Parameters

<a name='ErrorOrResult.Result.Of_TOutput_(System.Func_ErrorOrResult.Result_TOutput__).func'></a>

`func` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.Of.6OZR9VPKH8BG1OOM1EUMXSR0D.md#ErrorOrResult.Result.Of_TOutput_(System.Func_ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.Result\.Of\<TOutput\>\(System\.Func\<ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The function to execute\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.Of.6OZR9VPKH8BG1OOM1EUMXSR0D.md#ErrorOrResult.Result.Of_TOutput_(System.Func_ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.Result\.Of\<TOutput\>\(System\.Func\<ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The result returned by the function\.