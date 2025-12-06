using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Task<Result<TValue>> resultTask)
    {
        public async Task<Result<TValue>> Ensure(Func<Task<bool>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return await result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<bool>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return await result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<Task<Result<bool>>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return await result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<Result<bool>>> condition, ErrorMessage error)
        {
            var result = await resultTask;
            return await result.Ensure(condition, error);
        }

        public async Task<Result<TValue>> Ensure(Func<Task<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return await result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<bool>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return await result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Func<Task<Result<bool>>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return await result.Ensure(condition, errorFactory);
        }

        public async Task<Result<TValue>> Ensure(Func<TValue, Task<Result<bool>>> condition, Func<TValue, ErrorMessage> errorFactory)
        {
            var result = await resultTask;
            return await result.Ensure(condition, errorFactory);
        }
    }
}