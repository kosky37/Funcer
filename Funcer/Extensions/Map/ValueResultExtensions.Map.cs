namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> Map<TValue>(this Result<TValue> result, Func<Result<TValue>> next)
    {
        return result.IsFailure ? result : next();
    }
    
    public static Result Map<TValue>(this Result<TValue> result, Func<TValue, Result> next)
    {
        return result.IsFailure ? Result.Failure(result.Errors) : next(result.Value!);
    }
    
    public static Result<TValue2> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Result<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : next(result.Value!);
    }
    
    public static Result Map<TValue>(this Result<TValue> result, Action next)
    {
        if (result.IsSuccess) next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success();
    }

    public static Result Map<TValue>(this Result<TValue> result, Action<TValue> next)
    {
        if (!result.IsFailure) next(result.Value!);
        
        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success();
    }

    public static Result<TValue2> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue2> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(next());
    }
    
    public static Result<TValue2> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, TValue2> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(next(result.Value!));
    }
}