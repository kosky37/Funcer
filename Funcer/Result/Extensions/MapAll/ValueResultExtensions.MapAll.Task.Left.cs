namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }
}

