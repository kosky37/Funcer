namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;
        return await result.TapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Task> next)
    {
        var result = await resultTask;
        return await result.TapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue>>> TapAll<TValue, TValue2>(this Task<Result<IEnumerable<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        return await result.TapAll(next);
    }
}