namespace Funcer;

public partial struct Result
{
    public static Result Combine(IEnumerable<Result> results)
    {
        var errors = results.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() ? Failure(errors) : Success();
    }
    
    public static Result Combine(params Result[] results)
    {
        var errors = results.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        return errors.Any() ? Failure(errors) : Success();
    }
}