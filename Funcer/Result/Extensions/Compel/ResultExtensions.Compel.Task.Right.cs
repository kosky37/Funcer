using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public async Task Compel(Func<IEnumerable<ErrorMessage>, Task<Exception>> exception)
        {
            if (result.IsFailure) throw await exception(result.Errors);
        }
    }
}