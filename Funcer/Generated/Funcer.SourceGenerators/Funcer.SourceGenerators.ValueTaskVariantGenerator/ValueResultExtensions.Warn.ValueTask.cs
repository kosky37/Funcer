using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Warn_ValueTask
{
    public static async ValueTask<Result<TValue>> Warn<TValue>(this ValueTask<Result<TValue>> resultValueTask, WarningMessage warning)
    {
        var result = await resultValueTask;
        return result.Warn(warning);
    }
    
    internal static async ValueTask<Result<TValue>> Warn<TValue>(this ValueTask<Result<TValue>> resultValueTask, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultValueTask;
        return result.Warn(warnings);
    }
}