namespace Funcer;

//TODO: add tests
public static partial class ResultExtensions
{
    public static async ValueTask<Result> Ensure(this Result result, Func<ValueTask<bool>> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result.Failure(error);
    }
}