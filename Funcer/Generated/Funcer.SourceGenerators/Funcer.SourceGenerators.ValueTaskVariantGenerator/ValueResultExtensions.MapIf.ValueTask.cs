namespace Funcer;

public static class ValueResultExtensions_MapIf_ValueTask
{
    public static async ValueTask<Result<TValue>> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }

    public static async ValueTask<Result<TValue>> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
}