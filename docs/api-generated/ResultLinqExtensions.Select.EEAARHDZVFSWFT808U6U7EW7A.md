## ResultLinqExtensions\.Select\<TSource,TOutput\>\(this Result\<TSource\>, Func\<TSource,TOutput\>\) Method

Projects the success value of a result using a selector function\.
Supports LINQ 'select' syntax\.

```csharp
public static ErrorOrResult.Result<TOutput> Select<TSource,TOutput>(this ErrorOrResult.Result<TSource> source, System.Func<TSource,TOutput> selector);
```
#### Type parameters

<a name='ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).TSource'></a>

`TSource`

The type of the source result value\.

<a name='ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).TOutput'></a>

`TOutput`

The type of the projected value\.
#### Parameters

<a name='ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).source'></a>

`source` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TSource](ResultLinqExtensions.Select.EEAARHDZVFSWFT808U6U7EW7A.md#ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).TSource 'ErrorOrResult\.ResultLinqExtensions\.Select\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,TOutput\>\)\.TSource')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The source result\.

<a name='ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).selector'></a>

`selector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TSource](ResultLinqExtensions.Select.EEAARHDZVFSWFT808U6U7EW7A.md#ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).TSource 'ErrorOrResult\.ResultLinqExtensions\.Select\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,TOutput\>\)\.TSource')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TOutput](ResultLinqExtensions.Select.EEAARHDZVFSWFT808U6U7EW7A.md#ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).TOutput 'ErrorOrResult\.ResultLinqExtensions\.Select\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The projection function\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultLinqExtensions.Select.EEAARHDZVFSWFT808U6U7EW7A.md#ErrorOrResult.ResultLinqExtensions.Select_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,TOutput_).TOutput 'ErrorOrResult\.ResultLinqExtensions\.Select\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result with the projected value or the original error\.