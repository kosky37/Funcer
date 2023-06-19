namespace Funcer;

public static class ValueResultExtensions_TapIf_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<TValue, Result> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<TValue, Result> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Func<TValue, Result> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Action next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Action next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Action next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Action<TValue> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Action<TValue> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Action<TValue> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, bool condition, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<bool> condition, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask,  Func<TValue1, bool> condition, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, bool condition, Func<TValue2> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<bool> condition, Func<TValue2> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue1, bool> condition, Func<TValue2> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
}