namespace Funcer;

public static class ValueResultExtensions_Map_Task_Right
{
    public static async Task<Result<TValue>> Map<TValue>(this Result<TValue> result, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result> Map<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> next)
    {
        return result.IsFailure ? Result.Failure(result.Errors) : (await next(result.Value!)).WithContext(result);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Task<Result<TValue2>>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : (await next(result.Value!)).WithContext(result);
    }
    
    public static async Task<Result> Map<TValue>(this Result<TValue> result, Func<Task> next)
    {
        if (result.IsSuccess) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async Task<Result> Map<TValue>(this Result<TValue> result, Func<TValue, Task> next)
    {
        if (!result.IsFailure) await next(result.Value!);
        
        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success().WithContext(result);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<Task<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next()).WithContext(result);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Task<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next(result.Value!)).WithContext(result);
    }
}