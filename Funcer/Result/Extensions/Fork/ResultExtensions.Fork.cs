namespace Funcer;

public static partial class ResultExtensions
{
    extension(Result result)
    {
        // bool condition overloads

        public Result<TValue> Fork<TValue>(bool condition, Func<Result<TValue>> onTrue, Func<Result<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue> Fork<TValue>(bool condition, Func<TValue> onTrue, Func<TValue> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        // Mixed overloads for bool condition

        public Result<TValue> Fork<TValue>(bool condition, Func<Result<TValue>> onTrue, Func<TValue> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue> Fork<TValue>(bool condition, Func<TValue> onTrue, Func<Result<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        // Func<bool> condition overloads

        public Result<TValue> Fork<TValue>(Func<bool> condition, Func<Result<TValue>> onTrue, Func<Result<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue> Fork<TValue>(Func<bool> condition, Func<TValue> onTrue, Func<TValue> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        // Mixed overloads for Func<bool> condition

        public Result<TValue> Fork<TValue>(Func<bool> condition, Func<Result<TValue>> onTrue, Func<TValue> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue> Fork<TValue>(Func<bool> condition, Func<TValue> onTrue, Func<Result<TValue>> onFalse)
        {
            if (result.IsFailure) return Result<TValue>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }
    }
}
