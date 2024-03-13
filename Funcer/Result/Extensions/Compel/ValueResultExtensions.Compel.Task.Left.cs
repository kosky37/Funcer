using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<TValue> Compel<TValue>(this Task<Result<TValue>> resultTask, Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
    {
        var result = await resultTask;
        if (result.IsFailure) throw exception(result.Errors);

        return result.Value!;
    }
}