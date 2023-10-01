namespace Funcer;

public static class ResultExtensions_MapIf_Task_Right
{
    public static async Task<Result> MapIf(this Result result, bool condition, Func<Task<Result>> next)
    {
        return result.IsFailure || !condition ? result : (await next()).WithContext(result);
    }
    
    public static async Task<Result> MapIf(this Result result, Func<bool> condition, Func<Task<Result>> next)
    {
        return result.IsFailure || !condition() ? result : (await next()).WithContext(result);
    }

    public static async Task<Result> MapIf(this Result result, bool condition, Func<Task> next)
    {
        if (result.IsSuccess && condition) await next();

        return result;
    }
    
    public static async Task<Result> MapIf(this Result result, Func<bool> condition, Func<Task> next)
    {
        if (result.IsSuccess && condition()) await next();

        return result;
    }
}