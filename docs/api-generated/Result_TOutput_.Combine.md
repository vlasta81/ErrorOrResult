#### [ErrorOrResult](index.md 'index')
### [ErrorOrResult](ErrorOrResult.md 'ErrorOrResult').[Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

## Result\<TOutput\>\.Combine Method

| Overloads | |
| :--- | :--- |
| [Combine&lt;TOther&gt;\(Result&lt;TOther&gt;\)](Result_TOutput_.Combine.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_) 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)') | Combines this result with another result into a single result containing a tuple of both values\. If either result is in error state, all errors are combined \(errors from `this` first, then from [other](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).other 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)\.other')\)\. |
| [Combine&lt;TOther&gt;\(Result&lt;TOther&gt;, IComparer&lt;Error&gt;\)](Result_TOutput_.Combine.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_) 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>, System\.Collections\.Generic\.IComparer\<ErrorOrResult\.Error\>\)') | Combines this result with another result into a single result containing a tuple of both values, optionally reordering combined errors using the specified comparer\. |

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_)'></a>

## Result\<TOutput\>\.Combine\<TOther\>\(Result\<TOther\>\) Method

Combines this result with another result into a single result containing a tuple of both values\.
If either result is in error state, all errors are combined \(errors from `this` first, then from [other](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).other 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)\.other')\)\.

```csharp
public ErrorOrResult.Result<(TOutput,TOther)> Combine<TOther>(ErrorOrResult.Result<TOther> other);
```
#### Type parameters

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).TOther'></a>

`TOther`

The type of the other result value\.
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).other'></a>

`other` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOther](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).TOther 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)\.TOther')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The other result to combine with\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOther](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).TOther 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)\.TOther')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result containing a tuple of both values if both are successful, otherwise a combined error result\.

### Remarks
Errors are concatenated in the order of operands\. The first error determines the resulting HTTP status code
when converted via `ToProblem`\. If different [ErrorType](ErrorType.md 'ErrorOrResult\.ErrorType') values are combined, callers should
be aware that the representative type is `FirstError.Type`\.

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_)'></a>

## Result\<TOutput\>\.Combine\<TOther\>\(Result\<TOther\>, IComparer\<Error\>\) Method

Combines this result with another result into a single result containing a tuple of both values,
optionally reordering combined errors using the specified comparer\.

```csharp
public ErrorOrResult.Result<(TOutput,TOther)> Combine<TOther>(ErrorOrResult.Result<TOther> other, System.Collections.Generic.IComparer<ErrorOrResult.Error>? errorComparer);
```
#### Type parameters

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_).TOther'></a>

`TOther`

The type of the other result value\.
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_).other'></a>

`other` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOther](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_).TOther 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>, System\.Collections\.Generic\.IComparer\<ErrorOrResult\.Error\>\)\.TOther')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The other result to combine with\.

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_).errorComparer'></a>

`errorComparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

Optional comparer used to stable\-sort combined errors\. When `null`, operand order is preserved\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOther](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_).TOther 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>, System\.Collections\.Generic\.IComparer\<ErrorOrResult\.Error\>\)\.TOther')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result containing a tuple of both values if both are successful, otherwise a combined error result\.

### Remarks
When [errorComparer](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_).errorComparer 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>, System\.Collections\.Generic\.IComparer\<ErrorOrResult\.Error\>\)\.errorComparer') is `null`, behaves identically to [Combine&lt;TOther&gt;\(Result&lt;TOther&gt;\)](Result_TOutput_.Combine.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_) 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)')
\(errors from `this` first, then from [other](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_,System.Collections.Generic.IComparer_ErrorOrResult.Error_).other 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>, System\.Collections\.Generic\.IComparer\<ErrorOrResult\.Error\>\)\.other')\)\. When a comparer is supplied, errors are
stable\-sorted by it — useful for placing the most actionable error first \(e\.g\. [BySeverityDescending](ErrorComparers.BySeverityDescending.md 'ErrorOrResult\.ErrorComparers\.BySeverityDescending')\),
which then determines the HTTP status code produced by `ToProblem`\.

---
Generated by [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation 'https://github\.com/Doraku/DefaultDocumentation')