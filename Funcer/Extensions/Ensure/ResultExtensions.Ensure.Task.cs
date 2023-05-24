namespace Funcer;

//TODO: add tests
public static partial class ResultExtensions
{
    public static async Task<Result> Ensure(this Result result, Func<Task<bool>> condition, Error error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result.Failure(error);
    }
}