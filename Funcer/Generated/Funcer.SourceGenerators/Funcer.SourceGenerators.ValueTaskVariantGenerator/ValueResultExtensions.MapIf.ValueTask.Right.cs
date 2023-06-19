namespace Funcer;

public static class ValueResultExtensions_MapIf_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> MapIf<TValue>(this Result<TValue> result, bool condition, Func<ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure || !condition ? result : (await next()).WithContext(result);
    }

    public static async ValueTask<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure || !condition() ? result : (await next()).WithContext(result);
    }
    
    public static async ValueTask<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure || !condition(result.Value!) ? result : (await next()).WithContext(result);
    }

    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, ValueTask<Result>> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition
                    ? await next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }

    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition()
                    ? await next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<TValue, ValueTask<Result>> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition(result.Value!)
                    ? await next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }

    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, bool condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition()) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition(result.Value!)) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, ValueTask> next)
    {
        if (!result.IsFailure && condition) await next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, ValueTask> next)
    {
        if (!result.IsFailure && condition()) await next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async ValueTask<Result> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<TValue, ValueTask> next)
    {
        if (!result.IsFailure && condition(result.Value!)) await next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
}