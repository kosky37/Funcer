using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_WarnIf_ValueTask
{
    public static async ValueTask<Result<TValue>> WarnIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, WarningMessage warning)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async ValueTask<Result<TValue>> WarnIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, WarningMessage warning)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async ValueTask<Result<TValue>> WarnIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, WarningMessage warning)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warning);
    }
    
    internal static async ValueTask<Result<TValue>> WarnIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, bool condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warnings);
    }
    
    internal static async ValueTask<Result<TValue>> WarnIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<bool> condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warnings);
    }
    
    internal static async ValueTask<Result<TValue>> WarnIf<TValue>(this ValueTask<Result<TValue>> resultValueTask, Func<TValue, bool> condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warnings);
    }
}