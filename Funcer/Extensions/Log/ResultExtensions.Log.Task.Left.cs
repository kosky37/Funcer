using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Log_Task_Left
{
    public static async Task<Result> Log(this Task<Result> resultTask, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultTask;

        return result.Log(onFailure);
    }
    
    public static async Task<Result> Log(this Task<Result> resultTask, Action onFailure)
    {
        var result = await resultTask;

        return result.Log(onFailure);
    }
}