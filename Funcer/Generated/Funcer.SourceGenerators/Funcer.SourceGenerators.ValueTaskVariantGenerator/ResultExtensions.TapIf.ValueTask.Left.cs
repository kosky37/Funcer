namespace Funcer;

public static class ResultExtensions_TapIf_ValueTask_Left
{
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, bool condition, Func<Result> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<Result> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, bool condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, bool condition, Action next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Action next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, bool condition, Func<TValue> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<TValue> next)
    {
        var result = await resultValueTask;

        return result.TapIf(condition, next);
    }
}