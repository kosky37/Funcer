using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Ensure_Task_Left
{
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, ErrorMessage error)
    {
        var result = await resultTask;
        return result.Ensure(condition, error);
    }
    
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, ErrorMessage error)
    {
        var result = await resultTask;
        return result.Ensure(condition, error);
    }
}