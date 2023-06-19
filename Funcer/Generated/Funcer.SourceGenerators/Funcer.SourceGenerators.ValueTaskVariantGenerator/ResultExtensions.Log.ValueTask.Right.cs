using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Log_ValueTask_Right
{
    public static async ValueTask<Result> Log(this Result result, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);

        return result;
    }
    
    public static async ValueTask<Result> Log(this Result result, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        
        return result;
    }
}