using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Tap_Task_Right
{
    public static async Task<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<Task<Result<TValue>>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<Task> next)
    {
        if (result.IsSuccess) await next();
    
        return result;
    }
    
    public static async Task<Result<TValue>> Tap<TValue>(this Result<TValue> result, Func<TValue, Task> next)
    {
        if (result.IsSuccess) await next(result.Value!);

        return result;
    }
    
    public static async Task<Result<TValue1>> Tap<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next(result.Value!);
        
        return nextResult.IsFailure ? Result<TValue1>.Failure(nextResult.Errors) : result.WithContext(nextResult);
    }
    
    public static async Task<Result<TValue1>> Tap<TValue1, TValue2>(this Result<TValue1> result, Func<Task<TValue2>> next)
    {
        if (result.IsSuccess) await next();

        return result;
    }
}