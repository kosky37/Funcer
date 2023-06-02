using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Compel_Task
{
    public static async Task<TResult> Compel<TResult>(this Task<Result<TResult>> resultTask)
    {
        var result = await resultTask;
        if (result.IsFailure) throw new FailureResultException(result.Errors);

        return result.Value!;
    }
    
    public static async Task<TResult> Compel<TResult>(this Task<Result<TResult>> resultTask, Func<IList<Error>, Exception> exception)
    {
        var result = await resultTask;
        if (result.IsFailure) throw exception(result.Errors);

        return result.Value!;
    }
}