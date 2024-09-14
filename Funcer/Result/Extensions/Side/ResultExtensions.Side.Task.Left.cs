namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Side(this Task<Result> resultTask, Func<Result> next)
    {
        var result = await resultTask;

        return result.Side(next);
    }
    
    public static async Task<Result> Side<TValue>(this Task<Result> resultTask, Func<Result<TValue>> next)
    {
        var result = await resultTask;

        return result.Side(next);
    }
}