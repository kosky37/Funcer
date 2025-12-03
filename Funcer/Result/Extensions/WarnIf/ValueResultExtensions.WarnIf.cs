using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> WarnIf(bool condition, WarningMessage warning)
        {
            return result.IsFailure || condition ? result : result.WithWarning(warning);
        }

        public Result<TValue> WarnIf(Func<bool> condition, WarningMessage warning)
        {
            return result.IsFailure || condition() ? result : result.WithWarning(warning);
        }

        public Result<TValue> WarnIf(Func<TValue, bool> condition, WarningMessage warning)
        {
            return result.IsFailure || condition(result.Value!) ? result : result.WithWarning(warning);
        }
    }
}