using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, WarningMessage warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, WarningMessage warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, WarningMessage warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    internal static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, bool condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
    
    internal static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<bool> condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
    
    internal static async Task<Result<TValue>> WarnIf<TValue>(this Task<Result<TValue>> resultTask, Func<TValue, bool> condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
}