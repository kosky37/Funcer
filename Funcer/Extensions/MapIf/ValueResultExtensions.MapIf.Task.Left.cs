namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_MapIf_Task_Left
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

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Result> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<TValue, Result> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Func<TValue, Result> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Action next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Action next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Action<TValue> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Action<TValue> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Action<TValue> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
}