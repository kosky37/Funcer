using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Log_Task
{
    public static async Task<Result> Log(this Task<Result> resultTask, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        var result = await resultTask;

        return await result.Log(onFailure);
    }
    
    public static async Task<Result> Log(this Task<Result> resultTask, Func<Task> onFailure)
    {
        var result = await resultTask;

        return await result.Log(onFailure);
    }
}