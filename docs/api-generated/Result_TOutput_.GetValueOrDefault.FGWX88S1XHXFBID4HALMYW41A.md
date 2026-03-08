## Result\<TOutput\>\.GetValueOrDefault\(TOutput\) Method

Gets the success value or returns the specified default value if the result is in an error state\.

```csharp
public TOutput GetValueOrDefault(TOutput defaultValue=default(TOutput));
```
#### Parameters

<a name='ErrorOrResult.Result_TOutput_.GetValueOrDefault(TOutput).defaultValue'></a>

`defaultValue` [TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')

The default value to return if in error state\.

#### Returns
[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')  
The success value or the default value\.