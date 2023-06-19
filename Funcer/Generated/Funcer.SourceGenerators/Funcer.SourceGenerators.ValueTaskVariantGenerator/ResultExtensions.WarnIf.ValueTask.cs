using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_WarnIf_ValueTask
{
    public static async ValueTask<Result> WarnIf(this ValueTask<Result> resultValueTask, bool condition, WarningMessage warning)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async ValueTask<Result> WarnIf(this ValueTask<Result> resultValueTask, Func<bool> condition, WarningMessage warning)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async ValueTask<Result> WarnIf(this ValueTask<Result> resultValueTask, bool condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warnings);
    }
    
    public static async ValueTask<Result> WarnIf(this ValueTask<Result> resultValueTask, Func<bool> condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultValueTask;
        return result.WarnIf(condition, warnings);
    }
}