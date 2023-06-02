using Funcer.Generator.Attributes;

namespace Funcer;

//TODO: add tests
[ValueTaskVariantGenerator]
public static class ResultExtensions_Ensure_Task_Right
{
    public static async Task<Result> Ensure(this Result result, Func<Task<bool>> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result.Failure(error);
    }
}