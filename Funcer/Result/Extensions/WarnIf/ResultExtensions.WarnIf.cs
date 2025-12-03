using Funcer.Messages;

namespace Funcer;

public static partial class  ResultExtensions
{
    extension(Result result)
    {
        public Result WarnIf(bool condition, WarningMessage warning)
        {
            return result.IsFailure || condition ? result : result.WithWarning(warning);
        }

        public Result WarnIf(Func<bool> condition, WarningMessage warning)
        {
            return result.IsFailure || condition() ? result : result.WithWarning(warning);
        }
    }
}