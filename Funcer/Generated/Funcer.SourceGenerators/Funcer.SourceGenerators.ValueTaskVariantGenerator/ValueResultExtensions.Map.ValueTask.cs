namespace Funcer;

public static class ValueResultExtensions_Map_ValueTask
{
    public static async ValueTask<Result<TValue>> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask<Result>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue1, ValueTask<Result<TValue2>>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<ValueTask> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<ValueTask<TValue2>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue1, ValueTask<TValue2>> next)
    {
        var result = await resultValueTask;
        return await result.Map(next);
    }
}