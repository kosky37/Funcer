namespace Funcer;

public static class ResultExtensions_MapIf_Task
{
    public static async Task<Result> MapIf(this Task<Result> resultTask, bool condition, Func<Task<Result>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf(this Task<Result> resultTask, Func<bool> condition, Func<Task<Result>> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }

    public static async Task<Result> MapIf(this Task<Result> resultTask, bool condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
    
    public static async Task<Result> MapIf(this Task<Result> resultTask, Func<bool> condition, Func<Task> next)
    {
        var result = await resultTask;

        return await result.MapIf(condition, next);
    }
}