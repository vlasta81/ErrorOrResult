## ResultHttpExtensions\.ToValidationProblem\(this ErrorInfo\) Method

Converts error information to a validation problem details response \(HTTP 422\)\.
Groups errors by their code\.

```csharp
public static Microsoft.AspNetCore.Http.IResult ToValidationProblem(this ErrorOrResult.ErrorInfo errorInfo);
```
#### Parameters

<a name='ErrorOrResult.ResultHttpExtensions.ToValidationProblem(thisErrorOrResult.ErrorInfo).errorInfo'></a>

`errorInfo` [ErrorInfo](ErrorInfo.md 'ErrorOrResult\.ErrorInfo')

The error information to convert\.

#### Returns
[Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult')  
An [Microsoft\.AspNetCore\.Http\.IResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iresult 'Microsoft\.AspNetCore\.Http\.IResult') representing a validation problem response\.