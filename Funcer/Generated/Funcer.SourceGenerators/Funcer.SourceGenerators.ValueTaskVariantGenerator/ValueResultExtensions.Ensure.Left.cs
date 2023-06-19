using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Ensure_ValueTask_Left
{
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, ErrorMessage error)
    {
        var result = await resultValueTask;
        return result.Ensure(condition, error);
    }
    
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, ErrorMessage error)
    {
        var result = await resultValueTask;
        return result.Ensure(condition, error);
    }
}