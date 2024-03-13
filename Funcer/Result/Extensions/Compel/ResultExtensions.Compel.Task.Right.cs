using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task Compel(this Result result, Func<IEnumerable<ErrorMessage>, Task<Exception>> exception)
    {
        if (result.IsFailure) throw await exception(result.Errors);
    }
}