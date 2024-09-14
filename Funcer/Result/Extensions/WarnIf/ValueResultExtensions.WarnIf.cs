using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> WarnIf<TValue>(this Result<TValue> result, bool condition, WarningMessage warning)
    {
        return result.IsFailure || condition ? result : result.WithWarning(warning);
    }
    
    public static Result<TValue> WarnIf<TValue>(this Result<TValue> result, Func<bool> condition, WarningMessage warning)
    {
        return result.IsFailure || condition() ? result : result.WithWarning(warning);
    }
    
    public static Result<TValue> WarnIf<TValue>(this Result<TValue> result, Func<TValue, bool> condition, WarningMessage warning)
    {
        return result.IsFailure || condition(result.Value!) ? result : result.WithWarning(warning);
    }
}