using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result> Side(Func<Task<Result>> next)
        {
            if (result.IsFailure) return result;

            var nextResult = await next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public async Task<Result> Side<TValue>(Func<Task<Result<TValue>>> next)
        {
            if (result.IsFailure) return result;
        
            var nextResult = await next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }
    }
}