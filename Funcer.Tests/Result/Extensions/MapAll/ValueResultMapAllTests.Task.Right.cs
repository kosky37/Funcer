using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.MapAll;

using Result = Funcer.Result;

public class ValueResultMapAllTests_Task_Right
{
    public static TheoryData<Result<IEnumerable<Types.Alpha>>, Func<Types.Alpha, Task<Result<Types.Beta>>>, IEnumerable<Types.Beta>, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>>> TestData1 => new()
    {
        { TestResult.AlphaEnumerable.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
        { TestResult.AlphaEnumerable.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Failure, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Failure, AsyncFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Success.Empty, AsyncFunc.Takes.Alpha.Returns.Success.Beta1, Array.Empty<Types.Beta>().AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResult_MapAll_ValueResultTask(Result<IEnumerable<Types.Alpha>> first, Func<Types.Alpha, Task<Result<Types.Beta>>> next, IEnumerable<Types.Beta> expectedValues, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>> validate)
    {
        var result = await first
            .MapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Result<IEnumerable<Types.Alpha>>, Func<Types.Alpha, Task<Types.Beta>>, IEnumerable<Types.Beta>, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>>> TestData2 => new()
    {
        { TestResult.AlphaEnumerable.Success.V1V2, AsyncFunc.Takes.Alpha.Returns.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
        { TestResult.AlphaEnumerable.Failure, AsyncFunc.Takes.Alpha.Returns.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResult_MapAll_Task(Result<IEnumerable<Types.Alpha>> first, Func<Types.Alpha, Task<Types.Beta>> next, IEnumerable<Types.Beta> expectedValues, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>> validate)
    {
        var result = await first
            .MapAll(next);

        validate(result, expectedValues);
    }
}

