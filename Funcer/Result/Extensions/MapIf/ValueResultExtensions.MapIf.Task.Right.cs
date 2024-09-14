namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, bool condition, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure || !condition ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, bool condition, Func<TValue, Task<TValue>> mapping)
    {
        return result.IsFailure || !condition ? result : Result.Success(await mapping(result.Value!)).WithContext(result);
    }

    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure || !condition() ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<bool> condition, Func<TValue, Task<TValue>> mapping)
    {
        return result.IsFailure || !condition() ? result : Result.Success(await mapping(result.Value!)).WithContext(result);
    }
    
    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure || !condition(result.Value!) ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result<TValue>> MapIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Func<TValue, Task<TValue>> mapping)
    {
        return result.IsFailure || !condition(result.Value!) ? result : Result.Success(await mapping(result.Value!)).WithContext(result);
    }
}