using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Map;

public partial class ValueResultMapTests
{
    public static IEnumerable<object[]> TaskTestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };

    [Theory, MemberData(nameof(TaskTestData1))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult_Task
        (Result<Types.Alpha> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TaskTestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithTask.Void, Assertions.ResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithTask.Void, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithTask.Void, Assertions.ResultFailure },
        };

    [Theory, MemberData(nameof(TaskTestData2))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_With_Result_Task
        (Result<Types.Alpha> first, Func<Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result);
    }

    public static IEnumerable<object[]> TaskTestData3 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, FunctionsOld.Success.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Beta1, FunctionsOld.Failure.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Success.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Failure.WithTask.Alpha, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TaskTestData3))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_With_Different_ValueResult_Task
        (Result<Types.Beta> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TaskTestData4 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, FunctionsOld.Success.WithTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Beta1, FunctionsOld.Failure.WithTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Success.WithTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Beta, FunctionsOld.Failure.WithTask.AlphaWithBetaParam, Values.Alpha1, Assertions.ValueResultFailure },
        };
    
    [Theory, MemberData(nameof(TaskTestData4))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult_Task
        (Result<Types.Beta> first, Func<Types.Beta, Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TaskTestData5 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, FunctionsOld.Success.WithTask.VoidWithAlphaParam, Assertions.ResultSuccess },
            new object[] { Results.Success.Alpha1, FunctionsOld.Failure.WithTask.VoidWithAlphaParam, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Success.WithTask.VoidWithAlphaParam, Assertions.ResultFailure },
            new object[] { Results.Failure.Alpha, FunctionsOld.Failure.WithTask.VoidWithAlphaParam, Assertions.ResultFailure },
        };
    
    [Theory, MemberData(nameof(TaskTestData5))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Result_Task
        (Result<Types.Alpha> first, Func<Types.Alpha, Task<Result>> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TaskTestData6 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Tasks.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Alpha, Tasks.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData6))]
    public async Task Should_Return_Result_When_Map_On_ValueResult_With_Action_Task
        (Result<Types.Alpha> first, Func<Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TaskTestData7 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Tasks.Takes.Alpha.Returns.Nothing, Assertions.ResultSuccess },
            new object[] { Results.Failure.Alpha, Tasks.Takes.Alpha.Returns.Nothing, Assertions.ResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData7))]
    public async Task Should_Pass_Param_And_Return_Result_When_Map_On_ValueResult_With_Action_Task
        (Result<Types.Alpha> first, Func<Types.Alpha, Task> next, Action<Result> validate)
    {
        var result = await first
            .Map(next);

        validate(result);
    }
    
    public static IEnumerable<object[]> TaskTestData8 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Beta, Tasks.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData8))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_With_Function_Task
        (Result<Types.Beta> first, Func<Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static IEnumerable<object[]> TaskTestData9 => 
        new List<object[]>
        {
            new object[] { Results.Success.Beta1, Tasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Failure.Beta, Tasks.Takes.Beta.Returns.Alpha1, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TaskTestData9))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_Function_Task
        (Result<Types.Beta> first, Func<Types.Beta, Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}