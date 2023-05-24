namespace Funcer;

//TODO: add tests
//TODO: add Task and ValueTask variants
public static partial class ResultExtensions
{
    public static Result TapIf(this Result result, bool condition, Func<Result> next)
    {
        return result.IsFailure || !condition ? result : next();
    }
    
    public static Result TapIf(this Result result, Func<bool> condition, Func<Result> next)
    {
        return result.IsFailure || !condition() ? result : next();
    }
    
    public static Result TapIf<TValue>(this Result result, bool condition, Func<Result<TValue>> next)
    {
        if (result.IsFailure || !condition) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success();
    }
    
    public static Result TapIf<TValue>(this Result result, Func<bool> condition, Func<Result<TValue>> next)
    {
        if (result.IsFailure || !condition()) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success();
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
        
        return Result.Success();
    }
    
    public static Result TapIf<TValue>(this Result result, Func<bool> condition, Func<TValue> next)
    {
        if (result.IsFailure || !condition()) return result;
        next();
        
        return Result.Success();
    }
}