using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_Ensure
{
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, bool condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : condition ? result : Result<TValue>.Failure(error);
    }
    
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, Func<bool> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : condition() ? result : Result<TValue>.Failure(error);
    }
    
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, Func<TValue, bool> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : condition(result.Value!) ? result : Result<TValue>.Failure(error);
    }
}