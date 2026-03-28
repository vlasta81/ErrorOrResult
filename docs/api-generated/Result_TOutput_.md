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
| [Bind&lt;TResult&gt;\(Func&lt;TOutput,Result&lt;TResult&gt;&gt;\)](Result_TOutput_.Bind.N8RZNUZ5VSZM0NWXH9RH8X4L3.md 'ErrorOrResult\.Result\<TOutput\>\.Bind\<TResult\>\(System\.Func\<TOutput,ErrorOrResult\.Result\<TResult\>\>\)') | Chains a result with another operation that returns a result \(flatMap/bind operation\)\. If the first result is in error state, the error is propagated without executing the binder\. |
| [Combine&lt;TOther&gt;\(Result&lt;TOther&gt;\)](Result_TOutput_.Combine.KHJMMOA058HTTE1VHM3AYNIY8.md 'ErrorOrResult\.Result\<TOutput\>\.Combine\<TOther\>\(ErrorOrResult\.Result\<TOther\>\)') | Combines this result with another result into a single result containing a tuple of both values\. If either result is in error state, all errors are combined\. |
| [Ensure\(Func&lt;TOutput,bool&gt;, Error\)](Result_TOutput_.Ensure.07AQBXP35EM7WBLPUILNR38G6.md 'ErrorOrResult\.Result\<TOutput\>\.Ensure\(System\.Func\<TOutput,bool\>, ErrorOrResult\.Error\)') | Validates the success value using a predicate\. If the predicate fails, converts to an error result\. |
| [Failure\(ErrorInfo\)](Result_TOutput_.Failure.md#ErrorOrResult.Result_TOutput_.Failure(ErrorOrResult.ErrorInfo) 'ErrorOrResult\.Result\<TOutput\>\.Failure\(ErrorOrResult\.ErrorInfo\)') | Creates a failed result with the specified error information\. |
| [Failure\(ReadOnlySpan&lt;Error&gt;\)](Result_TOutput_.Failure.md#ErrorOrResult.Result_TOutput_.Failure(System.ReadOnlySpan_ErrorOrResult.Error_) 'ErrorOrResult\.Result\<TOutput\>\.Failure\(System\.ReadOnlySpan\<ErrorOrResult\.Error\>\)') | Creates a failed result with the specified errors\. |
| [GetValueOrDefault\(TOutput\)](Result_TOutput_.GetValueOrDefault.FGWX88S1XHXFBID4HALMYW41A.md 'ErrorOrResult\.Result\<TOutput\>\.GetValueOrDefault\(TOutput\)') | Gets the success value or returns the specified default value if the result is in an error state\. |
| [GetValueOrThrow\(\)](Result_TOutput_.GetValueOrThrow().md 'ErrorOrResult\.Result\<TOutput\>\.GetValueOrThrow\(\)') | Gets the success value or throws an exception if the result is in an error state\. |
| [Map&lt;TResult&gt;\(Func&lt;TOutput,TResult&gt;\)](Result_TOutput_.Map.F8O6RAW33TJ1Q4SER87CLGRB3.md 'ErrorOrResult\.Result\<TOutput\>\.Map\<TResult\>\(System\.Func\<TOutput,TResult\>\)') | Maps the success value of a result to a new value using the specified selector function\. If the result is in error state, the error is propagated\. |
| [MapError\(Func&lt;Error,Error&gt;\)](Result_TOutput_.MapError.QDN2J1O29ZE5MOF94KU2FY0XA.md 'ErrorOrResult\.Result\<TOutput\>\.MapError\(System\.Func\<ErrorOrResult\.Error,ErrorOrResult\.Error\>\)') | Transforms all errors in a result using the specified mapper function\. |
| [Match&lt;TResult&gt;\(Func&lt;TOutput,TResult&gt;, Func&lt;ErrorInfo,TResult&gt;\)](Result_TOutput_.Match.LG1M686TC91EMIGPTSFLUPDD2.md 'ErrorOrResult\.Result\<TOutput\>\.Match\<TResult\>\(System\.Func\<TOutput,TResult\>, System\.Func\<ErrorOrResult\.ErrorInfo,TResult\>\)') | Pattern matches on the result, executing one of two functions based on success or error state\. |
| [Success\(TOutput\)](Result_TOutput_.Success.2SOBMBHSXAP5U3MEMXM7XOBV8.md 'ErrorOrResult\.Result\<TOutput\>\.Success\(TOutput\)') | Creates a successful result with the specified value\. |
| [Switch\(Action&lt;TOutput&gt;, Action&lt;ErrorInfo&gt;\)](Result_TOutput_.Switch.2QF0XVVXYOCRF9L31O3D2POB3.md 'ErrorOrResult\.Result\<TOutput\>\.Switch\(System\.Action\<TOutput\>, System\.Action\<ErrorOrResult\.ErrorInfo\>\)') | Executes one of two actions based on whether the result is successful or in error state\. Similar to Match but returns void\. |
| [Tap\(Action&lt;TOutput&gt;\)](Result_TOutput_.Tap.BNS6NMERZGIR64EOHSODSDNH2.md 'ErrorOrResult\.Result\<TOutput\>\.Tap\(System\.Action\<TOutput\>\)') | Executes a side\-effect action on the success value without modifying the result\. Useful for logging or other side effects\. |
| [TapError\(Action&lt;ErrorInfo&gt;\)](Result_TOutput_.TapError.T02L1CYEGSTZX1JU5M15O38AB.md 'ErrorOrResult\.Result\<TOutput\>\.TapError\(System\.Action\<ErrorOrResult\.ErrorInfo\>\)') | Executes a side\-effect action on the error information without modifying the result\. Useful for logging errors\. |
| [ThrowOnError\(\)](Result_TOutput_.ThrowOnError().md 'ErrorOrResult\.Result\<TOutput\>\.ThrowOnError\(\)') | Throws an exception if the result is in error state, otherwise returns the success value\. |
| [ToString\(\)](Result_TOutput_.ToString().md 'ErrorOrResult\.Result\<TOutput\>\.ToString\(\)') | Returns a string representation of the result\. |

| Operators | |
| :--- | :--- |
| [implicit operator Result&lt;TOutput&gt;\(Error\)](Result_TOutput_.op_Implicit.4OK2ARVY8TWAHM3R2I6SPD6PC.md 'ErrorOrResult\.Result\<TOutput\>\.op\_Implicit ErrorOrResult\.Result\<TOutput\>\(ErrorOrResult\.Error\)') | Implicitly converts an error to a failed result\. |
| [implicit operator Result&lt;TOutput&gt;\(ErrorInfo\)](Result_TOutput_.op_Implicit.T0VQKTQMRX0236CWTFKDMY9S6.md 'ErrorOrResult\.Result\<TOutput\>\.op\_Implicit ErrorOrResult\.Result\<TOutput\>\(ErrorOrResult\.ErrorInfo\)') | Implicitly converts error information to a failed result\. |
| [implicit operator Result&lt;TOutput&gt;\(TOutput\)](Result_TOutput_.op_Implicit.YWIU07HKNZM5HHVDURW1KL0T3.md 'ErrorOrResult\.Result\<TOutput\>\.op\_Implicit ErrorOrResult\.Result\<TOutput\>\(TOutput\)') | Implicitly converts a value to a successful result\. |
