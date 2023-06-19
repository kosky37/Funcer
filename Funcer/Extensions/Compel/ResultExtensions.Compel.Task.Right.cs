using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Compel_Task_Right
{
    public static async Task Compel(this Result result, Func<IEnumerable<ErrorMessage>, Task<Exception>> exception)
    {
        if (result.IsFailure) throw await exception(result.Errors);
    }
}