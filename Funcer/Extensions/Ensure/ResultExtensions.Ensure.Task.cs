using Funcer.Generator.Attributes;

namespace Funcer;

//TODO: add tests
[ValueTaskVariantGenerator]
public static class ResultExtensions_Ensure_Task
{
    public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<bool>> condition, Error error)
    {
        var result = await resultTask;
        return await result.Ensure(condition, error);
    }
}