namespace Funcer;

public static class ResultExtensions_MapIf_ValueTask_Left
{
    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, bool condition, Func<Result> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Func<Result> next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }

    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, bool condition, Action next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
    
    public static async ValueTask<Result> MapIf(this ValueTask<Result> resultValueTask, Func<bool> condition, Action next)
    {
        var result = await resultValueTask;

        return result.MapIf(condition, next);
    }
}