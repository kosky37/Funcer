namespace Funcer;

public static partial class ResultExtensions_Ensure
{
    public static Result Ensure(this Result result, bool condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : condition ? result : Result.Failure(error);
    }
    
    public static Result Ensure(this Result result, Func<bool> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : condition() ? result : Result.Failure(error);
    }
}