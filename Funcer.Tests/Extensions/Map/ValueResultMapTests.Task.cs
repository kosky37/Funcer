using Funcer.Generator.Attributes;
using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

[ValueTaskVariantGenerator]
public class ValueResultMapTests_Task
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Failure.Empty, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Result_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result);
    }

    public static IEnumerable<object[]> TestData3 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Beta1, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Tasks.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Tasks.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Different_ValueResult_Function_Task
        (Task<Result<Types.Beta>> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData4 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Tasks.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Success.Beta1, Tasks.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Tasks.Takes.Beta.Returns.Success.Alpha1, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Tasks.Failure.Beta, Tasks.Takes.Beta.Returns.Failure.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_ValueResult_Parameterized_Function_Task
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData5 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Success.Empty, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Success.Empty, Assertions.ResultFailure },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Failure.Empty, Assertions.ResultFailure },
        };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Result_Parameterized_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData6 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData6))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_Task_With_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData7 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Alpha1, Tasks.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Tasks.Failure.Alpha, Tasks.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TestData7))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_Task_With_Parameterized_Function_Task
        (Task<Result<Types.Alpha>> first, Func<Types.Alpha, Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TestData8 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Beta, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData8))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_Task_With_Function_Task
        (Task<Result<Types.Beta>> first, Func<Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TestData9 => 
        new List<object[]>
        {
            new object[] { Results.Tasks.Success.Beta1, Tasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Tasks.Failure.Beta, Tasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData9))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_Task_With_Parameterized_Function_Task
        (Task<Result<Types.Beta>> first, Func<Types.Beta, Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}