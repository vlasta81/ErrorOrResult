
namespace ErrorOrResult
{
    /// <summary>
    /// Provides LINQ query syntax support for <see cref="Result{TOutput}"/> instances.
    /// Enables use of 'select' and 'from' expressions with results.
    /// </summary>
    public static class ResultLinqExtensions
    {
        /// <summary>
        /// Projects the success value of a result using a selector function.
        /// Supports LINQ 'select' syntax.
        /// </summary>
        /// <typeparam name="TSource">The type of the source result value.</typeparam>
        /// <typeparam name="TOutput">The type of the projected value.</typeparam>
        /// <param name="source">The source result.</param>
        /// <param name="selector">The projection function.</param>
        /// <returns>A result with the projected value or the original error.</returns>
        public static Result<TOutput> Select<TSource, TOutput>(this Result<TSource> source, Func<TSource, TOutput> selector) => source.Map(selector);

        /// <summary>
        /// Chains result operations together.
        /// Supports LINQ 'from' syntax for flattening nested results.
        /// </summary>
        /// <typeparam name="TSource">The type of the source result value.</typeparam>
        /// <typeparam name="TOutput">The type of the output result value.</typeparam>
        /// <param name="source">The source result.</param>
        /// <param name="selector">The function that returns a new result.</param>
        /// <returns>The result returned by the selector or the original error.</returns>
        public static Result<TOutput> SelectMany<TSource, TOutput>(this Result<TSource> source, Func<TSource, Result<TOutput>> selector) => source.Bind(selector);

        /// <summary>
        /// Chains result operations together with a result selector.
        /// Supports LINQ query syntax with multiple 'from' clauses.
        /// </summary>
        /// <typeparam name="TSource">The type of the source result value.</typeparam>
        /// <typeparam name="TCollection">The type of the intermediate collection result value.</typeparam>
        /// <typeparam name="TOutput">The type of the final output value.</typeparam>
        /// <param name="source">The source result.</param>
        /// <param name="collectionSelector">The function that returns an intermediate result.</param>
        /// <param name="resultSelector">The function that combines source and collection values.</param>
        /// <returns>A result with the combined value or the first encountered error.</returns>
        public static Result<TOutput> SelectMany<TSource, TCollection, TOutput>(this Result<TSource> source, Func<TSource, Result<TCollection>> collectionSelector, Func<TSource, TCollection, TOutput> resultSelector) => source.Bind(x => collectionSelector(x).Map(y => resultSelector(x, y)));
    }

}
