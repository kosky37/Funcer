using Funcer.Messages;

namespace Funcer;

[ValueTaskVariantGenerator]
public static class ValueResultExtensions_Log_Task_Right
{
    public static async Task<Result<TValue>> Log<TValue>(this Result<TValue> result, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        
        return result;
    }
    
    public static async Task<Result<TValue>> Log<TValue>(this Result<TValue> result, Func<Task> onFailure)
    {
        if (result.IsFailure) await onFailure();
        
        return result;
    }
}