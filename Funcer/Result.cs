namespace Funcer;

public partial class Result : IResult
{
    private Result() { }

    private Result(Error error)
    {
        IsFailure = true;
        Errors.Add(error);
    }
    
    private Result(IList<Error> errors)
    {
        IsFailure = true;
        Errors = errors;
    }

    public bool IsFailure { get; }
    public bool IsSuccess => !IsFailure;

    public IList<Error> Errors { get; } = new List<Error>();
}