namespace Funcer;

public static class ValueResultExtensions_Map_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> Map<TValue>(this Result<TValue> result, Func<ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? result : (await next()).WithContext(result);
    }
    
    public static async ValueTask<Result> Map<TValue>(this Result<TValue> result, Func<TValue, ValueTask<Result>> next)
    {
        return result.IsFailure ? Result.Failure(result.Errors) : (await next(result.Value!)).WithContext(result);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : (await next(result.Value!)).WithContext(result);
    }
    
    public static async ValueTask<Result> Map<TValue>(this Result<TValue> result, Func<ValueTask> next)
    {
        if (result.IsSuccess) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async ValueTask<Result> Map<TValue>(this Result<TValue> result, Func<TValue, ValueTask> next)
    {
        if (!result.IsFailure) await next(result.Value!);
        
        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<ValueTask<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next()).WithContext(result);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, ValueTask<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next(result.Value!)).WithContext(result);
    }
}