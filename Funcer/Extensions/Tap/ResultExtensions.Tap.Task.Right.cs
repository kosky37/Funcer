using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Tap_Task_Right
{
    public static async Task<Result> Tap(this Result result, Func<Task<Result>> next)
    {
        return result.IsFailure ? result : await next();
    }
    
    public static async Task<Result> Tap<TValue>(this Result result, Func<Task<Result<TValue>>> next)
    {
        if (result.IsFailure) return result;
        var nextResult = await next();
        
        return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success();
    }
    
    public static async Task<Result> Tap(this Result result, Func<Task> next)
    {
        if (result.IsSuccess) await next();

        return result;
    }
    
    public static async Task<Result> Tap<TValue>(this Result result, Func<Task<TValue>> next)
    {
        if (result.IsFailure) return result;
        await next();
        
        return Result.Success();
    }
}