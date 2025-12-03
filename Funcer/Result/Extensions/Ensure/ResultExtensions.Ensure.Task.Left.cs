using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> Ensure(bool condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }

        public async Task<Result> Ensure(Func<bool> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return result.Ensure(condition, error);
        }
    }
}