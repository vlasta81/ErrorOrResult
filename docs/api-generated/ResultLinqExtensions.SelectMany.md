#### [ErrorOrResult](index.md 'index')
### [ErrorOrResult](ErrorOrResult.md 'ErrorOrResult').[ResultLinqExtensions](ResultLinqExtensions.md 'ErrorOrResult\.ResultLinqExtensions')

## ResultLinqExtensions\.SelectMany Method

| Overloads | |
| :--- | :--- |
| [SelectMany&lt;TSource,TCollection,TOutput&gt;\(this Result&lt;TSource&gt;, Func&lt;TSource,Result&lt;TCollection&gt;&gt;, Func&lt;TSource,TCollection,TOutput&gt;\)](ResultLinqExtensions.SelectMany.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_) 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)') | Chains result operations together with a result selector\. Supports LINQ query syntax with multiple 'from' clauses\. |
| [SelectMany&lt;TSource,TOutput&gt;\(this Result&lt;TSource&gt;, Func&lt;TSource,Result&lt;TOutput&gt;&gt;\)](ResultLinqExtensions.SelectMany.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__) 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TOutput\>\>\)') | Chains result operations together\. Supports LINQ 'from' syntax for flattening nested results\. |

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_)'></a>

## ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this Result\<TSource\>, Func\<TSource,Result\<TCollection\>\>, Func\<TSource,TCollection,TOutput\>\) Method

Chains result operations together with a result selector\.
Supports LINQ query syntax with multiple 'from' clauses\.

```csharp
public static ErrorOrResult.Result<TOutput> SelectMany<TSource,TCollection,TOutput>(this ErrorOrResult.Result<TSource> source, System.Func<TSource,ErrorOrResult.Result<TCollection>> collectionSelector, System.Func<TSource,TCollection,TOutput> resultSelector);
```
#### Type parameters

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TSource'></a>

`TSource`

The type of the source result value\.

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TCollection'></a>

`TCollection`

The type of the intermediate collection result value\.

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TOutput'></a>

`TOutput`

The type of the final output value\.
#### Parameters

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).source'></a>

`source` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TSource](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TSource 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)\.TSource')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The source result\.

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).collectionSelector'></a>

`collectionSelector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TSource](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TSource 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)\.TSource')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TCollection](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TCollection 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)\.TCollection')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function that returns an intermediate result\.

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).resultSelector'></a>

`resultSelector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TSource](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TSource 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)\.TSource')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TCollection](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TCollection 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)\.TCollection')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TOutput](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TOutput 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)\.TOutput')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

The function that combines source and collection values\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_).TOutput 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result with the combined value or the first encountered error\.

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__)'></a>

## ResultLinqExtensions\.SelectMany\<TSource,TOutput\>\(this Result\<TSource\>, Func\<TSource,Result\<TOutput\>\>\) Method

Chains result operations together\.
Supports LINQ 'from' syntax for flattening nested results\.

```csharp
public static ErrorOrResult.Result<TOutput> SelectMany<TSource,TOutput>(this ErrorOrResult.Result<TSource> source, System.Func<TSource,ErrorOrResult.Result<TOutput>> selector);
```
#### Type parameters

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).TSource'></a>

`TSource`

The type of the source result value\.

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).TOutput'></a>

`TOutput`

The type of the output result value\.
#### Parameters

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).source'></a>

`source` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TSource](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).TSource 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TOutput\>\>\)\.TSource')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The source result\.

<a name='ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).selector'></a>

`selector` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TSource](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).TSource 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TOutput\>\>\)\.TSource')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

The function that returns a new result\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](ResultLinqExtensions.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__).TOutput 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TOutput\>\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
The result returned by the selector or the original error\.

---
Generated by [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation 'https://github\.com/Doraku/DefaultDocumentation')