namespace Funcer;

public static class ValueResultExtensions_Tap_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, Result> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue1>> Tap<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result<TValue1>> Tap<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue2> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
}