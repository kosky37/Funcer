namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, bool condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : condition ? result : Result<TValue>.Failure(error);
    }
    
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, Func<bool> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : condition() ? result : Result<TValue>.Failure(error);
    }
    
    public static Result<TValue> Ensure<TValue>(this Result<TValue> result, Func<TValue, bool> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : condition(result.Value!) ? result : Result<TValue>.Failure(error);
    }
}