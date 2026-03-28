## Result\<TOutput\>\.ThrowOnError\(\) Method

Throws an exception if the result is in error state, otherwise returns the success value\.

```csharp
public TOutput ThrowOnError();
```

#### Returns
[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')  
The success value if the result is successful\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in error state\.