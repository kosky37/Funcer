using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.TapAll;

using Result = Funcer.Result;

public class ValueResultTapAllTests_Task_Left
{
    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Result>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData1 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Success.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Failure.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Success.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Failure.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Success.Empty, TestFunc.Takes.Alpha.Returns.Success.Empty, Array.Empty<Types.Alpha>().AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_TapAll_ResultFunction(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Result> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = await first
            .TapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Action<Types.Alpha>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData2 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Nothing, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Nothing, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Success.Empty, TestFunc.Takes.Alpha.Returns.Nothing, Array.Empty<Types.Alpha>().AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_TapAll_Action(Task<Result<IEnumerable<Types.Alpha>>> first, Action<Types.Alpha> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = await first
            .TapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Result<Types.Beta>>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData3 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Success.Empty, TestFunc.Takes.Alpha.Returns.Success.Beta1, Array.Empty<Types.Alpha>().AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask_TapAll_ValueResultFunction(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Result<Types.Beta>> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = await first
            .TapAll(next);

        validate(result, expectedValues);
    }
}

