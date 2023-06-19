namespace Funcer;

public static class ResultExtensions_Side_ValueTask
{
    public static async ValueTask<Result> Side(this ValueTask<Result> resultValueTask, Func<ValueTask<Result>> next)
    {
        var result = await resultValueTask;

        return await result.Side(next);
    }
    
    public static async ValueTask<Result> Side<TValue>(this ValueTask<Result> resultValueTask, Func<ValueTask<Result<TValue>>> next)
    {
        var result = await resultValueTask;

        return await result.Side(next);
    }
}