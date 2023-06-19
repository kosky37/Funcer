namespace Funcer;

public static class ValueResultExtensions_Tap_ValueTask
{
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<ValueTask> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue1>> Tap<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue1>> Tap<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<ValueTask<TValue2>> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
}