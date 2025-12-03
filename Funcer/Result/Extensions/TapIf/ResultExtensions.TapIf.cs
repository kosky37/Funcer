namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result TapIf(bool condition, Func<Result> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
        }

        public Result TapIf(Func<bool> condition, Func<Result> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? nextResult : result.WithContext(nextResult);
        }

        public Result TapIf<TValue>(bool condition, Func<Result<TValue>> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result TapIf<TValue>(Func<bool> condition, Func<Result<TValue>> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result TapIf(bool condition, Action next)
        {
            if (result.IsSuccess && condition) next();

            return result;
        }

        public Result TapIf(Func<bool> condition, Action next)
        {
            if (result.IsSuccess && condition()) next();

            return result;
        }

        public Result TapIf<TValue>(bool condition, Func<TValue> next)
        {
            if (result.IsFailure || !condition) return result;
            next();
        
            return Result.Success().WithContext(result);
        }

        public Result TapIf<TValue>(Func<bool> condition, Func<TValue> next)
        {
            if (result.IsFailure || !condition()) return result;
            next();
        
            return Result.Success().WithContext(result);
        }
    }
}