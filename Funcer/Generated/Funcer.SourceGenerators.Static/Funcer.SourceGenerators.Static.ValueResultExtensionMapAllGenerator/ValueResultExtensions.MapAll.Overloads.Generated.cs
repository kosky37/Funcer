using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funcer;

public static partial class ValueResultExtensions
{

    // Sync Overloads for List<TValue>
    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    // Task Overloads (Input Task, Func Task) for List<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, Task<TValue2>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Task Left Overloads (Input Task, Func Sync) for List<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<List<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    // Task Right Overloads (Input Sync, Func Task) for List<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<List<TValue>> result, Func<TValue, Task<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Sync Overloads for IList<TValue>
    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    // Task Overloads (Input Task, Func Task) for IList<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, Task<TValue2>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Task Left Overloads (Input Task, Func Sync) for IList<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IList<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    // Task Right Overloads (Input Sync, Func Task) for IList<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IList<TValue>> result, Func<TValue, Task<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Sync Overloads for IReadOnlyCollection<TValue>
    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    // Task Overloads (Input Task, Func Task) for IReadOnlyCollection<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, Task<TValue2>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Task Left Overloads (Input Task, Func Sync) for IReadOnlyCollection<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<IReadOnlyCollection<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    // Task Right Overloads (Input Sync, Func Task) for IReadOnlyCollection<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<IReadOnlyCollection<TValue>> result, Func<TValue, Task<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Sync Overloads for ICollection<TValue>
    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    // Task Overloads (Input Task, Func Task) for ICollection<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, Task<TValue2>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Task Left Overloads (Input Task, Func Sync) for ICollection<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<ICollection<TValue>>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    // Task Right Overloads (Input Sync, Func Task) for ICollection<TValue>
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<ICollection<TValue>> result, Func<TValue, Task<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Sync Overloads for TValue[]
    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, Result<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = result.Value!.Select(next).ToList();
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static Result<IEnumerable<TValue2>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, TValue2> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        return Result.Success(result.Value!.Select(next)).WithContext(result);
    }

    // Task Overloads (Input Task, Func Task) for TValue[]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, Task<Result<TValue2>>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, Task<TValue2>> next)
    {
        var result = await resultTask;
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }

    // Task Left Overloads (Input Task, Func Sync) for TValue[]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, Result<TValue2>> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Task<Result<TValue[]>> resultTask, Func<TValue, TValue2> next)
    {
        var result = await resultTask;
        return result.MapAll(next);
    }

    // Task Right Overloads (Input Sync, Func Task) for TValue[]
    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, Task<Result<TValue2>>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedResults = await Task.WhenAll(result.Value!.Select(next));
        var errors = mappedResults.Where(x => x.IsFailure).SelectMany(x => x.Errors).ToList();

        if (errors.Count is not 0)
        {
            return Result<IEnumerable<TValue2>>.Failure(errors);
        }

        return Result.Success(mappedResults.Select(x => x.Value!)).WithContext(result);
    }

    public static async Task<Result<IEnumerable<TValue2>>> MapAll<TValue, TValue2>(this Result<TValue[]> result, Func<TValue, Task<TValue2>> next)
    {
        if (result.IsFailure)
        {
            return Result<IEnumerable<TValue2>>.Failure(result.Errors);
        }

        var mappedValues = await Task.WhenAll(result.Value!.Select(next));
        return Result.Success(mappedValues.AsEnumerable()).WithContext(result);
    }
}
