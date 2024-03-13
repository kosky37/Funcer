namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Tap(this Result result, Func<Task<Result>> next)
    {
        return result.IsFailure ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result> Tap<TValue>(this Result result, Func<Task<Result<TValue>>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success().WithContext(result).WithContext(nextResult);
    }
    
    public static async Task<Result> Tap(this Result result, Func<Task> next)
    {
        if (result.IsSuccess) await next();

        return result;
    }
    
    public static async Task<Result> Tap<TValue>(this Result result, Func<Task<TValue>> next)
    {
        if (result.IsFailure) return result;
        await next();
        
        return Result.Success().WithContext(result);
    }
}