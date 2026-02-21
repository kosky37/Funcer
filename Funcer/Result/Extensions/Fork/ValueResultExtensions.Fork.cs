namespace Funcer;

public static partial class ValueResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        // bool condition overloads

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue(result.Value!).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        // Mixed overloads for bool condition

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue(result.Value!).WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue(result.Value!).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue(result.Value!).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? onTrue().WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(bool condition, Func<TValue, TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : onFalse().WithContext(result);
        }

        // Func<bool> condition overloads

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue(result.Value!).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        // Mixed overloads for Func<bool> condition

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue(result.Value!).WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue(result.Value!).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue(result.Value!).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? onTrue().WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<bool> condition, Func<TValue, TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition()
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : onFalse().WithContext(result);
        }

        // Func<TValue, bool> condition overloads

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue(result.Value!).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue().WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        // Mixed overloads for Func<TValue, bool> condition

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue(result.Value!).WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue().WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue(result.Value!).WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue().WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse().WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, Result<TValue2>> onTrue, Func<TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue(result.Value!).WithContext(result)
                : Result.Success(onFalse()).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue2> onTrue, Func<TValue, Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue()).WithContext(result)
                : onFalse(result.Value!).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<Result<TValue2>> onTrue, Func<TValue, TValue2> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? onTrue().WithContext(result)
                : Result.Success(onFalse(result.Value!)).WithContext(result);
        }

        public Result<TValue2> Fork<TValue2>(Func<TValue, bool> condition, Func<TValue, TValue2> onTrue, Func<Result<TValue2>> onFalse)
        {
            if (result.IsFailure) return Result<TValue2>.Failure(result.Errors);

            return condition(result.Value!)
                ? Result.Success(onTrue(result.Value!)).WithContext(result)
                : onFalse().WithContext(result);
        }
    }
}
