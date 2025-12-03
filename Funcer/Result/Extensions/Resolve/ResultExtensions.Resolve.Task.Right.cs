using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public Task Resolve(Func<Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            if (result.IsFailure) return onFailure(result.Errors);
            else return onSuccess();
        }

        public Task Resolve(Func<Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            if (result.IsFailure) onFailure(result.Errors);
            else return onSuccess();
            return Task.CompletedTask;
        }

        public Task Resolve(Action onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            if (result.IsFailure) return onFailure(result.Errors);
            else onSuccess();
            return Task.CompletedTask;
        }

        public Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            if (result.IsFailure) return onFailure(result.Errors);
            else return onSuccess(result.Warnings);
        }

        public Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            if (result.IsFailure) onFailure(result.Errors);
            else return onSuccess(result.Warnings);
            return Task.CompletedTask;
        }

        public Task Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
        {
            if (result.IsFailure) return onFailure(result.Errors);
            else onSuccess(result.Warnings);
            return Task.CompletedTask;
        }

        public Task Resolve(Func<Task> onSuccess, Func<Task> onFailure)
        {
            if (result.IsFailure) return onFailure();
            else return onSuccess();
        }

        public Task Resolve(Func<Task> onSuccess, Action onFailure)
        {
            if (result.IsFailure) onFailure();
            else return onSuccess();
            return Task.CompletedTask;
        }

        public Task Resolve(Action onSuccess, Func<Task> onFailure)
        {
            if (result.IsFailure) return onFailure();
            else onSuccess();
            return Task.CompletedTask;
        }

        public Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Func<Task> onFailure)
        {
            if (result.IsFailure) return onFailure();
            else return onSuccess(result.Warnings);
        }

        public Task Resolve(Func<IEnumerable<WarningMessage>, Task> onSuccess, Action onFailure)
        {
            if (result.IsFailure) onFailure();
            else return onSuccess(result.Warnings);
            return Task.CompletedTask;
        }

        public Task Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Func<Task> onFailure)
        {
            if (result.IsFailure) return onFailure();
            else onSuccess(result.Warnings);
            return Task.CompletedTask;
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            return result.IsFailure ? await onFailure(result.Errors) : await onSuccess();
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            return result.IsFailure ? onFailure(result.Errors) : await onSuccess();
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            return result.IsFailure ? await onFailure(result.Errors) : onSuccess();
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            return result.IsFailure ? await onFailure(result.Errors) : await onSuccess(result.Warnings);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            return result.IsFailure ? onFailure(result.Errors) : await onSuccess(result.Warnings);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            return result.IsFailure ? await onFailure(result.Errors) : onSuccess(result.Warnings);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            return result.IsFailure ? await onFailure(result.Errors) : await onSuccess;
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            return result.IsFailure ? onFailure(result.Errors) : await onSuccess;
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
        {
            return result.IsFailure ? await onFailure(result.Errors) : onSuccess;
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
        {
            return result.IsFailure ? await onFailure : await onSuccess;
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Task<TReturnValue> onSuccess, TReturnValue onFailure)
        {
            return result.IsFailure ? onFailure : await onSuccess;
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(TReturnValue onSuccess, Task<TReturnValue> onFailure)
        {
            return result.IsFailure ? await onFailure : onSuccess;
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
        {
            return result.IsFailure ? await onFailure : await onSuccess();
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<Task<TReturnValue>> onSuccess, TReturnValue onFailure)
        {
            return result.IsFailure ? onFailure : await onSuccess();
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
        {
            return result.IsFailure ? await onFailure : onSuccess();
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
        {
            return result.IsFailure ? await onFailure : await onSuccess(result.Warnings);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
        {
            return result.IsFailure ? onFailure : await onSuccess(result.Warnings);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
        {
            return result.IsFailure ? await onFailure : onSuccess(result.Warnings);
        }
    }
}