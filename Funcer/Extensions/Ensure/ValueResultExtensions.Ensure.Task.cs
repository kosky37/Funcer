using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Ensure_Task
{
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<Task<bool>> condition, Error error)
    {
        var result = await resultTask;
        return await result.Ensure(condition, error);
    }
    
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, Task<bool>> condition, Error error)
    {
        var result = await resultTask;
        return await result.Ensure(condition, error);
    }
}