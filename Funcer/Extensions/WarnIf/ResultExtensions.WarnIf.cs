using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_WarnIf
{
    public static Result WarnIf(this Result result, bool condition, WarningMessage warning)
    {
        return result.IsFailure || condition ? result : result.WithWarning(warning);
    }
    
    public static Result WarnIf(this Result result, Func<bool> condition, WarningMessage warning)
    {
        return result.IsFailure || condition() ? result : result.WithWarning(warning);
    }
    
    public static Result WarnIf(this Result result, bool condition, IEnumerable<WarningMessage> warnings)
    {
        return result.IsFailure || condition ? result : result.WithWarnings(warnings);
    }
    
    public static Result WarnIf(this Result result, Func<bool> condition, IEnumerable<WarningMessage> warnings)
    {
        return result.IsFailure || condition() ? result : result.WithWarnings(warnings);
    }
}