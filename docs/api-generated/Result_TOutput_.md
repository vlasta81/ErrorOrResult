## Result\<TOutput\> Struct

Represents the result of an operation that can either succeed with a value or fail with error information\.

```csharp
public readonly struct Result<TOutput>
```
#### Type parameters

<a name='ErrorOrResult.Result_TOutput_.TOutput'></a>

`TOutput`

The type of the success value\.

| Properties | |
| :--- | :--- |
| [Error](Result_TOutput_.Error.md 'ErrorOrResult\.Result\<TOutput\>\.Error') | Gets the first error\. Throws an exception if the result is in a success state\. |
| [ErrorInfo](Result_TOutput_.ErrorInfo.md 'ErrorOrResult\.Result\<TOutput\>\.ErrorInfo') | Gets the error information\. Throws an exception if the result is in a success state\. |
| [Errors](Result_TOutput_.Errors.md 'ErrorOrResult\.Result\<TOutput\>\.Errors') | Gets all errors as an immutable array\. Throws an exception if the result is in a success state\. |
| [IsError](Result_TOutput_.IsError.md 'ErrorOrResult\.Result\<TOutput\>\.IsError') | Gets a value indicating whether the result represents a failed operation\. |
| [IsSuccess](Result_TOutput_.IsSuccess.md 'ErrorOrResult\.Result\<TOutput\>\.IsSuccess') | Gets a value indicating whether the result represents a successful operation\. |
| [Value](Result_TOutput_.Value.md 'ErrorOrResult\.Result\<TOutput\>\.Value') | Gets the success value\. Throws an exception if the result is in an error state\. |

| Methods | |
| :--- | :--- |
| [Failure\(ErrorInfo\)](Result_TOutput_.Failure.md#ErrorOrResult.Result_TOutput_.Failure(ErrorOrResult.ErrorInfo) 'ErrorOrResult\.Result\<TOutput\>\.Failure\(ErrorOrResult\.ErrorInfo\)') | Creates a failed result with the specified error information\. |
| [Failure\(ReadOnlySpan&lt;Error&gt;\)](Result_TOutput_.Failure.md#ErrorOrResult.Result_TOutput_.Failure(System.ReadOnlySpan_ErrorOrResult.Error_) 'ErrorOrResult\.Result\<TOutput\>\.Failure\(System\.ReadOnlySpan\<ErrorOrResult\.Error\>\)') | Creates a failed result with the specified errors\. |
| [GetValueOrDefault\(TOutput\)](Result_TOutput_.GetValueOrDefault.FGWX88S1XHXFBID4HALMYW41A.md 'ErrorOrResult\.Result\<TOutput\>\.GetValueOrDefault\(TOutput\)') | Gets the success value or returns the specified default value if the result is in an error state\. |
| [GetValueOrThrow\(\)](Result_TOutput_.GetValueOrThrow().md 'ErrorOrResult\.Result\<TOutput\>\.GetValueOrThrow\(\)') | Gets the success value or throws an exception if the result is in an error state\. |
| [Success\(TOutput\)](Result_TOutput_.Success.2SOBMBHSXAP5U3MEMXM7XOBV8.md 'ErrorOrResult\.Result\<TOutput\>\.Success\(TOutput\)') | Creates a successful result with the specified value\. |
| [ToString\(\)](Result_TOutput_.ToString().md 'ErrorOrResult\.Result\<TOutput\>\.ToString\(\)') | Returns a string representation of the result\. |

| Operators | |
| :--- | :--- |
| [implicit operator Result&lt;TOutput&gt;\(Error\)](Result_TOutput_.op_Implicit.4OK2ARVY8TWAHM3R2I6SPD6PC.md 'ErrorOrResult\.Result\<TOutput\>\.op\_Implicit ErrorOrResult\.Result\<TOutput\>\(ErrorOrResult\.Error\)') | Implicitly converts an error to a failed result\. |
| [implicit operator Result&lt;TOutput&gt;\(ErrorInfo\)](Result_TOutput_.op_Implicit.T0VQKTQMRX0236CWTFKDMY9S6.md 'ErrorOrResult\.Result\<TOutput\>\.op\_Implicit ErrorOrResult\.Result\<TOutput\>\(ErrorOrResult\.ErrorInfo\)') | Implicitly converts error information to a failed result\. |
| [implicit operator Result&lt;TOutput&gt;\(TOutput\)](Result_TOutput_.op_Implicit.YWIU07HKNZM5HHVDURW1KL0T3.md 'ErrorOrResult\.Result\<TOutput\>\.op\_Implicit ErrorOrResult\.Result\<TOutput\>\(TOutput\)') | Implicitly converts a value to a successful result\. |
