using Funcer.Generator.Attributes;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Ensure_Task_Left
{
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Error error)
    {
        var result = await resultTask;
        return result.Ensure(condition, error);
    }
    
    public static async Task<Result<TValue>> Ensure<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Error error)
    {
        var result = await resultTask;
        return result.Ensure(condition, error);
    }
}