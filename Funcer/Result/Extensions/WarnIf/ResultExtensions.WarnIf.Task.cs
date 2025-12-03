using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task<Result> WarnIf(bool condition, WarningMessage warning)
        {
            var result = await resultTask;
            return result.WarnIf(condition, warning);
        }

        public async Task<Result> WarnIf(Func<bool> condition, WarningMessage warning)
        {
            var result = await resultTask;
            return result.WarnIf(condition, warning);
        }
    }
}