namespace Funcer;

public static class ValueResultExtensions_Tap_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<TValue, ValueTask<Result>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<ValueTask> next)
    {
        if (result.IsSuccess) await next();
    
        return result;
    }
    
    public static async ValueTask<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<TValue, ValueTask> next)
    {
        if (result.IsSuccess) await next(result.Value!);

        return result;
    }
    
    public static async ValueTask<Result<TValue1>> Tap<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue1>> Tap<TValue1, TValue2>(this Result<TValue1> result, Func<ValueTask<TValue2>> next)
    {
        if (result.IsSuccess) await next();

        return result;
    }
}