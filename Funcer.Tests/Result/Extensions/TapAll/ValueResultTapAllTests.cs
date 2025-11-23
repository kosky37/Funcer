using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.TapAll;

using Result = Funcer.Result;

public class ValueResultTapAllTests
{
    public static TheoryData<Result<IEnumerable<Types.Alpha>>, Func<Types.Alpha, Result>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData1 => new()
    {
        { TestResult.AlphaEnumerable.Success.V1V2, TestFunc.Takes.Alpha.Returns.Success.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Success.V1V2, TestFunc.Takes.Alpha.Returns.Failure.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Failure, TestFunc.Takes.Alpha.Returns.Success.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Failure, TestFunc.Takes.Alpha.Returns.Failure.Empty, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Success.Empty, TestFunc.Takes.Alpha.Returns.Success.Empty, Array.Empty<Types.Alpha>().AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData1))]
    public void ValueResult_TapAll_ResultFunction(Result<IEnumerable<Types.Alpha>> first, Func<Types.Alpha, Result> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = first
            .TapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Result<IEnumerable<Types.Alpha>>, Action<Types.Alpha>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData2 => new()
    {
        { TestResult.AlphaEnumerable.Success.V1V2, TestFunc.Takes.Alpha.Returns.Nothing, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Failure, TestFunc.Takes.Alpha.Returns.Nothing, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Success.Empty, TestFunc.Takes.Alpha.Returns.Nothing, Array.Empty<Types.Alpha>().AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData2))]
    public void ValueResult_TapAll_Action(Result<IEnumerable<Types.Alpha>> first, Action<Types.Alpha> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = first
            .TapAll(next);

        validate(result, expectedValues);
    }

    public static TheoryData<Result<IEnumerable<Types.Alpha>>, Func<Types.Alpha, Result<Types.Beta>>, IEnumerable<Types.Alpha>, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>>> TestData3 => new()
    {
        { TestResult.AlphaEnumerable.Success.V1V2, TestFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
        { TestResult.AlphaEnumerable.Success.V1V2, TestFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Failure, TestFunc.Takes.Alpha.Returns.Success.Beta1, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Failure, TestFunc.Takes.Alpha.Returns.Failure.Beta, new[] { TestValues.Alpha1, TestValues.Alpha2 }.AsEnumerable(), Assertions.ValueResultEnumerableFailure },
        { TestResult.AlphaEnumerable.Success.Empty, TestFunc.Takes.Alpha.Returns.Success.Beta1, Array.Empty<Types.Alpha>().AsEnumerable(), Assertions.ValueResultEnumerableSuccess },
    };

    [Theory, MemberData(nameof(TestData3))]
    public void ValueResult_TapAll_ValueResultFunction(Result<IEnumerable<Types.Alpha>> first, Func<Types.Alpha, Result<Types.Beta>> next, IEnumerable<Types.Alpha> expectedValues, Action<Result<IEnumerable<Types.Alpha>>, IEnumerable<Types.Alpha>> validate)
    {
        var result = first
            .TapAll(next);

        validate(result, expectedValues);
    }
}
