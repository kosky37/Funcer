namespace Funcer;

public static class ResultExtensions_Tap_ValueTask_Right
{
    public static async ValueTask<Result> Tap(this Result result, Func<ValueTask<Result>> next)
    {
        return result.IsFailure ? result : (await next()).WithContext(result);
    }
    
    public static async ValueTask<Result> Tap<TValue>(this Result result, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success().WithContext(result).WithContext(nextResult);
    }
    
    public static async ValueTask<Result> Tap(this Result result, Func<ValueTask> next)
    {
        if (result.IsSuccess) await next();

        return result;
    }
    
    public static async ValueTask<Result> Tap<TValue>(this Result result, Func<ValueTask<TValue>> next)
    {
        if (result.IsFailure) return result;
        await next();
        
        return Result.Success().WithContext(result);
    }
}