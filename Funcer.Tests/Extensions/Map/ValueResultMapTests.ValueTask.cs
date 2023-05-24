using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

public partial class ValueResultMapTests
{
    public static IEnumerable<object[]> ValueTaskTestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(ValueTaskTestData1))]
    public async ValueTask Should_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult_ValueTask
        (Result<Types.Alpha> first, Func<ValueTask<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithValueTask.Void, Assertions.ResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithValueTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithValueTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithValueTask.Void, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(ValueTaskTestData2))]
    public async ValueTask Should_Return_Result_When_Map_On_ValueResult_With_Result_ValueTask
        (Result<Types.Alpha> first, Func<ValueTask<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result);
    }

    public static IEnumerable<object[]> ValueTaskTestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, FunctionsOld.Success.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Beta1, FunctionsOld.Failure.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Success.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Failure.WithValueTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(ValueTaskTestData3))]
    public async ValueTask Should_Return_ValueResult_When_Map_On_ValueResult_With_Different_ValueResult_ValueTask
        (Result<Types.Beta> first, Func<ValueTask<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, FunctionsOld.Success.WithValueTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Beta1, FunctionsOld.Failure.WithValueTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Success.WithValueTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Failure.WithValueTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(ValueTaskTestData4))]
    public async ValueTask Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult_ValueTask
        (Result<Types.Beta> first, Func<Types.Beta, ValueTask<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData5 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithValueTask.VoidWithAlphaParam, Assertions.ResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithValueTask.VoidWithAlphaParam, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithValueTask.VoidWithAlphaParam, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithValueTask.VoidWithAlphaParam, Assertions.ResultFailure },
        };
    
    [Theory, MemberData(nameof(ValueTaskTestData5))]
    public async ValueTask Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Result_ValueTask
        (Result<Types.Alpha> first, Func<Types.Alpha, ValueTask<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData6 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, ValueTasks.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Alpha, ValueTasks.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(ValueTaskTestData6))]
    public async ValueTask Should_Return_Result_When_Map_On_ValueResult_With_Action_ValueTask
        (Result<Types.Alpha> first, Func<ValueTask> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData7 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, ValueTasks.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Alpha, ValueTasks.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(ValueTaskTestData7))]
    public async ValueTask Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Action_ValueTask
        (Result<Types.Alpha> first, Func<Types.Alpha, ValueTask> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData8 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, ValueTasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Beta, ValueTasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(ValueTaskTestData8))]
    public async ValueTask Should_Return_ValueResult_When_Map_On_ValueResult_With_Function_ValueTask
        (Result<Types.Beta> first, Func<ValueTask<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> ValueTaskTestData9 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, ValueTasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Beta, ValueTasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(ValueTaskTestData9))]
    public async ValueTask Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_Function_ValueTask
        (Result<Types.Beta> first, Func<Types.Beta, ValueTask<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}