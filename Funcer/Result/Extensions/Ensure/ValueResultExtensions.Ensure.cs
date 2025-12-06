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

        public Result<TValue> Ensure(Result<bool> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            if (condition.IsFailure)
                return Result<TValue>.Failure(condition.Errors);
            
            return condition.Value ? result : Result<TValue>.Failure(error);
        }

        public Result<TValue> Ensure(Func<Result<bool>> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = condition();
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(error);
        }

        public Result<TValue> Ensure(Func<TValue, Result<bool>> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = condition(result.Value!);
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(error);
        }

        public Result<TValue> Ensure(bool condition, Func<TValue, ErrorMessage> errorFactory)
        {
            return result.IsFailure 
                ? result 
                : condition ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public Result<TValue> Ensure(Func<bool> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            return result.IsFailure 
                ? result 
                : condition() ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public Result<TValue> Ensure(Func<TValue, bool> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            return result.IsFailure 
                ? result 
                : condition(result.Value!) ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public Result<TValue> Ensure(Result<bool> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            if (result.IsFailure) return result;
            
            if (condition.IsFailure)
                return Result<TValue>.Failure(condition.Errors);
            
            return condition.Value ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public Result<TValue> Ensure(Func<Result<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = condition();
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }

        public Result<TValue> Ensure(Func<TValue, Result<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = condition(result.Value!);
            if (conditionResult.IsFailure)
                return Result<TValue>.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result<TValue>.Failure(errorFactory(result.Value!));
        }
    }
}