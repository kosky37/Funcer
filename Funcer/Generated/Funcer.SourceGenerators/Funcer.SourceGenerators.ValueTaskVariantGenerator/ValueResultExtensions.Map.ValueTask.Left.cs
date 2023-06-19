namespace Funcer;

public static class ValueResultExtensions_Map_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<Result<TValue>> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, Result> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result> Map<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<TValue> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue2> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
    
    public static async ValueTask<Result<TValue2>> Map<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<TValue1, TValue2> next)
    {
        var result = await resultValueTask;
        return result.Map(next);
    }
}