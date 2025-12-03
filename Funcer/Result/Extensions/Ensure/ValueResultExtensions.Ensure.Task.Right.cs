using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<Result<TValue>> Ensure(Func<Task<bool>> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : await condition() ? result : Result<TValue>.Failure(error);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<bool>> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : await condition(result.Value!) ? result : Result<TValue>.Failure(error);
        }
    }
}