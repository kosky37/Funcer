using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public Result<TValue> HandleError(string errorType,
            Func<IEnumerable<ErrorMessage>, Result<TValue>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
        
            var newResult = onError(handledErrors);
        
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result<TValue>.Failure(remainingErrors) : newResult;
        }

        public Result<TValue> HandleError(string errorType, Func<IEnumerable<ErrorMessage>, TValue> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
        
            var newValue = onError(handledErrors);
            
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
        }

        public Result<TValue> HandleError(string errorType, Func<Result<TValue>> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
            
            var newResult = onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result<TValue>.Failure(remainingErrors) : newResult;
        }

        public Result<TValue> HandleError(string errorType, Func<TValue> onError)
        {
            if (result.IsSuccess) return result;
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return result;
            
            var newValue = onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result<TValue>.Failure(remainingErrors) : Result.Success(newValue);
        }

        public Result HandleError(string errorType, Func<IEnumerable<ErrorMessage>, Result> onError)
        {
            if (result.IsSuccess) return Result.Success().WithContext(result);
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return Result.Failure(result.Errors);
        
            var newResult = onError(handledErrors);
            
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : newResult;
        }

        public Result HandleError(string errorType, Action<IEnumerable<ErrorMessage>> onError)
        {
            if (result.IsSuccess) return Result.Success().WithContext(result);
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);
        
            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return Result.Failure(result.Errors);
        
            onError(handledErrors);
            
            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : Result.Success();
        }

        public Result HandleError(string errorType, Func<Result> onError)
        {
            if (result.IsSuccess) return Result.Success().WithContext(result);
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return Result.Failure(result.Errors);
            
            var newResult = onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : newResult;
        }

        public Result HandleError(string errorType, Action onError)
        {
            if (result.IsSuccess) return Result.Success().WithContext(result);
        
            var errorLookup = result.Errors.ToLookup(e => e.Type == errorType);

            var handledErrors = errorLookup[true].ToList();
            if (handledErrors.Count == 0) return Result.Failure(result.Errors);
            
            onError();

            var remainingErrors = errorLookup[false].ToList();
            return remainingErrors.Count != 0 ? Result.Failure(remainingErrors) : Result.Success();
        }
    }
}