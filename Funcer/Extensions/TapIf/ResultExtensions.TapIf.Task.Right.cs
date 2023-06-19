namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_TapIf_Task_Right
{
    public static async Task<Result> TapIf(this Result result, bool condition, Func<Task<Result>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
    }
    
    public static async Task<Result> TapIf(this Result result, Func<bool> condition, Func<Task<Result>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
    }
    
    public static async Task<Result> TapIf<TValue>(this Result result, bool condition, Func<Task<Result<TValue>>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async Task<Result> TapIf<TValue>(this Result result, Func<bool> condition, Func<Task<Result<TValue>>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async Task<Result> TapIf(this Result result, bool condition, Func<Task> next)
    {
        if (result.IsSuccess && condition) await next();

        return result;
    }
    
    public static async Task<Result> TapIf(this Result result, Func<bool> condition, Func<Task> next)
    {
        if (result.IsSuccess && condition()) await next();

        return result;
    }
    
    public static async Task<Result> TapIf<TValue>(this Result result, bool condition, Func<Task<TValue>> next)
    {
        if (result.IsFailure || !condition) return result;
        await next();
        
        return Result.Success().WithContext(result);
    }
    
    public static async Task<Result> TapIf<TValue>(this Result result, Func<bool> condition, Func<Task<TValue>> next)
    {
        if (result.IsFailure || !condition()) return result;
        await next();
        
        return Result.Success().WithContext(result);
    }
}