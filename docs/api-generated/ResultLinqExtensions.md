## ResultLinqExtensions Class

Provides LINQ query syntax support for [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>') instances\.
Enables use of 'select' and 'from' expressions with results\.

```csharp
public static class ResultLinqExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ResultLinqExtensions

| Methods | |
| :--- | :--- |
| [Select&lt;TSource,TOutput&gt;\(this Result&lt;TSource&gt;, Func&lt;TSource,TOutput&gt;\)](ResultLinqExtensions.Select.EEAARHDZVFSWFT808U6U7EW7A.md 'ErrorOrResult\.ResultLinqExtensions\.Select\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,TOutput\>\)') | Projects the success value of a result using a selector function\. Supports LINQ 'select' syntax\. |
| [SelectMany&lt;TSource,TCollection,TOutput&gt;\(this Result&lt;TSource&gt;, Func&lt;TSource,Result&lt;TCollection&gt;&gt;, Func&lt;TSource,TCollection,TOutput&gt;\)](ResultLinqExtensions.SelectMany.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TCollection,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TCollection__,System.Func_TSource,TCollection,TOutput_) 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TCollection,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TCollection\>\>, System\.Func\<TSource,TCollection,TOutput\>\)') | Chains result operations together with a result selector\. Supports LINQ query syntax with multiple 'from' clauses\. |
| [SelectMany&lt;TSource,TOutput&gt;\(this Result&lt;TSource&gt;, Func&lt;TSource,Result&lt;TOutput&gt;&gt;\)](ResultLinqExtensions.SelectMany.md#ErrorOrResult.ResultLinqExtensions.SelectMany_TSource,TOutput_(thisErrorOrResult.Result_TSource_,System.Func_TSource,ErrorOrResult.Result_TOutput__) 'ErrorOrResult\.ResultLinqExtensions\.SelectMany\<TSource,TOutput\>\(this ErrorOrResult\.Result\<TSource\>, System\.Func\<TSource,ErrorOrResult\.Result\<TOutput\>\>\)') | Chains result operations together\. Supports LINQ 'from' syntax for flattening nested results\. |
