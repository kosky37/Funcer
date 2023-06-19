using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Warn_ValueTask
{
    public static async ValueTask<Result> Warn(this ValueTask<Result> resultValueTask, WarningMessage warning)
    {
        var result = await resultValueTask;
        return result.Warn(warning);
    }
    
    public static async ValueTask<Result> Warn(this ValueTask<Result> resultValueTask, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultValueTask;
        return result.Warn(warnings);
    }
}