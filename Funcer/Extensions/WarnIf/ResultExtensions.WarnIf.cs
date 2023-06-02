using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_WarnIf
{
    public static Result WarnIf(this Result result, bool condition, Warning warning)
    {
        return result.IsFailure || condition ? result : result.WithWarning(warning);
    }
    
    public static Result WarnIf(this Result result, Func<bool> condition, Warning warning)
    {
        return result.IsFailure || condition() ? result : result.WithWarning(warning);
    }
    
    public static Result WarnIf(this Result result, bool condition, IEnumerable<Warning> warnings)
    {
        return result.IsFailure || condition ? result : result.WithWarnings(warnings);
    }
    
    public static Result WarnIf(this Result result, Func<bool> condition, IEnumerable<Warning> warnings)
    {
        return result.IsFailure || condition() ? result : result.WithWarnings(warnings);
    }
}