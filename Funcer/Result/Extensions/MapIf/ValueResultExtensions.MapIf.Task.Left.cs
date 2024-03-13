namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }

    public static async Task<Result<TValue>> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
}