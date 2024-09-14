using Funcer.Messages;

namespace Funcer;

public static partial class  ResultExtensions
{
    public static Result WarnIf(this Result result, bool condition, WarningMessage warning)
    {
        return result.IsFailure || condition ? result : result.WithWarning(warning);
    }
    
    public static Result WarnIf(this Result result, Func<bool> condition, WarningMessage warning)
    {
        return result.IsFailure || condition() ? result : result.WithWarning(warning);
    }
}