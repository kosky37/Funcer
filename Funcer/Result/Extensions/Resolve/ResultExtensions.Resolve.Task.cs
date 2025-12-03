using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task Resolve(Func<Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Func<Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Func<Task> onSuccess, Func<Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Func<Task> onSuccess, Action onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action onSuccess, Func<Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Action onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Func<Task> onFailure)
        {
            var result = await resultTask;

            await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, TReturnValue onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(TReturnValue onSuccess, Task<TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, TReturnValue onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
        {
            var result = await resultTask;

            return await result.Resolve(onSuccess, onFailure);
        }
    }
}