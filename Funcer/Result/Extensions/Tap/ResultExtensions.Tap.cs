namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result Tap(Func<Result> next)
        {
            return result.IsFailure ? result : next().WithContext(result);
        }

        public Result Tap<TValue>(Func<Result<TValue>> next)
        {
            if (result.IsFailure) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success().WithContext(result).WithContext(nextResult);
        }

        public Result Tap(Action next)
        {
            if (result.IsSuccess) next();

            return result;
        }

        public Result Tap<TValue>(Func<TValue> next)
        {
            if (result.IsFailure) return result;
            next();
        
            return Result.Success().WithContext(result);
        }
    }
}