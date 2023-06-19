using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Ensure_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this Result<TValue> result, Func<ValueTask<bool>> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result<TValue>.Failure(error);
    }
    
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this Result<TValue> result, Func<TValue, ValueTask<bool>> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : await condition(result.Value!) ? result : Result<TValue>.Failure(error);
    }
}