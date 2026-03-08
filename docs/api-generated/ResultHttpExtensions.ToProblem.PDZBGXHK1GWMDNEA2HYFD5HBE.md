## ResultHttpExtensions\.ToProblem\(this ErrorInfo\) Method

Converts error information to a Problem Details \(RFC 7807\) HTTP response\.
Maps error types to appropriate HTTP status codes\.

```csharp
public static Microsoft.AspNetCore.Http.IResult ToProblem(this ErrorOrResult.ErrorInfo errorInfo);
```
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToProblem(thisErrorOrResult.ErrorInfo).errorInfo'></a>

`errorInfo` [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')

The error information to convert\.

#### Returns
[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')  
An [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') representing a problem details response\.