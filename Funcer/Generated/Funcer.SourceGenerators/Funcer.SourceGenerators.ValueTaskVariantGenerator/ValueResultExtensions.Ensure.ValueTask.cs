using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Ensure_ValueTask
{
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<ValueTask<bool>> condition, ErrorMessage error)
    {
        var result = await resultValueTask;
        return await result.Ensure(condition, error);
    }
    
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, ValueTask<bool>> condition, ErrorMessage error)
    {
        var result = await resultValueTask;
        return await result.Ensure(condition, error);
    }
}