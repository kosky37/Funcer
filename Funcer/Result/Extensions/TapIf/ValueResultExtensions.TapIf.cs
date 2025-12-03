namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> TapIf(bool condition, Func<Result<TValue>> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf(Func<bool> condition, Func<Result<TValue>> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf(Func<TValue, bool> condition, Func<Result<TValue>> next)
        {
            if (result.IsFailure || !condition(result.Value!)) return result;
            var nextResult = next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf(bool condition, Func<TValue, Result> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf(Func<bool> condition, Func<TValue, Result> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf(Func<TValue, bool> condition, Func<TValue, Result> next)
        {
            if (result.IsFailure || !condition(result.Value!)) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf(bool condition, Action next)
        {
            if (result.IsSuccess && condition) next();
    
            return result;
        }

        public Result<TValue> TapIf(Func<bool> condition, Action next)
        {
            if (result.IsSuccess && condition()) next();
    
            return result;
        }

        public Result<TValue> TapIf(Func<TValue, bool> condition, Action next)
        {
            if (result.IsSuccess && condition(result.Value!)) next();
    
            return result;
        }

        public Result<TValue> TapIf(bool condition, Action<TValue> next)
        {
            if (result.IsSuccess && condition) next(result.Value!);

            return result;
        }

        public Result<TValue> TapIf(Func<bool> condition, Action<TValue> next)
        {
            if (result.IsSuccess && condition()) next(result.Value!);

            return result;
        }

        public Result<TValue> TapIf(Func<TValue, bool> condition, Action<TValue> next)
        {
            if (result.IsSuccess && condition(result.Value!)) next(result.Value!);

            return result;
        }

        public Result<TValue> TapIf<TValue2>(bool condition, Func<TValue, Result<TValue2>> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> next)
        {
            if (result.IsFailure || !condition(result.Value!)) return result;
            var nextResult = next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public Result<TValue> TapIf<TValue2>(bool condition, Func<TValue2> next)
        {
            if (result.IsSuccess && condition) next();

            return result;
        }

        public Result<TValue> TapIf<TValue2>(Func<bool> condition, Func<TValue2> next)
        {
            if (result.IsSuccess && condition()) next();

            return result;
        }

        public Result<TValue> TapIf<TValue2>(Func<TValue, bool> condition, Func<TValue2> next)
        {
            if (result.IsSuccess && condition(result.Value!)) next();

            return result;
        }
    }
}