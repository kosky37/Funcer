using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Compel_Task
{
    public static async Task Compel(this Task<Result> resultTask)
    {
        var result = await resultTask;
        if (result.IsFailure) throw new FailureResultException(result.Errors);
    }
}