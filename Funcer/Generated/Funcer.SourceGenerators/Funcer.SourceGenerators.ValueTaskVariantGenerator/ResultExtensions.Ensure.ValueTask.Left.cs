using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Ensure_ValueTask_Left
{
    public static async ValueTask<Result> Ensure(this ValueTask<Result> resultValueTask, Func<bool> condition, ErrorMessage error)
    {
        var result = await resultValueTask;
        return result.Ensure(condition, error);
    }
}