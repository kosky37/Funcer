using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> Warn(WarningMessage warning)
        {
            var result = await resultTask;
            return result.Warn(warning);
        }
    }
}