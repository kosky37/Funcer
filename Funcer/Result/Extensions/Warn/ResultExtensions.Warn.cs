using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result Warn(WarningMessage warning)
        {
            return result.IsFailure ? result : result.WithWarning(warning);
        }
    }
}