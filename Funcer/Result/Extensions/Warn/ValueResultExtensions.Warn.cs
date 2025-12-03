using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> Warn(WarningMessage warning)
        {
            return result.IsFailure ? result : result.WithWarning(warning);
        }
    }
}