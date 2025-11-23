namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Result> next)
    {
        var result = await resultTask;
        return result.TapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<Result<IEnumerable<TValue>>> resultTask, Action<TValue> next)
    {
        var result = await resultTask;
        return result.TapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.TapAll(next);
    }
}

