using Funcer.Generator.Attributes;

namespace Funcer;

//TODO: add tests
[ValueTaskVariantGenerator]
public static class ResultExtensions_Ensure_Task_Left
{
    public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> condition, Error error)
    {
        var result = await resultTask;
        return result.Ensure(condition, error);
    }
}