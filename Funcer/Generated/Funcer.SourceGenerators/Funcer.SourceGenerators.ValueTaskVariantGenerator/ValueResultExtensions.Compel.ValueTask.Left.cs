using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Compel_ValueTask_Left
{
    public static async ValueTask<TValue> Compel<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<IReadOnlyCollection<ErrorMessage>, Exception> exception)
    {
        var result = await resultValueTask;
        if (result.IsFailure) throw exception(result.Errors);

        return result.Value!;
    }
}