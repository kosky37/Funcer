using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<Result<TValue>> Side(Func<Task<Result>> next)
        {
            if (result.IsFailure) return result;

            var nextResult = await next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> Side(Func<TValue, Task<Result>> next)
        {
            if (result.IsFailure) return result;

            var nextResult = await next(result.Value);

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> Side<TValue2>(Func<Task<Result<TValue2>>> next)
        {
            if (result.IsFailure) return result;
        
            var nextResult = await next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> Side<TValue2>(Func<TValue, Task<Result<TValue2>>> next)
        {
            if (result.IsFailure) return result;
        
            var nextResult = await next(result.Value);

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }
    }
}