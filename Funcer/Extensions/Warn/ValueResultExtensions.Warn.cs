using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Warn
{
    public static Result<TValue> Warn<TValue>(this Result<TValue> result, WarningMessage warning)
    {
        return result.IsFailure ? result : result.WithWarning(warning);
    }
    
    internal static Result<TValue> Warn<TValue>(this Result<TValue> result, IEnumerable<WarningMessage> warnings)
    {
        return result.IsFailure ? result : result.WithWarnings(warnings);
    }
}