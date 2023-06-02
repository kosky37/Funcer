using Funcer.Generator.Attributes;
using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Ensure_Task
{
    public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<bool>> condition, Error error)
    {
        var result = await resultTask;
        return await result.Ensure(condition, error);
    }
}