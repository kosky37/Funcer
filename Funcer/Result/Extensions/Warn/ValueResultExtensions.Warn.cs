using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> Warn<TValue>(this Result<TValue> result, WarningMessage warning)
    {
        return result.IsFailure ? result : result.WithWarning(warning);
    }
}