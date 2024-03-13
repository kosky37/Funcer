namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, bool condition, Func<Result<TValue>> next)
    {
        return result.IsFailure || !condition ? result : next().WithContext(result);
    }

    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, Func<bool> condition,
        Func<Result<TValue>> next)
    {
        return result.IsFailure || !condition() ? result : next().WithContext(result);
    }
    
    public static Result<TValue> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition,
        Func<Result<TValue>> next)
    {
        return result.IsFailure || !condition(result.Value!) ? result : next().WithContext(result);
    }
}