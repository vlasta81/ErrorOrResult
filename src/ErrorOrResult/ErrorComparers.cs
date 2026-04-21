namespace ErrorOrResult
{
    /// <summary>
    /// Provides reusable <see cref="IComparer{T}"/> implementations for ordering <see cref="Error"/> instances.
    /// </summary>
    public static class ErrorComparers
    {
        /// <summary>
        /// Orders errors so that the most client-actionable categories come first
        /// (validation and request-shape issues before infrastructure failures).
        /// </summary>
        /// <remarks>
        /// Severity ranking (higher comes first):
        /// <list type="bullet">
        /// <item><description><see cref="ErrorType.Validation"/> (100)</description></item>
        /// <item><description><see cref="ErrorType.BadRequest"/> (90)</description></item>
        /// <item><description><see cref="ErrorType.Conflict"/> (80)</description></item>
        /// <item><description><see cref="ErrorType.Unauthorized"/> (70)</description></item>
        /// <item><description><see cref="ErrorType.Forbidden"/> (60)</description></item>
        /// <item><description><see cref="ErrorType.NotFound"/> (50)</description></item>
        /// <item><description><see cref="ErrorType.Failure"/> (20)</description></item>
        /// <item><description><see cref="ErrorType.Unexpected"/> (10)</description></item>
        /// </list>
        /// </remarks>
        public static IComparer<Error> BySeverityDescending { get; } = new SeverityDescComparer();

        private sealed class SeverityDescComparer : IComparer<Error>
        {
            public int Compare(Error x, Error y) => GetRank(y.Type).CompareTo(GetRank(x.Type));

            private static int GetRank(ErrorType type) => type switch
            {
                ErrorType.Validation => 100,
                ErrorType.BadRequest => 90,
                ErrorType.Conflict => 80,
                ErrorType.Unauthorized => 70,
                ErrorType.Forbidden => 60,
                ErrorType.NotFound => 50,
                ErrorType.Failure => 20,
                ErrorType.Unexpected => 10,
                _ => 0,
            };
        }
    }
}
