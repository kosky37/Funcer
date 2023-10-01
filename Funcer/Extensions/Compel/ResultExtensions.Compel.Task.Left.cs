using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Compel_Task_Left
{
    public static async Task Compel(this Task<Result> resultTask, Func<IEnumerable<ErrorMessage>, Exception> exception)
    {
        var result = await resultTask;
        if (result.IsFailure) throw exception(result.Errors);
    }
}