using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Compel_Task_Right
{
    public static async Task<TValue> Compel<TValue>(this Result<TValue> result, Func<IReadOnlyCollection<ErrorMessage>, Task<Exception>> exception)
    {
        if (result.IsFailure) throw await exception(result.Errors);

        return result.Value!;
    }
}