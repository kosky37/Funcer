namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Side_Task
{
    public static async Task<Result<TValue>> Side<TValue>(this Task<Result<TValue>> resultTask, Func<Task<Result>> next)
    {
        var result = await resultTask;

        return await result.Side(next);
    }
    
    public static async Task<Result<TValue1>> Side<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Func<Task<Result<TValue2>>> next)
    {
        var result = await resultTask;

        return await result.Side(next);
    }
}