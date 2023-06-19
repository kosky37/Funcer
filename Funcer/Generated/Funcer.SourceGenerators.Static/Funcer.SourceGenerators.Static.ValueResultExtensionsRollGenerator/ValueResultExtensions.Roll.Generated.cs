namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Result<(TValue1, TValue2)> Roll<TValue1, TValue2>(this Result<TValue1> result, Result<TValue2> next)
    {
        return result.IsFailure 
        ? Result.Failure<(TValue1, TValue2)>(result.Errors) 
        : next.IsFailure 
            ? Result.Failure<(TValue1, TValue2)>(next.Errors) 
            : Result.Success((result.Value!, next.Value!)).WithContext(result).WithContext(next);
    }
    public static Result<(TValue1, TValue2, TValue3)> Roll<TValue1, TValue2, TValue3>(this Result<(TValue1, TValue2)> result, Result<TValue3> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4)> Roll<TValue1, TValue2, TValue3, TValue4>(this Result<(TValue1, TValue2, TValue3)> result, Result<TValue4> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5>(this Result<(TValue1, TValue2, TValue3, TValue4)> result, Result<TValue5> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> result, Result<TValue6> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> result, Result<TValue7> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> result, Result<TValue8> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> result, Result<TValue9> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> result, Result<TValue10> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> result, Result<TValue11> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> result, Result<TValue12> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> result, Result<TValue13> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> result, Result<TValue14> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> result, Result<TValue15> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> result, Result<TValue16> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15, next.Value!)).WithContext(result).WithContext(next);
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17)> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> result, Result<TValue17> next)
    {
        return result.IsFailure 
            ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17)>(result.Errors) 
            : next.IsFailure 
                ? Result.Failure<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17)>(next.Errors) 
                : Result.Success((result.Value!.Item1, result.Value!.Item2, result.Value!.Item3, result.Value!.Item4, result.Value!.Item5, result.Value!.Item6, result.Value!.Item7, result.Value!.Item8, result.Value!.Item9, result.Value!.Item10, result.Value!.Item11, result.Value!.Item12, result.Value!.Item13, result.Value!.Item14, result.Value!.Item15, result.Value!.Item16, next.Value!)).WithContext(result).WithContext(next);
    }
}