using Funcer.Exceptions;
using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task Compel()
        {
            var result = await resultTask;
            if (result.IsFailure) throw new FailureResultException(result.Errors);
        }

        public async Task Compel(Func<IEnumerable<ErrorMessage>, Task<Exception>> exception)
        {
            var result = await resultTask;
            if (result.IsFailure) throw await exception(result.Errors);
        }
    }
}