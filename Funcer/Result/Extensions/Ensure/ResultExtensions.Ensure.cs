using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Result Ensure(bool condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : condition ? result : Result.Failure(error);
        }

        public Result Ensure(Func<bool> condition, ErrorMessage error)
        {
            return result.IsFailure 
                ? result 
                : condition() ? result : Result.Failure(error);
        }
    }
}