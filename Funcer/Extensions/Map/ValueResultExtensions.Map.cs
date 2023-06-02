namespace Funcer;

public static class ValueResultExtensions_Map
{
    public static Result<TValue> Map<TValue>(this Result<TValue> result, Func<Result<TValue>> next)
    {
        return result.IsFailure ? result : next().WithContext(result);
    }
    
    public static Result Map<TValue>(this Result<TValue> result, Func<TValue, Result> next)
    {
        return result.IsFailure ? Result.Failure(result.Errors) : next(result.Value!).WithContext(result);
    }
    
    public static Result<TValue2> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Result<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : next(result.Value!).WithContext(result);
    }
    
    public static Result Map<TValue>(this Result<TValue> result, Action next)
    {
        if (result.IsSuccess) next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static Result Map<TValue>(this Result<TValue> result, Action<TValue> next)
    {
        if (!result.IsFailure) next(result.Value!);
        
        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static Result<TValue2> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue2> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(next()).WithContext(result);
    }
    
    public static Result<TValue2> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, TValue2> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(next(result.Value!)).WithContext(result);
    }
}