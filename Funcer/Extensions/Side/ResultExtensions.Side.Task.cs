namespace Funcer;

public static class ResultExtensions_Side_Task
{
    public static async Task<Result> Side(this Task<Result> resultTask, Func<Task<Result>> next)
    {
        var result = await resultTask;

        return await result.Side(next);
    }
    
    public static async Task<Result> Side<TValue>(this Task<Result> resultTask, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;

        return await result.Side(next);
    }
}