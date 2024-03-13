using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
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