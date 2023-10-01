namespace Funcer;

public static class ResultExtensions_MapIf_Task_Left
{
    public static async Task<Result> MapIf(this Task<Result> resultTask, bool condition, Func<Result> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf(this Task<Result> resultTask, Func<bool> condition, Func<Result> next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf(this Task<Result> resultTask, bool condition, Action next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf(this Task<Result> resultTask, Func<bool> condition, Action next)
    {
        var result = await resultTask;

        return result.MapIf(condition, next);
    }
}