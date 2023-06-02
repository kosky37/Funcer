namespace Funcer;

public static class ResultExtensions_TapIf
{
    public static Result TapIf(this Result result, bool condition, Func<Result> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
    }
    
    public static Result TapIf(this Result result, Func<bool> condition, Func<Result> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
    }
    
    public static Result TapIf<TValue>(this Result result, bool condition, Func<Result<TValue>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result TapIf<TValue>(this Result result, Func<bool> condition, Func<Result<TValue>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result TapIf(this Result result, bool condition, Action next)
    {
        if (result.IsSuccess && condition) next();

        return result;
    }
    
    public static Result TapIf(this Result result, Func<bool> condition, Action next)
    {
        if (result.IsSuccess && condition()) next();

        return result;
    }
    
    public static Result TapIf<TValue>(this Result result, bool condition, Func<TValue> next)
    {
        if (result.IsFailure || !condition) return result;
        next();
        
        return Result.Success().WithContext(result);
    }
    
    public static Result TapIf<TValue>(this Result result, Func<bool> condition, Func<TValue> next)
    {
        if (result.IsFailure || !condition()) return result;
        next();
        
        return Result.Success().WithContext(result);
    }
}