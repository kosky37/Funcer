using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task<Result> Ensure(Func<Task<bool>> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : await condition() ? result : Result.Failure(error);
        }
    }
}