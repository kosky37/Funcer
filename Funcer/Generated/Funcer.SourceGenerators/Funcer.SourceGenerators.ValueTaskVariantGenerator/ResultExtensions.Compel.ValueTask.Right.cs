using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Compel_ValueTask_Right
{
    public static async ValueTask Compel(this Result result, Func<IEnumerable<ErrorMessage>, ValueTask<Exception>> exception)
    {
        if (result.IsFailure) throw await exception(result.Errors);
    }
}