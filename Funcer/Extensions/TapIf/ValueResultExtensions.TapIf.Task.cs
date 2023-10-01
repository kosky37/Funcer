namespace Funcer;

public static class ValueResultExtensions_TapIf_Task
{
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Func<TValue, Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Func<TValue, Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue>> TapIf<TValue>(this Task<Result<TValue>> resultTask,  Func<TValue, bool> condition, Func<TValue, Task> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, bool condition, Func<TValue1, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>>  resultTask, Func<bool> condition, Func<TValue1, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>>  resultTask,  Func<TValue1, bool> condition, Func<TValue1, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>>  resultTask, bool condition, Func<Task<TValue2>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>>  resultTask, Func<bool> condition, Func<Task<TValue2>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
    
    public static async Task<Result<TValue1>> TapIf<TValue1, TValue2>(this Task<Result<TValue1>>  resultTask, Func<TValue1, bool> condition, Func<Task<TValue2>> next)
    {
        var result = await resultTask;

        return await result.TapIf(condition, next);
    }
}