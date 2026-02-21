namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        // bool condition overloads

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Task<Result<TValue>>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Task<TValue>> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Mixed overloads for bool condition

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Task<Result<TValue>>> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(bool condition, Func<Task<TValue>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        // Func<bool> condition overloads

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Task<Result<TValue>>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Task<TValue>> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        // Mixed overloads for Func<bool> condition

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Task<Result<TValue>>> onTrue, Func<Task<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? (await onTrue()).WithContext(result)
                : Result.Success(await onFalse()).WithContext(result);
        }

        public async Task<Result<TValue>> Fork<TValue>(Func<bool> condition, Func<Task<TValue>> onTrue, Func<Task<Result<TValue>>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? Result.Success(await onTrue()).WithContext(result)
                : (await onFalse()).WithContext(result);
        }
    }
}
