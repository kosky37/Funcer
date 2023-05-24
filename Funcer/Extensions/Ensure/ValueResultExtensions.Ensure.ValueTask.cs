namespace Funcer;

//TODO: add tests
public static partial class ValueResultExtensions
{
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this Result<TValue> result, Func<ValueTask<bool>> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result<TValue>.Failure(error);
    }
    
    public static async ValueTask<Result<TValue>> Ensure<TValue>(this Result<TValue> result, Func<TValue, ValueTask<bool>> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : await condition(result.Value!) ? result : Result<TValue>.Failure(error);
    }
}