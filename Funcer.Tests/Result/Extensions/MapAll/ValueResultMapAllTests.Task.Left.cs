using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.MapAll;

using Result = Funcer.Result;

public class ValueResultMapAllTests_Task_Left
{
    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Result<Types.Beta>>, IEnumerable<Types.Beta>, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>>> TestData1 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Success.Empty, TestFunc.Takes.Alpha.Returns.Success.Beta1, Array.Empty<Types.Beta>().AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_MapAll_ValueResultFunction(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Result<Types.Beta>> next, IEnumerable<Types.Beta> expectedValues, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>> validate)
    {
        var result = await first
            .MapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Task<Result<IEnumerable<Types.Alpha>>>, Func<Types.Alpha, Types.Beta>, IEnumerable<Types.Beta>, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>>> TestData2 => new()
    {
        { TestResult.AlphaEnumerable.Async.Success.V1V2, TestFunc.Takes.Alpha.Returns.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
        { TestResult.AlphaEnumerable.Async.Failure, TestFunc.Takes.Alpha.Returns.Beta1, new[] { TestValues.Beta1, TestValues.Beta1 }.AsEnumerable(), Assertions.ValueResultBetaEnumerableFailure },
        { TestResult.AlphaEnumerable.Async.Success.Empty, TestFunc.Takes.Alpha.Returns.Beta1, Array.Empty<Types.Beta>().AsEnumerable(), Assertions.ValueResultBetaEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_MapAll_Function(Task<Result<IEnumerable<Types.Alpha>>> first, Func<Types.Alpha, Types.Beta> next, IEnumerable<Types.Beta> expectedValues, Action<Result<IEnumerable<Types.Beta>>, IEnumerable<Types.Beta>> validate)
    {
        var result = await first
            .MapAll(next);

        validate(result, expectedValues);
    }
}

