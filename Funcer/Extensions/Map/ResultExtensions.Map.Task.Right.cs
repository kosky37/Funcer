namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Map_Task_Right
{
    public static async Task<Result> Map(this Result result, Func<Task<Result>> next)
    {
        return result.IsFailure ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Result result, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await next()).WithContext(result);
    }
    
    public static async Task<Result> Map(this Result result, Func<Task> next)
    {
        if (result.IsSuccess) await next();

        return result;
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Result result, Func<Task<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next()).WithContext(result);
    }
}