namespace Funcer;

public static class ValueResultExtensions_Tap_Task
{
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<Result>> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Func<Task> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result<TValue1>> Tap<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result<TValue1>> Tap<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<Task<TValue2>> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
}