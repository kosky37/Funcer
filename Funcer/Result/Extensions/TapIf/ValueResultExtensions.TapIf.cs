namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, bool condition, Func<Result<TValue>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<Result<TValue>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Func<Result<TValue>> next)
    {
        if (result.IsFailure || !condition(result.Value!)) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, Result> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, Result> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Func<TValue, Result> next)
    {
        if (result.IsFailure || !condition(result.Value!)) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, bool condition, Action next)
    {
        if (result.IsSuccess && condition) next();
    
        return result;
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Action next)
    {
        if (result.IsSuccess && condition()) next();
    
        return result;
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Action next)
    {
        if (result.IsSuccess && condition(result.Value!)) next();
    
        return result;
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, bool condition, Action<TValue> next)
    {
        if (result.IsSuccess && condition) next(result.Value!);

        return result;
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result, Func<bool> condition, Action<TValue> next)
    {
        if (result.IsSuccess && condition()) next(result.Value!);

        return result;
    }
    
    public static Result<TValue> TapIf<TValue>(this Result<TValue> result,  Func<TValue, bool> condition, Action<TValue> next)
    {
        if (result.IsSuccess && condition(result.Value!)) next(result.Value!);

        return result;
    }
    
    public static Result<TValue1> TapIf<TValue1, TValue2>(this Result<TValue1> result, bool condition, Func<TValue1, Result<TValue2>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue1> TapIf<TValue1, TValue2>(this Result<TValue1> result, Func<bool> condition, Func<TValue1, Result<TValue2>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue1> TapIf<TValue1, TValue2>(this Result<TValue1> result,  Func<TValue1, bool> condition, Func<TValue1, Result<TValue2>> next)
    {
        if (result.IsFailure || !condition(result.Value!)) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue1> TapIf<TValue1, TValue2>(this Result<TValue1> result, bool condition, Func<TValue2> next)
    {
        if (result.IsSuccess && condition) next();

        return result;
    }
    
    public static Result<TValue1> TapIf<TValue1, TValue2>(this Result<TValue1> result, Func<bool> condition, Func<TValue2> next)
    {
        if (result.IsSuccess && condition()) next();

        return result;
    }
    
    public static Result<TValue1> TapIf<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, bool> condition, Func<TValue2> next)
    {
        if (result.IsSuccess && condition(result.Value!)) next();

        return result;
    }
}