using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> Ensure(Func<Task<bool>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return await result.Ensure(condition, error);
        }

        public async Task<Result> Ensure(Func<Task<Result<bool>>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return await result.Ensure(condition, error);
        }
    }
}