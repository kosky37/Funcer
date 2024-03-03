using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Ensure
{
    public static Result Ensure(this Result result, bool condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : condition ? result : Result.Failure(error);
    }
    
    public static Result Ensure(this Result result, Func<bool> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : condition() ? result : Result.Failure(error);
    }
}