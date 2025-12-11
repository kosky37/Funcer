namespace Funcer;

public readonly partial struct Result
{
    public static Result<TValue> Retry<TValue>(Func<int, Result<TValue>> operation, string errorType, int maxTries)
    {
        var attemptNumber = 0;
        Result<TValue> result;
        
        do
        {
            attemptNumber++;
            result = operation(attemptNumber);
            
            if (result.IsSuccess || result.Errors.Any(x => x.Type != errorType))
            {
                return result;
            }
        }
        while (attemptNumber < maxTries);
        
        return result;
    }
    
    public static async Task<Result<TValue>> Retry<TValue>(Func<int, Task<Result<TValue>>> operation, string errorType, int maxTries)
    {
        var attemptNumber = 0;
        Result<TValue> result;
        
        do
        {
            attemptNumber++;
            result = await operation(attemptNumber);
            
            if (result.IsSuccess || result.Errors.Any(x => x.Type != errorType))
            {
                return result;
            }
        }
        while (attemptNumber < maxTries);
        
        return result;
    }
}
