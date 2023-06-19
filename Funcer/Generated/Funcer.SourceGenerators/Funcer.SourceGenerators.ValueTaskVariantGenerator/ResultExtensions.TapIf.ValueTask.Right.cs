namespace Funcer;

public static class ResultExtensions_TapIf_ValueTask_Right
{
    public static async ValueTask<Result> TapIf(this Result result, bool condition, Func<ValueTask<Result>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result> TapIf(this Result result, Func<bool> condition, Func<ValueTask<Result>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this Result result, bool condition, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this Result result, Func<bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result> TapIf(this Result result, bool condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition) await next();

        return result;
    }
    
    public static async ValueTask<Result> TapIf(this Result result, Func<bool> condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition()) await next();

        return result;
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this Result result, bool condition, Func<ValueTask<TValue>> next)
    {
        if (result.IsFailure || !condition) return result;
        await next();
        
        return Result.Success().WithContext(result);
    }
    
    public static async ValueTask<Result> TapIf<TValue>(this Result result, Func<bool> condition, Func<ValueTask<TValue>> next)
    {
        if (result.IsFailure || !condition()) return result;
        await next();
        
        return Result.Success().WithContext(result);
    }
}