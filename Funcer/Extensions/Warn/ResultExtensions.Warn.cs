using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Warn
{
    public static Result Warn(this Result result, WarningMessage warning)
    {
        return result.IsFailure ? result : result.WithWarning(warning);
    }
    
    public static Result Warn(this Result result, IEnumerable<WarningMessage> warnings)
    {
        return result.IsFailure ? result : result.WithWarnings(warnings);
    }
}