namespace Funcer;

public static class ValueResultExtensions_Side_ValueTask
{
    public static async ValueTask<Result<TValue>> Side<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.Side(next);
    }
    
    public static async ValueTask<Result<TValue1>> Side<TValue1, TValue2>(this ValueTask<Result<TValue1>> resultValueTask, Func<ValueTask<Result<TValue2>>> next)
    {
        var result = await resultValueTask;

        return await result.Side(next);
    }
}