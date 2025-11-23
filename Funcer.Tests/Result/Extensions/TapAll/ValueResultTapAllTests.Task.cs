using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.TapAll;

using Result = Funcer.Result;

public class ValueResultTapAllTests_Task
{
    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Task<Result>>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData1 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Success.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Failure.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Success.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Failure.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_TapAll_ResultTask(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Task<Result>> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = await first
            .TapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Task>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData2 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Nothing, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Nothing, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_TapAll_Task(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Task> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = await first
            .TapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Task<Result<Types.Beta>>>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData3 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
    };

    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask_TapAll_ValueResultTask(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Task<Result<Types.Beta>>> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = await first
            .TapAll(next);

        validate(result, expectedValues);
    }
}
