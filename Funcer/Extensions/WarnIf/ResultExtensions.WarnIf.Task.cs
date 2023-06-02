using Funcer.Generator.Attributes;
using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_WarnIf_Task
{
    public static async Task<Result> WarnIf(this Task<Result> resultTask, bool condition, Warning warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result> WarnIf(this Task<Result> resultTask, Func<bool> condition, Warning warning)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warning);
    }
    
    public static async Task<Result> WarnIf(this Task<Result> resultTask, bool condition, IEnumerable<Warning> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
    
    public static async Task<Result> WarnIf(this Task<Result> resultTask, Func<bool> condition, IEnumerable<Warning> warnings)
    {
        var result = await resultTask;
        return result.WarnIf(condition, warnings);
    }
}