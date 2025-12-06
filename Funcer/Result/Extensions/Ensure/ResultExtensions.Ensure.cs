using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result Ensure(bool condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : condition ? result : Result.Failure(error);
        }

        public Result Ensure(Func<bool> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : condition() ? result : Result.Failure(error);
        }

        public Result Ensure(Result<bool> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            if (condition.IsFailure)
                return Result.Failure(condition.Errors);
            
            return condition.Value ? result : Result.Failure(error);
        }

        public Result Ensure(Func<Result<bool>> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = condition();
            if (conditionResult.IsFailure)
                return Result.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result.Failure(error);
        }
    }
}