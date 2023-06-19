using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Ensure_ValueTask
{
    public static async ValueTask<Result> Ensure(this ValueTask<Result> resultValueTask, Func<ValueTask<bool>> condition, ErrorMessage error)
    {
        var result = await resultValueTask;
        return await result.Ensure(condition, error);
    }
}