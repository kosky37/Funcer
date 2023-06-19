namespace Funcer;

public static class ResultExtensions_MapIf_ValueTask
{
    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, bool condition, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, bool condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<ValueTask> next)
    {
        var result = await resultValueTask;

        return await result.MapIf(condition, next);
    }
}