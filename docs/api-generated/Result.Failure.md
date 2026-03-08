#### [ErrorOrResult](index.md 'index')
### [ErrorOrResult](ErrorOrResult.md 'ErrorOrResult').[Result](Result.md 'ErrorOrResult\.Result')

## Result\.Failure Method

| Overloads | |
| :--- | :--- |
| [Failure\(Error\)](Result.Failure.md#ErrorOrResult.Result.Failure(ErrorOrResult.Error) 'ErrorOrResult\.Result\.Failure\(ErrorOrResult\.Error\)') | Creates a failed result with no value and a single error\. |
| [Failure\(ErrorInfo\)](Result.Failure.md#ErrorOrResult.Result.Failure(ErrorOrResult.ErrorInfo) 'ErrorOrResult\.Result\.Failure\(ErrorOrResult\.ErrorInfo\)') | Creates a failed result with no value and error information\. |
| [Failure\(Error\[\]\)](Result.Failure.md#ErrorOrResult.Result.Failure(ErrorOrResult.Error[]) 'ErrorOrResult\.Result\.Failure\(ErrorOrResult\.Error\[\]\)') | Creates a failed result with no value and an array of errors\. |
| [Failure\(List&lt;Error&gt;\)](Result.Failure.md#ErrorOrResult.Result.Failure(System.Collections.Generic.List_ErrorOrResult.Error_) 'ErrorOrResult\.Result\.Failure\(System\.Collections\.Generic\.List\<ErrorOrResult\.Error\>\)') | Creates a failed result with no value and a list of errors\. |
| [Failure&lt;TOutput&gt;\(Error\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.Error\)') | Creates a failed result with a single error\. |
| [Failure&lt;TOutput&gt;\(ErrorInfo\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.ErrorInfo) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.ErrorInfo\)') | Creates a failed result with error information\. |
| [Failure&lt;TOutput&gt;\(Error\[\]\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error[]) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.Error\[\]\)') | Creates a failed result with an array of errors\. |
| [Failure&lt;TOutput&gt;\(List&lt;Error&gt;\)](Result.Failure.md#ErrorOrResult.Result.Failure_TOutput_(System.Collections.Generic.List_ErrorOrResult.Error_) 'ErrorOrResult\.Result\.Failure\<TOutput\>\(System\.Collections\.Generic\.List\<ErrorOrResult\.Error\>\)') | Creates a failed result with a list of errors\. |

<a name='ErrorOrResult.Result.Failure(ErrorOrResult.Error)'></a>

## Result\.Failure\(Error\) Method

Creates a failed result with no value and a single error\.

```csharp
public static ErrorOrResult.Result<ErrorOrResult.None> Failure(ErrorOrResult.Error error);
```
#### Parameters

<a name='ErrorOrResult.Result.Failure(ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error that occurred\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[None](None.md 'ErrorOrResult\.None')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed result with no value\.

<a name='ErrorOrResult.Result.Failure(ErrorOrResult.ErrorInfo)'></a>

## Result\.Failure\(ErrorInfo\) Method

Creates a failed result with no value and error information\.

```csharp
public static ErrorOrResult.Result<ErrorOrResult.None> Failure(ErrorOrResult.ErrorInfo errorInfo);
```
#### Parameters

<a name='ErrorOrResult.Result.Failure(ErrorOrResult.ErrorInfo).errorInfo'></a>

`errorInfo` [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')

The error information\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[None](None.md 'ErrorOrResult\.None')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed result with no value\.

<a name='ErrorOrResult.Result.Failure(ErrorOrResult.Error[])'></a>

## Result\.Failure\(Error\[\]\) Method

Creates a failed result with no value and an array of errors\.

```csharp
public static ErrorOrResult.Result<ErrorOrResult.None> Failure(ErrorOrResult.Error[] errors);
```
#### Parameters

<a name='ErrorOrResult.Result.Failure(ErrorOrResult.Error[]).errors'></a>

`errors` [Error](Error.md 'ErrorOrResult\.Error')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors that occurred\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[None](None.md 'ErrorOrResult\.None')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed result with no value\.

<a name='ErrorOrResult.Result.Failure(System.Collections.Generic.List_ErrorOrResult.Error_)'></a>

## Result\.Failure\(List\<Error\>\) Method

Creates a failed result with no value and a list of errors\.

```csharp
public static ErrorOrResult.Result<ErrorOrResult.None> Failure(System.Collections.Generic.List<ErrorOrResult.Error> errors);
```
#### Parameters

<a name='ErrorOrResult.Result.Failure(System.Collections.Generic.List_ErrorOrResult.Error_).errors'></a>

`errors` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

The errors that occurred\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[None](None.md 'ErrorOrResult\.None')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed result with no value\.

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error)'></a>

## Result\.Failure\<TOutput\>\(Error\) Method

Creates a failed result with a single error\.

```csharp
public static ErrorOrResult.Result<TOutput> Failure<TOutput>(ErrorOrResult.Error error);
```
#### Type parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error).TOutput'></a>

`TOutput`

The type of the success value\.
#### Parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error).error'></a>

`error` [Error](Error.md 'ErrorOrResult\.Error')

The error that occurred\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error).TOutput 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.Error\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')\.

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.ErrorInfo)'></a>

## Result\.Failure\<TOutput\>\(ErrorInfo\) Method

Creates a failed result with error information\.

```csharp
public static ErrorOrResult.Result<TOutput> Failure<TOutput>(ErrorOrResult.ErrorInfo errorInfo);
```
#### Type parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.ErrorInfo).TOutput'></a>

`TOutput`

The type of the success value\.
#### Parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.ErrorInfo).errorInfo'></a>

`errorInfo` [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')

The error information\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.ErrorInfo).TOutput 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.ErrorInfo\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')\.

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error[])'></a>

## Result\.Failure\<TOutput\>\(Error\[\]\) Method

Creates a failed result with an array of errors\.

```csharp
public static ErrorOrResult.Result<TOutput> Failure<TOutput>(ErrorOrResult.Error[] errors);
```
#### Type parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error[]).TOutput'></a>

`TOutput`

The type of the success value\.
#### Parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error[]).errors'></a>

`errors` [Error](Error.md 'ErrorOrResult\.Error')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The errors that occurred\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.md#ErrorOrResult.Result.Failure_TOutput_(ErrorOrResult.Error[]).TOutput 'ErrorOrResult\.Result\.Failure\<TOutput\>\(ErrorOrResult\.Error\[\]\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')\.

<a name='ErrorOrResult.Result.Failure_TOutput_(System.Collections.Generic.List_ErrorOrResult.Error_)'></a>

## Result\.Failure\<TOutput\>\(List\<Error\>\) Method

Creates a failed result with a list of errors\.

```csharp
public static ErrorOrResult.Result<TOutput> Failure<TOutput>(System.Collections.Generic.List<ErrorOrResult.Error> errors);
```
#### Type parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(System.Collections.Generic.List_ErrorOrResult.Error_).TOutput'></a>

`TOutput`

The type of the success value\.
#### Parameters

<a name='ErrorOrResult.Result.Failure_TOutput_(System.Collections.Generic.List_ErrorOrResult.Error_).errors'></a>

`errors` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

The errors that occurred\.

#### Returns
[ErrorOrResult\.Result&lt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')[TOutput](Result.md#ErrorOrResult.Result.Failure_TOutput_(System.Collections.Generic.List_ErrorOrResult.Error_).TOutput 'ErrorOrResult\.Result\.Failure\<TOutput\>\(System\.Collections\.Generic\.List\<ErrorOrResult\.Error\>\)\.TOutput')[&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')  
A failed [Result&lt;TOutput&gt;](Result_TOutput_.md 'ErrorOrResult\.Result\<TOutput\>')\.

---
Generated by [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation 'https://github\.com/Doraku/DefaultDocumentation')