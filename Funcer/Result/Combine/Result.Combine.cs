namespace Funcer;

public readonly partial struct Result
{
#if NET9_0_OR_GREATER
    public static Result Combine(params IEnumerable<IResult> results)
#else
    public static Result Combine(params IResult[] results)
    {
        var errors = results.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() ? Failure(errors) : Success();
    }
    
    public static Result Combine(IEnumerable<Result> results)
#endif
    {
        var errors = results.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() ? Failure(errors) : Success();
    }
}