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

        public async Task<Result<TValue>> Ensure(Func<Task<Result<bool>>> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = await condition();
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(error);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<Result<bool>>> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = await condition(result.Value!);
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(error);
        }

        public async Task<Result<TValue>> Ensure(Func<Task<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            return result.IsFailure 
                ? result 
                : await condition() ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            return result.IsFailure 
                ? result 
                : await condition(result.Value!) ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public async Task<Result<TValue>> Ensure(Func<Task<Result<bool>>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = await condition();
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<Result<bool>>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = await condition(result.Value!);
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }
    }
}