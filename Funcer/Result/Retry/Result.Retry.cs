namespace Funcer;

public readonly partial struct Result
{
    public static Result Retry(Func<int, Result> operation, string errorType, int maxTries)
    {
        var attemptNumber = 0;
        Result result;
        
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
    
    public static async Task<Result> Retry(Func<int, Task<Result>> operation, string errorType, int maxTries)
    {
        var attemptNumber = 0;
        Result result;
        
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
