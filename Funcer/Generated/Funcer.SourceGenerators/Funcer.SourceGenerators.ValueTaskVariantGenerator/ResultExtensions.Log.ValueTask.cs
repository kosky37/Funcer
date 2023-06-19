using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Log_ValueTask
{
    public static async ValueTask<Result> Log(this ValueTask<Result> resultValueTask, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        var result = await resultValueTask;

        return await result.Log(onFailure);
    }
    
    public static async ValueTask<Result> Log(this ValueTask<Result> resultValueTask, Func<ValueTask> onFailure)
    {
        var result = await resultValueTask;

        return await result.Log(onFailure);
    }
}