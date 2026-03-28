## Error Struct

Represents an error with a code, description, and type\.

```csharp
public readonly record struct Error : System.IEquatable<ErrorOrResult.Error>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[Error](Error.md 'ErrorOrResult\.Error')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [Error\(string, string, ErrorType\)](Error..ctor.3MU8J2M46MIYQXAH9BSTS6DQ5.md 'ErrorOrResult\.Error\.Error\(string, string, ErrorOrResult\.ErrorType\)') | Represents an error with a code, description, and type\. |

| Properties | |
| :--- | :--- |
| [Code](Error.Code.md 'ErrorOrResult\.Error\.Code') | The error code that uniquely identifies the error type\. |
| [Description](Error.Description.md 'ErrorOrResult\.Error\.Description') | A human\-readable description of the error\. |
| [NumericType](Error.NumericType.md 'ErrorOrResult\.Error\.NumericType') | Gets the numeric representation of the error type \(HTTP status code\)\. |
| [Type](Error.Type.md 'ErrorOrResult\.Error\.Type') | The type/category of the error\. |

| Methods | |
| :--- | :--- |
| [BadRequest\(string, string\)](Error.BadRequest.2S15IPC1T1XA7FBM51ABBL3YE.md 'ErrorOrResult\.Error\.BadRequest\(string, string\)') | Creates a bad request error\. |
| [Conflict\(string, string\)](Error.Conflict.N24T8H54MBQFLXE4RICIL1IS9.md 'ErrorOrResult\.Error\.Conflict\(string, string\)') | Creates a conflict error\. |
| [Custom\(string, string, ErrorType\)](Error.Custom.Y4HXL9GT85UIW79MIIO6BIJ2D.md 'ErrorOrResult\.Error\.Custom\(string, string, ErrorOrResult\.ErrorType\)') | Creates a custom error with a specified type\. |
| [Deconstruct\(string, string, ErrorType\)](Error.Deconstruct.Z90LW8QLDL9WITBJFPPSN2SC6.md 'ErrorOrResult\.Error\.Deconstruct\(string, string, ErrorOrResult\.ErrorType\)') | Deconstructs the error into its components\. |
| [Failure\(string, string\)](Error.Failure.RJKS3WCMWZHV8UAR98S77I7ID.md 'ErrorOrResult\.Error\.Failure\(string, string\)') | Creates a general failure error\. |
| [Forbidden\(string, string\)](Error.Forbidden.HFVML90ZF0XDS5VOOBAQ4DBM.md 'ErrorOrResult\.Error\.Forbidden\(string, string\)') | Creates a forbidden error\. |
| [NotFound\(string, string\)](Error.NotFound.7H30UXP9GX0SR5V8BTZ2XFCL8.md 'ErrorOrResult\.Error\.NotFound\(string, string\)') | Creates a not found error\. |
| [Unauthorized\(string, string\)](Error.Unauthorized.NKJ5AVODII3HUF1R89G3VZG0A.md 'ErrorOrResult\.Error\.Unauthorized\(string, string\)') | Creates an unauthorized error\. |
| [Unexpected\(string, string\)](Error.Unexpected.36VQZYFHCWIA1MMVXWVM6A3QB.md 'ErrorOrResult\.Error\.Unexpected\(string, string\)') | Creates an unexpected error\. |
| [Validation\(string, string\)](Error.Validation.4WXO4A65VYKB2LLCOF2XPM5U.md 'ErrorOrResult\.Error\.Validation\(string, string\)') | Creates a validation error\. |
| [WithDescription\(string\)](Error.WithDescription.EH9TE395ANNXXQ7TSINBKRB5D.md 'ErrorOrResult\.Error\.WithDescription\(string\)') | Creates a new error with the specified description, keeping the original code and type\. |
