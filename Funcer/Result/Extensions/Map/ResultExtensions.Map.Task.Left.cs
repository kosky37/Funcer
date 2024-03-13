namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result> resultTask, Func<Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result> resultTask, Func<TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
}