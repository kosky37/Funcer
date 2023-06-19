namespace Funcer;

public static class ResultExtensions_Map_ValueTask_Right
{
    public static async ValueTask<Result> Map(this Result result, Func<ValueTask<Result>> next)
    {
        return result.IsFailure ? result : (await next()).WithContext(result);
    }
    
    public static async ValueTask<Result<TValue>> Map<TValue>(this Result result, Func<ValueTask<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await next()).WithContext(result);
    }
    
    public static async ValueTask<Result> Map(this Result result, Func<ValueTask> next)
    {
        if (result.IsSuccess) await next();

        return result;
    }
    
    public static async ValueTask<Result<TValue>> Map<TValue>(this Result result, Func<ValueTask<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next()).WithContext(result);
    }
}