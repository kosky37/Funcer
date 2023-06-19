namespace Funcer;

public partial struct Result
{
    public static Result<(TValue1, TValue2)> Combine<TValue1, TValue2>(Result<TValue1> result1, Result<TValue2> result2, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2)>.Failure(errors)
            : Result<(TValue1, TValue2)>.Success((result1.Value!, result2.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3)> Combine<TValue1, TValue2, TValue3>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3)>.Success((result1.Value!, result2.Value!, result3.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4)> Combine<TValue1, TValue2, TValue3, TValue4>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, Result<TValue10> result10, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!, result10.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, Result<TValue10> result10, Result<TValue11> result11, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!, result10.Value!, result11.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, Result<TValue10> result10, Result<TValue11> result11, Result<TValue12> result12, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!, result10.Value!, result11.Value!, result12.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, Result<TValue10> result10, Result<TValue11> result11, Result<TValue12> result12, Result<TValue13> result13, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!, result10.Value!, result11.Value!, result12.Value!, result13.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, Result<TValue10> result10, Result<TValue11> result11, Result<TValue12> result12, Result<TValue13> result13, Result<TValue14> result14, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!, result10.Value!, result11.Value!, result12.Value!, result13.Value!, result14.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, Result<TValue10> result10, Result<TValue11> result11, Result<TValue12> result12, Result<TValue13> result13, Result<TValue14> result14, Result<TValue15> result15, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!, result10.Value!, result11.Value!, result12.Value!, result13.Value!, result14.Value!, result15.Value!));
    }

    public static Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> Combine<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16>(Result<TValue1> result1, Result<TValue2> result2, Result<TValue3> result3, Result<TValue4> result4, Result<TValue5> result5, Result<TValue6> result6, Result<TValue7> result7, Result<TValue8> result8, Result<TValue9> result9, Result<TValue10> result10, Result<TValue11> result11, Result<TValue12> result12, Result<TValue13> result13, Result<TValue14> result14, Result<TValue15> result15, Result<TValue16> result16, params IResult[] results)
    {
        var errors = new List<IResult> { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15, result16 }
            .Concat(results)
            .Where(result => result.IsFailure)
            .SelectMany(result => result.Errors)
            .ToList();

        return errors.Any()
            ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>.Failure(errors)
            : Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>.Success((result1.Value!, result2.Value!, result3.Value!, result4.Value!, result5.Value!, result6.Value!, result7.Value!, result8.Value!, result9.Value!, result10.Value!, result11.Value!, result12.Value!, result13.Value!, result14.Value!, result15.Value!, result16.Value!));
    }
}