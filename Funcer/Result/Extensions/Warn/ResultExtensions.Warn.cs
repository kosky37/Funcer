using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static Result Warn(this Result result, WarningMessage warning)
    {
        return result.IsFailure ? result : result.WithWarning(warning);
    }
}