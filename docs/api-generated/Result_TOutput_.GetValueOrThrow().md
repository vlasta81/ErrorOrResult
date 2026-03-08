## Result\<TOutput\>\.GetValueOrThrow\(\) Method

Gets the success value or throws an exception if the result is in an error state\.

```csharp
public TOutput GetValueOrThrow();
```

#### Returns
[TOutput](Result_TOutput_.md#ErrorOrResult.Result_TOutput_.TOutput 'ErrorOrResult\.Result\<TOutput\>\.TOutput')  
The success value\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown when the result is in an error state\.