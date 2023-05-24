namespace Funcer;

public partial class Result<TValue>
{
    public static Result<TValue> Failure(Error error)
    {
        return new Result<TValue>(error);
    }
    
    public static Result<TValue> Failure(IList<Error> errors)
    {
        return new Result<TValue>(errors);
    }
}