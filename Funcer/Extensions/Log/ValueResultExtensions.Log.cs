using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Log
{
    public static Result<TValue> Log<TValue>(this Result<TValue> result, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        
        return result;
    }
    
    public static Result<TValue> Log<TValue>(this Result<TValue> result, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        
        return result;
    }
}