namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result<TValue>> resultTask, Func<Result<TValue>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result> Map<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result> Map<TValue>(this Task<Result<TValue>> resultTask, Action next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result> Map<TValue>(this Task<Result<TValue>> resultTask, Action<TValue> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue2> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, TValue2> next)
    {
        var result = await resultTask;
        return result.Map(next);
    }
}