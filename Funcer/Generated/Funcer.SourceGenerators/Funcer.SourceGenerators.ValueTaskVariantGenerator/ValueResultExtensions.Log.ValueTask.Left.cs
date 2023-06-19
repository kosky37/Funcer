using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Log_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> Log<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        return result.Log(onFailure);
    }
    
    public static async ValueTask<Result<TValue>> Log<TValue>(this ValueTask<Result<TValue>> resultValueTask, Action onFailure)
    {
        var result = await resultValueTask;

        return result.Log(onFailure);
    }
}