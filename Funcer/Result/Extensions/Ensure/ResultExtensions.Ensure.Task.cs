using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<bool>> condition, ErrorMessage error)
    {
        var result = await resultTask;
        return await result.Ensure(condition, error);
    }
}