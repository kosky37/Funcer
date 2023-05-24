namespace Funcer;

public partial class Result
{
    public static Result<TValue> Failure<TValue>(Error error)
    {
        return Result<TValue>.Failure(error);
    }
    
    public static Result<TValue> Failure<TValue>(IList<Error> errors)
    {
        return Result<TValue>.Failure(errors);
    }
}