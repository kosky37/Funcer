using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Compel_ValueTask_Right
{
    public static async ValueTask<TValue> Compel<TValue>(this Result<TValue> result, Func<IReadOnlyCollection<ErrorMessage>, ValueTask<Exception>> exception)
    {
        if (result.IsFailure) throw await exception(result.Errors);

        return result.Value!;
    }
}