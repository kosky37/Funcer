namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Map_Task
{
    public static async Task<Result> Map(this Task<Result> resultTask, Func<Task<Result>> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result> resultTask, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
    
    public static async Task<Result> Map(this Task<Result> resultTask, Func<Task> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result> resultTask, Func<Task<TValue>> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
}