using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Compel_ValueTask
{
    public static async ValueTask Compel(this ValueTask<Result> resultValueTask)
    {
        var result = await resultValueTask;
        if (result.IsFailure) throw new FailureResultException(result.Errors);
    }
    
    public static async ValueTask Compel(this ValueTask<Result> resultValueTask, Func<IEnumerable<ErrorMessage>, ValueTask<Exception>> exception)
    {
        var result = await resultValueTask;
        if (result.IsFailure) throw await exception(result.Errors);
    }
}