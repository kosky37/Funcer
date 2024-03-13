namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> Tap<TValue>(this Result<TValue> result, Func<Result<TValue>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> Tap<TValue>(this Result<TValue> result, Func<TValue, Result> next)
    {
        if (result.IsFailure) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue> Tap<TValue>(this Result<TValue> result, Action next)
    {
        if (result.IsSuccess) next();
    
        return result;
    }
    
    public static Result<TValue> Tap<TValue>(this Result<TValue> result, Action<TValue> next)
    {
        if (result.IsSuccess) next(result.Value!);

        return result;
    }
    
    public static Result<TValue1> Tap<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Result<TValue2>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static Result<TValue1> Tap<TValue1, TValue2>(this Result<TValue1> result, Func<TValue2> next)
    {
        if (result.IsSuccess) next();

        return result;
    }
}