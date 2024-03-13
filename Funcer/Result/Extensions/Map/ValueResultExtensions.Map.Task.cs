namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue>(this Task<Result<TValue>> resultTask, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<Task<TValue2>> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
    
    public static async Task<Result<TValue2>> Map<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<TValue1, Task<TValue2>> next)
    {
        var result = await resultTask;
        return await result.Map(next);
    }
}