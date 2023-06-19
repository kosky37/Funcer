namespace Funcer;

public static class ResultExtensions_Map_ValueTask_Left
{
    public static async ValueTask<Result> Map(this ValueTask<Result> resultValueTask, Func<Result> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result<TValue>> Map<TValue>(this ValueTask<Result> resultValueTask, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result> Map(this ValueTask<Result> resultValueTask, Action next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result<TValue>> Map<TValue>(this ValueTask<Result> resultValueTask, Func<TValue> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
}