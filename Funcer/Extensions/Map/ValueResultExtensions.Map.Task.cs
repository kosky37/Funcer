namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue>(this Result<TValue> result, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure ? result : await next();
    }
    
    public static async Task<Result> Map<TValue>(this Result<TValue> result, Func<TValue, Task<Result>> next)
    {
        return result.IsFailure ? Result.Failure(result.Errors) : await next(result.Value!);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Task<Result<TValue2>>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : await next(result.Value!);
    }
    
    public static async Task<Result> Map<TValue>(this Result<TValue> result, Func<Task> next)
    {
        if (result.IsSuccess) await next();

        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success();
    }
    
    public static async Task<Result> Map<TValue>(this Result<TValue> result, Func<TValue, Task> next)
    {
        if (!result.IsFailure) await next(result.Value!);
        
        return result.IsFailure ? Result.Failure(result.Errors) : Result.Success();
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<Task<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next());
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Result<TValue1> result, Func<TValue1, Task<TValue2>> next)
    {
        return result.IsFailure ? Result<TValue2>.Failure(result.Errors) : Result.Success(await next(result.Value!));
    }
}