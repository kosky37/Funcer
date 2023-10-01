using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Log_Task_Right
{
    public static async Task<Result> Log(this Result result, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);

        return result;
    }
    
    public static async Task<Result> Log(this Result result, Func<Task> onFailure)
    {
        if (result.IsFailure) await onFailure();
        
        return result;
    }
}