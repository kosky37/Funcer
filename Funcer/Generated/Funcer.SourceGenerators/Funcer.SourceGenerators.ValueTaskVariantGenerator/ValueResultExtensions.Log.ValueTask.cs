using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Log_ValueTask
{
    public static async ValueTask<Result<TValue>> Log<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        return await result.Log(onFailure);
    }
    
    public static async ValueTask<Result<TValue>> Log<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        return await result.Log(onFailure);
    }
}