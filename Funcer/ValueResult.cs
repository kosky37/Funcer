namespace Funcer;

public partial class Result<TValue> : IResult
{
    private Result(TValue value)
    {
        Value = value;
    }
    
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

    public TValue? Value { get; }
    public IList<Error> Errors { get; } = new List<Error>();
}