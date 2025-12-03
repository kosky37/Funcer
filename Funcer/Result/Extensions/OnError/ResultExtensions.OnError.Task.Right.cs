using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            await onError(matchedErrors);
            
            return result;
        }

        public async Task<Result> OnError(string errorType, Func<Task> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            await onError();

            return result;
        }

        public async Task<Result> OnError(string errorType, Func<IEnumerable<ErrorMessage>, Task<Result>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
        
            var nextResult = await onError(matchedErrors);
        
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result.Failure(allErrors).WithContext(nextResult);
            }
        
            return result.WithContext(nextResult);
        }

        public async Task<Result> OnError(string errorType, Func<Task<Result>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var matchedErrors = errorLookup[true].ToList();
            if (matchedErrors.Count == 0) return result;
            
            var nextResult = await onError();
        
            // Preserve original result, but combine errors if nextResult has errors
            if (nextResult.IsFailure)
            {
                var allErrors = result.Errors.Concat(nextResult.Errors).ToList();
                return Result.Failure(allErrors).WithContext(nextResult);
            }
        
            // Preserve original result unchanged, but preserve warnings from nextResult
            return result.WithContext(nextResult);
        }
    }
}

