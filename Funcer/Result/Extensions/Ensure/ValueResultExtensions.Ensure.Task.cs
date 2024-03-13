using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<Task<bool>> condition, ErrorMessage error)
    {
        var result = await resultTask;
        return await result.Ensure(condition, error);
    }
    
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<bool>> condition, ErrorMessage error)
    {
        var result = await resultTask;
        return await result.Ensure(condition, error);
    }
}