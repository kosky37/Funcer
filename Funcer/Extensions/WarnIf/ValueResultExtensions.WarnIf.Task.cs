using Funcer.Generator.Attributes;
using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_WarnIf_Task
{
    public static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, Warning warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, Warning warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, Warning warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    internal static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, IEnumerable<Warning> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
    
    internal static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, IEnumerable<Warning> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
    
    internal static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, IEnumerable<Warning> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
}