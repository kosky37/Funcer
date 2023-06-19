namespace Funcer;

public static class ValueResultExtensions_MapIf_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }

    public static async ValueTask<Result<TValue>> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<TValue, Result> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<TValue, Result> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Func<TValue, Result> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Action next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Action next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Action next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Action<TValue> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Action<TValue> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, Action<TValue> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
}