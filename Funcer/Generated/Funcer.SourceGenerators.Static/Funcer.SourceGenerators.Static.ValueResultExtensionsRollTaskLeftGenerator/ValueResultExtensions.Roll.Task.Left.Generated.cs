namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<(TValue1, TValue2)>> Roll<TValue1, TValue2>(this Task<Result<TValue1>> resultTask, Result<TValue2> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }
    public static async Task<Result<(TValue1, TValue2, TValue3)>> Roll<TValue1, TValue2, TValue3>(this Task<Result<(TValue1, TValue2)>> resultTask, Result<TValue3> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4)>> Roll<TValue1, TValue2, TValue3, TValue4>(this Task<Result<(TValue1, TValue2, TValue3)>> resultTask, Result<TValue4> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5>(this Task<Result<(TValue1, TValue2, TValue3, TValue4)>> resultTask, Result<TValue5> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5)>> resultTask, Result<TValue6> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6)>> resultTask, Result<TValue7> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7)>> resultTask, Result<TValue8> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8)>> resultTask, Result<TValue9> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9)>> resultTask, Result<TValue10> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10)>> resultTask, Result<TValue11> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11)>> resultTask, Result<TValue12> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12)>> resultTask, Result<TValue13> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13)>> resultTask, Result<TValue14> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14)>> resultTask, Result<TValue15> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15)>> resultTask, Result<TValue16> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }

    public static async Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17)>> Roll<TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16, TValue17>(this Task<Result<(TValue1, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8, TValue9, TValue10, TValue11, TValue12, TValue13, TValue14, TValue15, TValue16)>> resultTask, Result<TValue17> next)
    {
        var result = await resultTask;
        return result.Roll(next);
    }
}