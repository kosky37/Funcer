namespace Funcer;

public static class ValueResultExtensions_TapIf_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, bool condition, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        if (result.IsFailure || !condition(result.Value!)) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, ValueTask<Result>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        if (result.IsFailure || !condition(result.Value!)) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, bool condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition) await next();
    
        return result;
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition()) await next();
    
        return result;
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition(result.Value!)) await next();
    
        return result;
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, ValueTask> next)
    {
        if (result.IsSuccess && condition) await next(result.Value!);

        return result;
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, ValueTask> next)
    {
        if (result.IsSuccess && condition()) await next(result.Value!);

        return result;
    }
    
    public static async ValueTask<Result<TValue>> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Func<TValue, ValueTask> next)
    {
        if (result.IsSuccess && condition(result.Value!)) await next(result.Value!);

        return result;
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this Result<TValue1> result, bool condition, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this Result<TValue1> result, Func<bool> condition, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this Result<TValue1> result,  Func<TValue1, bool> condition, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        if (result.IsFailure || !condition(result.Value!)) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this Result<TValue1> result, bool condition, Func<ValueTask<TValue2>> next)
    {
        if (result.IsSuccess && condition) await next();

        return result;
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this Result<TValue1> result, Func<bool> condition, Func<ValueTask<TValue2>> next)
    {
        if (result.IsSuccess && condition()) await next();

        return result;
    }
    
    public static async ValueTask<Result<TValue1>> TapIf<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, bool> condition, Func<ValueTask<TValue2>> next)
    {
        if (result.IsSuccess && condition(result.Value!)) await next();

        return result;
    }
}