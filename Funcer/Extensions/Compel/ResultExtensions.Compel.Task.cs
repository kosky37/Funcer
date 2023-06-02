using Funcer.Generator.Attributes;
using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Compel_Task
{
    public static async Task Compel(this Task<Result> resultTask)
    {
        var result = await resultTask;
        if (result.IsFailure) throw new FailureResultException(result.Errors);
    }
    
    public static async Task Compel(this Task<Result> resultTask, Func<IEnumerable<Error>, Exception> exception)
    {
        var result = await resultTask;
        if (result.IsFailure) throw exception(result.Errors);
    }
}