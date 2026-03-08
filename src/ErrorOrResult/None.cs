
namespace ErrorOrResult
{
    /// <summary>
    /// Represents the absence of a value, similar to void but usable as a generic type parameter.
    /// Used with <see cref="Result{TOutput}"/> when no return value is needed.
    /// </summary>
    public readonly record struct None;
}
