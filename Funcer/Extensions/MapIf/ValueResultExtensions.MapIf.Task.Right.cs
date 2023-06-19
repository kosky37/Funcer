namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_MapIf_Task_Right
{
    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, bool condition, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure || !condition ? result : (await next()).WithContext(result);
    }

    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure || !condition() ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure || !condition(result.Value!) ? result : (await next()).WithContext(result);
    }

    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, Task<Result>> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition
                    ? await next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }

    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, Task<Result>> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition()
                    ? await next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }
    
    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<TValue, Task<Result>> next)
    {
        return result.IsFailure
            ? Result.Failure(result.Errors)
            : (
                condition(result.Value!)
                    ? await next(result.Value!)
                    : Result.Success()
            ).WithContext(result);
    }

    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, bool condition, Func<Task> next)
    {
        if (result.IsSuccess && condition) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<Task> next)
    {
        if (result.IsSuccess && condition()) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<Task> next)
    {
        if (result.IsSuccess && condition(result.Value!)) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }

    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, Task> next)
    {
        if (!result.IsFailure && condition) await next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, Task> next)
    {
        if (!result.IsFailure && condition()) await next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async Task<Result> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<TValue, Task> next)
    {
        if (!result.IsFailure && condition(result.Value!)) await next(result.Value!);

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
}