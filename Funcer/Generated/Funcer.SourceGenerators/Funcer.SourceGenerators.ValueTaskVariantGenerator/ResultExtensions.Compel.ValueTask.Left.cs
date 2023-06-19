using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Compel_ValueTask_Left
{
    public static async ValueTask Compel(this ValueTask<Result> resultValueTask, Func<IEnumerable<ErrorMessage>, Exception> exception)
    {
        var result = await resultValueTask;
        if (result.IsFailure) throw exception(result.Errors);
    }
}