using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Result> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
        
            var newResult = onError(handledErrors);
            
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : newResult;
        }

        public Result HandleError(string errorType, Action<IEnumerable<ErrorMessage>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
        
            onError(handledErrors);
            
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : Result.Success();
        }

        public Result HandleError(string errorType, Func<Result> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
            
            var newResult = onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : newResult;
        }

        public Result HandleError(string errorType, Action onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
            
            onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : Result.Success();
        }
    }
}