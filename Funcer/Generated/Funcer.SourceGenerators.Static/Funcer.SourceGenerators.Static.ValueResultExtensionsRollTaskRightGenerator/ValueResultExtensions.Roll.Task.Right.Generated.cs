namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<(TValue1, TValue2)>> Roll<TValue1, TValue2>(this Result<TValue1> result, Task<Result<TValue2>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2)>.Failure(result.Errors) : result.Roll(await nextTask);
    }
    public static async Task<Result<(TValue1, TValue2, TValue3)>> Roll<TValue1, TValue2, TValue3>(this Result<(TValue1, TValue2)> result, Task<Result<TValue3>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4)>> Roll<TValue1, TValue2, TValue3, TValue4>(this Result<(TValue1, TValue2, TValue3)> result, Task<Result<TValue4>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5>(this Result<(TValue1, TValue2, TValue3, TValue4)> result, Task<Result<TValue5>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5)> result, Task<Result<TValue6>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)> result, Task<Result<TValue7>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)> result, Task<Result<TValue8>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)> result, Task<Result<TValue9>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)> result, Task<Result<TValue10>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)> result, Task<Result<TValue11>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)> result, Task<Result<TValue12>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)> result, Task<Result<TValue13>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)> result, Task<Result<TValue14>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)> result, Task<Result<TValue15>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)> result, Task<Result<TValue16>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>.Failure(result.Errors) : result.Roll(await nextTask);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17>(this Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)> result, Task<Result<TValue17>> nextTask)
    {
        return result.IsFailure ? Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17)>.Failure(result.Errors) : result.Roll(await nextTask);
    }
}