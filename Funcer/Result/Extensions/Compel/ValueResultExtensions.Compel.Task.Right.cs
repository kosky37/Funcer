using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<TValue> Compel<TValue>(this Result<TValue> result, Func<IReadOnlyCollection<ErrorMessage>, Task<Exception>> exception)
    {
        if (result.IsFailure) throw await exception(result.Errors);

        return result.Value!;
    }
}