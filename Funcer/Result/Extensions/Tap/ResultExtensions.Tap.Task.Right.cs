namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result> Tap(Func<Task<Result>> next)
        {
            return result.IsFailure ? result : (await next()).WithContext(result);
        }

        public async Task<Result> Tap<TValue>(Func<Task<Result<TValue>>> next)
        {
            if (result.IsFailure) return result;
            var nextResult = await next();
        
            return nextResult.IsFailure ? Result.Failure(nextResult.Errors) : Result.Success().WithContext(result).WithContext(nextResult);
        }

        public async Task<Result> Tap(Func<Task> next)
        {
            if (result.IsSuccess) await next();

            return result;
        }

        public async Task<Result> Tap<TValue>(Func<Task<TValue>> next)
        {
            if (result.IsFailure) return result;
            await next();
        
            return Result.Success().WithContext(result);
        }
    }
}