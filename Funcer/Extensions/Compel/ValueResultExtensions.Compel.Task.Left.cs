using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Compel_Task_Left
{
    public static async Task<TValue> Compel<TValue>(this Task<Result<TValue>> resultTask, Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
    {
        var result = await resultTask;
        if (result.IsFailure) throw exception(result.Errors);

        return result.Value!;
    }
}