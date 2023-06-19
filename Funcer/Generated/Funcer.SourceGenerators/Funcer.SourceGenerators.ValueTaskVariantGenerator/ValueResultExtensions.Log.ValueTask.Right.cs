using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Log_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> Log<TValue>(this Result<TValue> result, Func<IEnumerable<ErrorMessage>, ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure(result.Errors);
        
        return result;
    }
    
    public static async ValueTask<Result<TValue>> Log<TValue>(this Result<TValue> result, Func<ValueTask> onFailure)
    {
        if (result.IsFailure) await onFailure();
        
        return result;
    }
}