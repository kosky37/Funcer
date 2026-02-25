namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        // bool condition - Mixed async/sync overloads (onTrue sync, onFalse async)

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Result<TValue>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<TValue> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<TValue> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Result<TValue>> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Func<bool> condition - Mixed async/sync overloads (onTrue sync, onFalse async)

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Result<TValue>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<TValue> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<TValue> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Result<TValue>> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }
    }
}
