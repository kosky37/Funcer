using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public async Task<Result<TValue>> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            await onError(matchedErrors);
        
            return result;
        }
        
        public async Task<Result<TValue>> OnError(string errorType, Func<Task> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            await onError();

            return result;
        }
        
        
        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<IEnumerable<ErrorMessage>, Task<TValue2>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            await onError(matchedErrors);
        
            return result;
        }

        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<Task<TValue2>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            await onError();

            return result;
        }

        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<IEnumerable<ErrorMessage>, Task<Result<TValue2>>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            var nextResult = await onError(matchedErrors);
        
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result<TValue>.Failure(allErrors).WithContext(nextResult);
            }
        
            return result.WithContext(nextResult);
        }

        public async Task<Result<TValue>> OnError<TValue2>(string errorType, Func<Task<Result<TValue2>>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            var nextResult = await onError();
        
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result<TValue>.Failure(allErrors).WithContext(nextResult);
            }
        
            return result.WithContext(nextResult);
        }
    }
}

