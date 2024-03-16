using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Map;

public class ValueResultMapTests_Task_Right
{
    public static TheoryData<Result<Types.Alpha>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData1 => new()
    {
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Success.V1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Failure, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TaskTestData1))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult_Function_Task
        (Result<Types.Alpha> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }

    public static TheoryData<Result<Types.Beta>, Func<Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData3 => new()
    {
        { TestResult.Beta.Success.V1, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, AsyncFunc.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, AsyncFunc.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TaskTestData3))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_With_Different_ValueResult_Function_Task
        (Result<Types.Beta> first, Func<Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Beta>, Func<Types.Beta, Task<Result<Types.Alpha>>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData4 => new()
    {
        { TestResult.Beta.Success.V1, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Success.V1, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, AsyncFunc.Takes.Beta.Returns.Success.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Beta.Failure, AsyncFunc.Takes.Beta.Returns.Failure.Alpha, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TaskTestData4))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_ValueResult_Parameterized_Function_Task
        (Result<Types.Beta> first, Func<Types.Beta, Task<Result<Types.Alpha>>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Beta>, Func<Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData8 => new()
    {
        { TestResult.Beta.Success.V1, AsyncFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, AsyncFunc.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData8))]
    public async Task Should_Return_ValueResult_When_Map_On_ValueResult_With_Function_Task
        (Result<Types.Beta> first, Func<Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Result<Types.Beta>, Func<Types.Beta, Task<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TaskTestData9 => new()
    {
        { TestResult.Beta.Success.V1, AsyncFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Beta.Failure, AsyncFunc.Takes.Beta.Returns.Alpha1, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TaskTestData9))]
    public async Task Should_Pass_Param_And_Return_ValueResult_When_Map_On_ValueResult_With_Parameterized_Function_Task
        (Result<Types.Beta> first, Func<Types.Beta, Task<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Map(next);

        validate(result, expectedValue);
    }
}