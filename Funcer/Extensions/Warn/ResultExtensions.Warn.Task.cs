using Funcer.Generator.Attributes;
using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ResultExtensions_Warn_Task
{
    public static async Task<Result> Warn(this Task<Result> resultTask, WarningMessage warning)
    {
        var result = await resultTask;
        return result.Warn(warning);
    }
    
    public static async Task<Result> Warn(this Task<Result> resultTask, IEnumerable<WarningMessage> warnings)
    {
        var result = await resultTask;
        return result.Warn(warnings);
    }
}