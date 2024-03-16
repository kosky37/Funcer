using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task Compel(this Task<Result> resultTask)
    {
        var result = await resultTask;
        if (result.IsFailure) throw new FailureResultException(result.Errors);
    }
    
    public static async Task Compel(this Task<Result> resultTask, Func<IEnumerable<ErrorMessage>, Task<Exception>> exception)
    {
        var result = await resultTask;
        if (result.IsFailure) throw await exception(result.Errors);
    }
}