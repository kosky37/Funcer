using Funcer.Generator.Attributes;
using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Warn_Task
{
    public static async Task<Result<TValue>> Warn<TValue>(this Task<Result<TValue>> resultTask, Warning warning)
    {
        var result = await resultTask;
        return result.Warn(warning);
    }
    
    internal static async Task<Result<TValue>> Warn<TValue>(this Task<Result<TValue>> resultTask, IEnumerable<Warning> warnings)
    {
        var result = await resultTask;
        return result.Warn(warnings);
    }
}