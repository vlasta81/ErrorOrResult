
namespace ErrorOrResult
{
    /// <summary>
    /// Defines the types of errors that can occur, mapped to HTTP status codes.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Bad request error (HTTP 400).
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Unauthorized error (HTTP 401).
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Forbidden error (HTTP 403).
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// Not found error (HTTP 404).
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// Conflict error (HTTP 409).
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// Validation error (HTTP 422).
        /// </summary>
        Validation = 422,

        /// <summary>
        /// General failure error (HTTP 500).
        /// </summary>
        Failure = 500,

        /// <summary>
        /// Unexpected error (HTTP 520).
        /// </summary>
        Unexpected = 520
    }

}
