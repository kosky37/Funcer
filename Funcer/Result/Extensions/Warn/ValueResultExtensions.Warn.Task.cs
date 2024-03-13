using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Warn<TValue>(this Task<Result<TValue>> resultTask, WarningMessage warning)
    {
        var result = await resultTask;
        return result.Warn(warning);
    }
    
    internal static async Task<Result<TValue>> Warn<TValue>(this Task<Result<TValue>> resultTask, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultTask;
        return result.Warn(warnings);
    }
}