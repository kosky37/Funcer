using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> WarnIf(this Task<Result> resultTask, bool condition, WarningMessage warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result> WarnIf(this Task<Result> resultTask, Func<bool> condition, WarningMessage warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result> WarnIf(this Task<Result> resultTask, bool condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
    
    public static async Task<Result> WarnIf(this Task<Result> resultTask, Func<bool> condition, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
}