using Funcer.Messages;

namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        public void Resolve(Action onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            if (result.IsFailure) onFailure(result.Errors);
            else onSuccess();
        }

        public void Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
        {
            if (result.IsFailure) onFailure(result.Errors);
            else onSuccess(result.Warnings);
        }

        public void Resolve(Action onSuccess, Action onFailure)
        {
            if (result.IsFailure) onFailure();
            else onSuccess();
        }

        public void Resolve(Action<IEnumerable<WarningMessage>> onSuccess, Action onFailure)
        {
            if (result.IsFailure) onFailure();
            else onSuccess(result.Warnings);
        }

        public TReturnValue Resolve<TReturnValue>(Func<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            return result.IsFailure ? onFailure(result.Errors) : onSuccess();
        }

        public TReturnValue Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            return result.IsFailure ? onFailure(result.Errors) : onSuccess(result.Warnings);
        }

        public TReturnValue Resolve<TReturnValue>(TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
        {
            return result.IsFailure ? onFailure(result.Errors) : onSuccess;
        }

        public TReturnValue Resolve<TReturnValue>(TReturnValue onSuccess, TReturnValue onFailure)
        {
            return result.IsFailure ? onFailure : onSuccess;
        }

        public TReturnValue Resolve<TReturnValue>(Func<TReturnValue> onSuccess, TReturnValue onFailure)
        {
            return result.IsFailure ? onFailure : onSuccess();
        }

        public TReturnValue Resolve<TReturnValue>(Func<IEnumerable<WarningMessage>, TReturnValue> onSuccess, TReturnValue onFailure)
        {
            return result.IsFailure ? onFailure : onSuccess(result.Warnings);
        }
    }
}