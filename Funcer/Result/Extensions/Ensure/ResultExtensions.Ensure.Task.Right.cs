using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Ensure(this Result result, Func<Task<bool>> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result.Failure(error);
    }
}