namespace Funcer;

public partial class Result
{
    public static Result Failure(Error error)
    {
        return new Result(error);
    }
    
    public static Result Failure(IList<Error> errors)
    {
        return new Result(errors);
    }
}