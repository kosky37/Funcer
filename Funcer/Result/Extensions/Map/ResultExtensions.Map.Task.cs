namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result> resultTask, Func<Task<Result<TValue>>> next)
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