namespace Funcer;

public readonly partial struct Result
{
    public static Result Combine(params IEnumerable<IResult> results)
    {
        var errors = results.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Count is not 0 ? Failure(errors) : Success();
    }
}