namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> TapIf(this Task<Result> resultTask, bool condition, Func<Task<Result>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf(this Task<Result> resultTask, Func<bool> condition, Func<Task<Result>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, bool condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, Func<bool> condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf(this Task<Result> resultTask, bool condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf(this Task<Result> resultTask, Func<bool> condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, bool condition, Func<Task<TValue>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result> TapIf<TValue>(this Task<Result> resultTask, Func<bool> condition, Func<Task<TValue>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
}