using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Log_Task
{
    public static async Task<Result<TValue>> Log<TValue>(this Task<Result<TValue>> resultTask, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        return await result.Log(onFailure);
    }
    
    public static async Task<Result<TValue>> Log<TValue>(this Task<Result<TValue>> resultTask, Func<Task> onFailure)
    {
        var result = await resultTask;

        return await result.Log(onFailure);
    }
}