using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result> Ensure(Func<Task<bool>> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : await condition() ? result : Result.Failure(error);
        }

        public async Task<Result> Ensure(Func<Task<Result<bool>>> condition, ErrorMessage error)
        {
            if (result.IsFailure) return result;
            
            var conditionResult = await condition();
            if (conditionResult.IsFailure)
                return Result.Failure(conditionResult.Errors);
            
            return conditionResult.Value ? result : Result.Failure(error);
        }
    }
}