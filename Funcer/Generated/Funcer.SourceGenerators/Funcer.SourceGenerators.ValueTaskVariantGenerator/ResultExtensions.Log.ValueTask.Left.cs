using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Log_ValueTask_Left
{
    public static async ValueTask<Result> Log(this ValueTask<Result> resultValueTask, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        var result = await resultValueTask;

        return result.Log(onFailure);
    }
    
    public static async ValueTask<Result> Log(this ValueTask<Result> resultValueTask, Action onFailure)
    {
        var result = await resultValueTask;

        return result.Log(onFailure);
    }
}