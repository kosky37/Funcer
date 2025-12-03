using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> Side(Func<Result> next)
        {
            if (result.IsFailure) return result;

            var nextResult = next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public Result<TValue> Side(Func<TValue, Result> next)
        {
            if (result.IsFailure) return result;

            var nextResult = next(result.Value);

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public Result<TValue> Side<TValue2>(Func<Result<TValue2>> next)
        {
            if (result.IsFailure) return result;
        
            var nextResult = next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public Result<TValue> Side<TValue2>(Func<TValue, Result<TValue2>> next)
        {
            if (result.IsFailure) return result;

            var nextResult = next(result.Value);

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }
    }
}