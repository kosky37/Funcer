using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result Side(Func<Result> next)
        {
            if (result.IsFailure) return result;

            var nextResult = next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }

        public Result Side<TValue>(Func<Result<TValue>> next)
        {
            if (result.IsFailure) return result;
        
            var nextResult = next();

            return nextResult.IsFailure ? result.WithWarnings(nextResult.Errors.Select(error => new WarningMessage(error))) : result.WithContext(nextResult);
        }
    }
}