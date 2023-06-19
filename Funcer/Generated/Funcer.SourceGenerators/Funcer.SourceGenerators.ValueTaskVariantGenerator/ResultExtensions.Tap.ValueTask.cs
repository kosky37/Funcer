namespace Funcer;

public static class ResultExtensions_Tap_ValueTask
{
    public static async ValueTask<Result> Tap(this ValueTask<Result> resultValueTask, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result> Tap<TValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result> Tap(this ValueTask<Result> resultValueTask, Func<ValueTask> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
    
    public static async ValueTask<Result> Tap<TValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<TValue>> next)
    {
        var result = await resultValueTask;
        return await result.Tap(next);
    }
}