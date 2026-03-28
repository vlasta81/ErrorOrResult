## Result\<TOutput\>\.Combine\<TOther\>\(Result\<TOther\>\) Method

Combines this result with another result into a single result containing a tuple of both values\.
If either result is in error state, all errors are combined\.

```csharp
public ErrorOrResult.Result<(TOutput,TOther)> Combine<TOther>(ErrorOrResult.Result<TOther> other);
```
#### Type parameters

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).TOther'></a>

`TOther`

The type of the other result value\.
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).other'></a>

`other` [ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOther](Result_TOutput_.Combine.KHJMMOA058HTTE1VHM3AYNIY8.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).TOther 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)\.TOther')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')

The other result to combine with\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')[,](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[TOther](Result_TOutput_.Combine.KHJMMOA058HTTE1VHM3AYNIY8.md#ErrorOrResult.Result_TOutput_.Combine_TOther_(ErrorOrResult.Result_TOther_).TOther 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)\.TOther')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.valuetuple 'System\.ValueTuple')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A result containing a tuple of both values if both are successful, otherwise a combined error result\.