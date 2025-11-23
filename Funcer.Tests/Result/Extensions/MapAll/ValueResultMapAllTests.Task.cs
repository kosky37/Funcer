using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.MapAll;

using Result = Funcer.Result;

public class ValueResultMapAllTests_Task
{
    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Task<Result<Types.Beta>>>, IEnumerable<Types.Beta>, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>>> TestData1 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_MapAll_ValueResultTask(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Task<Result<Types.Beta>>> next, IEnumerable<Types.Beta> expectedValues, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>> validate)
    {
        var result = await first
            .MapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Task<Types.Beta>>, IEnumerable<Types.Beta>, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>>> TestData2 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Failure, AsyncFunc.Takes.Alpha.Returns.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_MapAll_Task(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Task<Types.Beta>> next, IEnumerable<Types.Beta> expectedValues, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>> validate)
    {
        var result = await first
            .MapAll(next);

        validate(result, expectedValues);
    }
}

