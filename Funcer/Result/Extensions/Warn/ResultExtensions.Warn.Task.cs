using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Warn(this Task<Result> resultTask, WarningMessage warning)
    {
        var result = await resultTask;
        return result.Warn(warning);
    }
}