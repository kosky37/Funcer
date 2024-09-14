namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Side<TValue>(this Task<Result<TValue>> resultTask, Func<Result> next)
    {
        var result = await resultTask;

        return result.Side(next);
    }
    
    public static async Task<Result<TValue>> Side<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Result> next)
    {
        var result = await resultTask;

        return result.Side(next);
    }
    
    public static async Task<Result<TValue1>> Side<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<Result<TValue2>> next)
    {
        var result = await resultTask;

        return result.Side(next);
    }
    
    public static async Task<Result<TValue1>> Side<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, Result<TValue2>> next)
    {
        var result = await resultTask;

        return result.Side(next);
    }
}