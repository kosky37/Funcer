namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<IEnumerable<TValue>> Combine<TValue>(this IEnumerable<Result<TValue>> results)
    {
        return Result.Combine(results);
    }
}

