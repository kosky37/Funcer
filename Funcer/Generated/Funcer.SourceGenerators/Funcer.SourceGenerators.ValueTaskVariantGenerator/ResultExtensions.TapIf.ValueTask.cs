namespace Funcer;

public static class ResultExtensions_TapIf_ValueTask
{
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, bool condition, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, bool condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, bool condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, bool condition, Func<ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<ValueTask<TValue>> next)
    {
        var result = await resultValueTask;

        return await result.TapIf(condition, next);
    }
}