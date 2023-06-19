namespace Funcer;

public static class ValueResultExtensions_TapIf_ValueTask
{
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this ValueTask<Result<TValue>> resultValueTask,  Func<TValue, bool> condition, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, bool condition, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>>  resultValueTask, Func<bool> condition, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>>  resultValueTask,  Func<TValue1, bool> condition, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>>  resultValueTask, bool condition, Func<ValueTask<TValue2>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>>  resultValueTask, Func<bool> condition, Func<ValueTask<TValue2>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this ValueTask<Result<TValue1>>  resultValueTask, Func<TValue1, bool> condition, Func<ValueTask<TValue2>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
}