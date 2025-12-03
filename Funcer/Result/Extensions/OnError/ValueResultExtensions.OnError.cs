using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> OnError<TValue2>(string errorType,
            Func<IEnumerable<ErrorMessage>, Result<TValue2>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            var nextResult = onError(matchedErrors);
        
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result<TValue>.Failure(allErrors).WithContext(nextResult);
            }
        
            return result.WithContext(nextResult);
        }

        public Result<TValue> OnError<TValue2>(string errorType, Func<IEnumerable<ErrorMessage>, TValue2> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            onError(matchedErrors);
        
            return result;
        }

        public Result<TValue> OnError<TValue2>(string errorType, Func<Result<TValue2>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            var nextResult = onError();
        
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result<TValue>.Failure(allErrors).WithContext(nextResult);
            }
        
            return result.WithContext(nextResult);
        }

        public Result<TValue> OnError<TValue2>(string errorType, Func<TValue2> onError)
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

