using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result OnError(string errorType, Func<IEnumerable<ErrorMessage>, Result> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            var nextResult = onError(matchedErrors);
        
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result.Failure(allErrors).WithContext(nextResult);
            }
        
            return result.WithContext(nextResult);
        }

        public Result OnError(string errorType, Action<IEnumerable<ErrorMessage>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            onError(matchedErrors);
        
            return result;
        }

        public Result OnError(string errorType, Func<Result> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            var nextResult = onError();
        
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result.Failure(allErrors).WithContext(nextResult);
            }
        
            return result.WithContext(nextResult);
        }

        public Result OnError(string errorType, Action onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            onError();

            return result;
        }
    }
}

