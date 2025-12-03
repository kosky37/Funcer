using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task Compel(Func<IEnumerable<ErrorMessage>, Exception> exception)
        {
            var result = await resultTask;
            if (result.IsFailure) throw exception(result.Errors);
        }
    }
}