## ResultExtensions Class

Provides async extension methods for working with [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>') instances\.
These methods operate on Task\<Result\<T\>\> and should be used for asynchronous operations\.

```csharp
public static class ResultExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ResultExtensions

| Methods | |
| :--- | :--- |
| [BindAsync&lt;TInput,TOutput&gt;\(this Task&lt;Result&lt;TInput&gt;&gt;, Func&lt;TInput,Task&lt;Result&lt;TOutput&gt;&gt;&gt;\)](ResultExtensions.BindAsync.9XXYYKAPIOKS6HVFZ4G6XC2H1.md 'ErrorOrResult\.ResultExtensions\.BindAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\>\)') | Asynchronously chains a result with another asynchronous operation that returns a result\. |
| [EnsureAsync&lt;TOutput&gt;\(this Task&lt;Result&lt;TOutput&gt;&gt;, Func&lt;TOutput,bool&gt;, Error\)](ResultExtensions.EnsureAsync.CMOWCSPCH8DG8TLAV4NY6IHH2.md 'ErrorOrResult\.ResultExtensions\.EnsureAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)') | Asynchronously validates the success value using a predicate\. |
| [MapAsync&lt;TInput,TOutput&gt;\(this Task&lt;Result&lt;TInput&gt;&gt;, Func&lt;TInput,TOutput&gt;\)](ResultExtensions.MapAsync.7C12ZWE16JV9YIEKL9FCSZMK5.md 'ErrorOrResult\.ResultExtensions\.MapAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>\)') | Asynchronously maps the success value of a result to a new value using the specified selector function\. |
| [MatchAsync&lt;TInput,TOutput&gt;\(this Task&lt;Result&lt;TInput&gt;&gt;, Func&lt;TInput,TOutput&gt;, Func&lt;ErrorInfo,TOutput&gt;\)](ResultExtensions.MatchAsync.TA88DFDTBKY4ZV0BHVJAWPPF6.md 'ErrorOrResult\.ResultExtensions\.MatchAsync\<TInput,TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TInput\>\>, System\.Func\<TInput,TOutput\>, System\.Func\<ErrorOrResult\.ErrorInfo,TOutput\>\)') | Asynchronously pattern matches on a result\. |
| [TapAsync&lt;TOutput&gt;\(this Task&lt;Result&lt;TOutput&gt;&gt;, Func&lt;TOutput,Task&gt;\)](ResultExtensions.TapAsync.V8KT2PF87U7VYS82MBE3YMNHE.md 'ErrorOrResult\.ResultExtensions\.TapAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>, System\.Func\<TOutput,System\.Threading\.Tasks\.Task\>\)') | Asynchronously executes a side\-effect action on the success value without modifying the result\. |
| [ThrowOnErrorAsync&lt;TOutput&gt;\(this Task&lt;Result&lt;TOutput&gt;&gt;\)](ResultExtensions.ThrowOnErrorAsync.N2BT5J95XF2E2H7IUIF38K6G1.md 'ErrorOrResult\.ResultExtensions\.ThrowOnErrorAsync\<TOutput\>\(this System\.Threading\.Tasks\.Task\<ErrorOrResult\.Result\<TOutput\>\>\)') | Asynchronously throws an exception if the result is in error state, otherwise returns the success value\. |
