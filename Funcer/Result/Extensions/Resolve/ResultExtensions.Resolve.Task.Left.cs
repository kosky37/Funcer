using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Task<Result> resultTask)
    {
        public async Task Resolve(Action onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            var result = await resultTask;
        
            result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            var result = await resultTask;
        
            result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action onSuccess, Action onFailure)
        {
            var result = await resultTask;
        
            result.Resolve(onSuccess, onFailure);
        }

        public async Task Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Action onFailure)
        {
            var result = await resultTask;
        
            result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            var result = await resultTask;
        
            return result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            var result = await resultTask;
        
            return result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            var result = await resultTask;
        
            return result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(TReturnValue onSuccess, TReturnValue onFailure)
        {
            var result = await resultTask;
        
            return result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<TReturnValue> onSuccess, TReturnValue onFailure)
        {
            var result = await resultTask;
        
            return result.Resolve(onSuccess, onFailure);
        }

        public async Task<TReturnValue> Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
        {
            var result = await resultTask;
        
            return result.Resolve(onSuccess, onFailure);
        }
    }
}