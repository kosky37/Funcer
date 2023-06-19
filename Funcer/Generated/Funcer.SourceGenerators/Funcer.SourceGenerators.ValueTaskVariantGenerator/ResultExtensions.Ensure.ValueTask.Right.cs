using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Ensure_ValueTask_Right
{
    public static async ValueTask<Result> Ensure(this Result result, Func<ValueTask<bool>> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result.Failure(error);
    }
}