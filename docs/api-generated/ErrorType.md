## ErrorType Enum

Defines the types of errors that can occur, mapped to HTTP status codes\.

```csharp
public enum ErrorType
```
### Fields

<a name='ErrorOrResult.ErrorType.BadRequest'></a>

`BadRequest` 400

Bad request error \(HTTP 400\)\.

<a name='ErrorOrResult.ErrorType.Unauthorized'></a>

`Unauthorized` 401

Unauthorized error \(HTTP 401\)\.

<a name='ErrorOrResult.ErrorType.Forbidden'></a>

`Forbidden` 403

Forbidden error \(HTTP 403\)\.

<a name='ErrorOrResult.ErrorType.NotFound'></a>

`NotFound` 404

Not found error \(HTTP 404\)\.

<a name='ErrorOrResult.ErrorType.Conflict'></a>

`Conflict` 409

Conflict error \(HTTP 409\)\.

<a name='ErrorOrResult.ErrorType.Validation'></a>

`Validation` 422

Validation error \(HTTP 422\)\.

<a name='ErrorOrResult.ErrorType.Failure'></a>

`Failure` 500

General failure error \(HTTP 500\)\.

<a name='ErrorOrResult.ErrorType.Unexpected'></a>

`Unexpected` 520

Unexpected error \(HTTP 520\)\.