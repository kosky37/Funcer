namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, bool condition, Func<Result<TValue>> next)
    {
        return result.IsFailure || !condition ? result : next().WithContext(result);
    }
    
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, TValue> mapping)
    {
        return result.IsFailure || !condition ? result : Result.Success(mapping(result.Value!)).WithContext(result);
    }

    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, Func<bool> condition,
        Func<Result<TValue>> next)
    {
        return result.IsFailure || !condition() ? result : next().WithContext(result);
    }

    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, Func<bool> condition,
        Func<TValue, TValue> mapping)
    {
        return result.IsFailure || !condition() ? result : Result.Success(mapping(result.Value!)).WithContext(result);
    }
    
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition,
        Func<Result<TValue>> next)
    {
        return result.IsFailure || !condition(result.Value!) ? result : next().WithContext(result);
    }
    
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition,
        Func<TValue, TValue> mapping)
    {
        return result.IsFailure || !condition(result.Value!) ? result : Result.Success(mapping(result.Value!)).WithContext(result);
    }
}