namespace Funcer;

public static class ResultExtensions_MapIf_ValueTask_Right
{
    public static async ValueTask<Result> MapIf(this Result result, bool condition, Func<ValueTask<Result>> next)
    {
        return result.IsFailure || !condition ? result : (await next()).WithContext(result);
    }
    
    public static async ValueTask<Result> MapIf(this Result result, Func<bool> condition, Func<ValueTask<Result>> next)
    {
        return result.IsFailure || !condition() ? result : (await next()).WithContext(result);
    }

    public static async ValueTask<Result> MapIf(this Result result, bool condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition) await next();

        return result;
    }
    
    public static async ValueTask<Result> MapIf(this Result result, Func<bool> condition, Func<ValueTask> next)
    {
        if (result.IsSuccess && condition()) await next();

        return result;
    }
}