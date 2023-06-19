namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_TapIf_Task_Left
{
    public static async Task<Result> TapIf(this Task<Result> resultTask, bool condition, Func<Result> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf(this Task<Result> resultTask, Func<bool> condition, Func<Result> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, bool condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, Func<bool> condition, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf(this Task<Result> resultTask, bool condition, Action next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf(this Task<Result> resultTask, Func<bool> condition, Action next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, bool condition, Func<TValue> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, Func<bool> condition, Func<TValue> next)
    {
        var result = await resultTask;

        return result.TapIf(condition, next);
    }
}