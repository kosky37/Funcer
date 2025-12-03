namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> Tap(Func<Result<TValue>> next)
        {
            if (result.IsFailure) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> Tap(Func<TValue, Result> next)
        {
            if (result.IsFailure) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> Tap(Action next)
        {
            if (result.IsSuccess) next();
    
            return result;
        }

        public Result<TValue> Tap(Action<TValue> next)
        {
            if (result.IsSuccess) next(result.Value!);

            return result;
        }

        public Result<TValue> Tap<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            if (result.IsFailure) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> Tap<TValue2>(Func<TValue2> next)
        {
            if (result.IsSuccess) next();

            return result;
        }
    }
}