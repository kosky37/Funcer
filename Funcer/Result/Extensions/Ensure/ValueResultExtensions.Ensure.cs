using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> Ensure(bool condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : condition ? result : Result<TValue>.Failure(error);
        }

        public Result<TValue> Ensure(Func<bool> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : condition() ? result : Result<TValue>.Failure(error);
        }

        public Result<TValue> Ensure(Func<TValue, bool> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : condition(result.Value!) ? result : Result<TValue>.Failure(error);
        }
    }
}