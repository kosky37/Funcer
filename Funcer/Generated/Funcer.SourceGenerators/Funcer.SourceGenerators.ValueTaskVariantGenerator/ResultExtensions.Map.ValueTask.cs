namespace Funcer;

public static class ResultExtensions_Map_ValueTask
{
    public static async ValueTask<Result> Map(this ValueTask<Result> resultValueTask, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result<TValue>> Map<TValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result> Map(this ValueTask<Result> resultValueTask, Func<ValueTask> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result<TValue>> Map<TValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<TValue>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
}