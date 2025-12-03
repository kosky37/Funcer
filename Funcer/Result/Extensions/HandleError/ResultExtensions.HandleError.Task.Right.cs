using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Task> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
        
            await onError(handledErrors);
            
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : Result.Success();
        }

        public async Task<Result> HandleError(string errorType, Func<Task> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
            
            await onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : Result.Success();
        }

        public async Task<Result> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Task<Result>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
        
            var newResult = await onError(handledErrors);
            
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : newResult;
        }

        public async Task<Result> HandleError(string errorType, Func<Task<Result>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
            
            var newResult = await onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : newResult;
        }
    }
}