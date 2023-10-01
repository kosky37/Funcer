namespace Funcer;

public static class ValueResultExtensions_Tap_Task_Left
{
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Func<Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Action next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result<TValue1>> Tap<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
    
    public static async Task<Result<TValue1>> Tap<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue2> next)
    {
        var result = await resultTask;
        return result.Tap(next);
    }
}