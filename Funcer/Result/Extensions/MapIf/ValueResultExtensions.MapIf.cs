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

    public static Result MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, Result> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition
                    ? next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }

    public static Result MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, Result> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition()
                    ? next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }
    
    public static Result MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<TValue, Result> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition(result.Value!)
                    ? next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }

    public static Result MapIf<TValue>(this Result<TValue> result, bool condition, Action next)
    {
        if (result.IsSuccess && condition) next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static Result MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Action next)
    {
        if (result.IsSuccess && condition()) next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static Result MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Action next)
    {
        if (result.IsSuccess && condition(result.Value!)) next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static Result MapIf<TValue>(this Result<TValue> result, bool condition, Action<TValue> next)
    {
        if (!result.IsFailure && condition) next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static Result MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Action<TValue> next)
    {
        if (!result.IsFailure && condition()) next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static Result MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Action<TValue> next)
    {
        if (!result.IsFailure && condition(result.Value!)) next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
}