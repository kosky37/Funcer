namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }

    public static async Task<Result<TValue>> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<TValue, Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Func<TValue, Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
}