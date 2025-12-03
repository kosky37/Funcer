namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<Result<TValue>> Tap(Func<Task<Result<TValue>>> next)
        {
            if (result.IsFailure) return result;
            var nextResult = await next();
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> Tap(Func<TValue, Task<Result>> next)
        {
            if (result.IsFailure) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> Tap(Func<Task> next)
        {
            if (result.IsSuccess) await next();
    
            return result;
        }

        public async Task<Result<TValue>> Tap(Func<TValue, Task> next)
        {
            if (result.IsSuccess) await next(result.Value!);

            return result;
        }

        public async Task<Result<TValue>> Tap<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            if (result.IsFailure) return result;
            var nextResult = await next(result.Value!);
        
            return nextResult.IsFailure ? Result<TValue>.Failure(nextResult.Errors) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> Tap<TValue2>(Func<Task<TValue2>> next)
        {
            if (result.IsSuccess) await next();

            return result;
        }
    }
}