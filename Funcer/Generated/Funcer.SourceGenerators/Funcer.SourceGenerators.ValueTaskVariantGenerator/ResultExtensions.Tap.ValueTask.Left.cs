namespace Funcer;

public static class ResultExtensions_Tap_ValueTask_Left
{
    public static async ValueTask<Result> Tap(this ValueTask<Result> resultValueTask, Func<Result> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result> Tap<TValue>(this ValueTask<Result> resultValueTask, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result> Tap(this ValueTask<Result> resultValueTask, Action next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
    
    public static async ValueTask<Result> Tap<TValue>(this ValueTask<Result> resultValueTask, Func<TValue> next)
    {
        var result = await resultValueTask;
        return result.Tap(next);
    }
}