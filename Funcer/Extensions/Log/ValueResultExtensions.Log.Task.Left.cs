using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Log_Task_Left
{
    public static async Task<Result<TValue>> Log<TValue>(this Task<Result<TValue>> resultTask, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;

        return result.Log(onFailure);
    }
    
    public static async Task<Result<TValue>> Log<TValue>(this Task<Result<TValue>> resultTask, Action onFailure)
    {
        var result = await resultTask;

        return result.Log(onFailure);
    }
}