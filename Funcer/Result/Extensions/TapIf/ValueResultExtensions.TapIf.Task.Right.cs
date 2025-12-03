namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<Result<TValue>> TapIf(bool condition, Func<Task<Result<TValue>>> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = await next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<Task<Result<TValue>>> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = await next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<Task<Result<TValue>>> next)
        {
            if (result.IsFailure || !condition(result.Value!)) return result;
            var nextResult = await next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Func<TValue, Task<Result>> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<TValue, Task<Result>> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<TValue, Task<Result>> next)
        {
            if (result.IsFailure || !condition(result.Value!)) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf(bool condition, Func<Task> next)
        {
            if (result.IsSuccess && condition) await next();
    
            return result;
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<Task> next)
        {
            if (result.IsSuccess && condition()) await next();
    
            return result;
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<Task> next)
        {
            if (result.IsSuccess && condition(result.Value!)) await next();
    
            return result;
        }

        public async Task<Result<TValue>> TapIf(bool condition, Func<TValue, Task> next)
        {
            if (result.IsSuccess && condition) await next(result.Value!);

            return result;
        }

        public async Task<Result<TValue>> TapIf(Func<bool> condition, Func<TValue, Task> next)
        {
            if (result.IsSuccess && condition()) await next(result.Value!);

            return result;
        }

        public async Task<Result<TValue>> TapIf(Func<TValue, bool> condition, Func<TValue, Task> next)
        {
            if (result.IsSuccess && condition(result.Value!)) await next(result.Value!);

            return result;
        }

        public async Task<Result<TValue>> TapIf<TValue2>(bool condition, Func<TValue, Task<Result<TValue2>>> next)
        {
            if (result.IsFailure || !condition) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<bool> condition, Func<TValue, Task<Result<TValue2>>> next)
        {
            if (result.IsFailure || !condition()) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<TValue, bool> condition, Func<TValue, Task<Result<TValue2>>> next)
        {
            if (result.IsFailure || !condition(result.Value!)) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> TapIf<TValue2>(bool condition, Func<Task<TValue2>> next)
        {
            if (result.IsSuccess && condition) await next();

            return result;
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<bool> condition, Func<Task<TValue2>> next)
        {
            if (result.IsSuccess && condition()) await next();

            return result;
        }

        public async Task<Result<TValue>> TapIf<TValue2>(Func<TValue, bool> condition, Func<Task<TValue2>> next)
        {
            if (result.IsSuccess && condition(result.Value!)) await next();

            return result;
        }
    }
}