using Funcer.Generator.Attributes;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

[ValueTaskVariantGenerator]
public class ValueResultMapTests_Task_Left
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Function
        (Task<Result<Types.Alpha>> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Failure.Empty, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Result_Function
        (Task<Result<Types.Alpha>> first, Func<Result> next, Action<Result> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result);
    }

    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Beta1, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Functions.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Functions.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Different_ValueResult_Function
        (Task<Result<Types.Beta>> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Functions.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Beta1, Functions.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Functions.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Functions.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Parameterized_Function
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData5 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Parameterized_Result_Function
        (Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData6 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData6))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Action
        (Task<Result<Types.Alpha>> first, Action next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData7 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Functions.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Functions.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData7))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Parameterized_Action
        (Task<Result<Types.Alpha>> first, Action<Types.Alpha> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData8 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Beta, Functions.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData8))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Function
        (Task<Result<Types.Beta>> first, Func<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData9 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Functions.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Beta, Functions.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData9))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_Parameterized_Function
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}