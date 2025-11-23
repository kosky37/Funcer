using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Combine;

public class ValueResultExtensionsTests_Combine
{
    [Fact]
    public void Should_Combine_ValueResult_With_Other_Results()
    {
        var result = TestResult.Alpha.Success.V1.Combine(TestResult.Success, TestResult.Beta.Success.V1);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public void Should_Combine_ValueResult_With_Other_Results_And_Return_Failure_When_One_Fails()
    {
        var result = TestResult.Alpha.Success.V1.Combine(TestResult.Failure, TestResult.Beta.Success.V1);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_Combine_ValueResult_With_Same_Type_ValueResults()
    {
        // Use IEnumerable extension to avoid ambiguity
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        };
        var result = results.Combine();

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value.Should().Contain(TestValues.Alpha1);
        result.Value.Should().Contain(TestValues.Alpha2);
    }
    
    [Fact]
    public void Should_Combine_ValueResult_With_Different_Type_ValueResults()
    {
        var result = TestResult.Alpha.Success.V1.Combine(TestResult.Beta.Success.V1, TestResult.Beta.Success.V2);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value.Should().Contain(TestValues.Beta1);
        result.Value.Should().Contain(TestValues.Beta2);
    }
    
    [Fact]
    public void Should_Combine_IEnumerable_Of_ValueResults()
    {
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        };
        var combined = results.Combine();

        combined.IsSuccess.Should().BeTrue();
        combined.Value.Should().HaveCount(2);
        combined.Value.Should().Contain(TestValues.Alpha1);
        combined.Value.Should().Contain(TestValues.Alpha2);
    }
    
    [Fact]
    public void Should_Combine_IEnumerable_Of_ValueResults_And_Return_Failure_When_One_Fails()
    {
        var results = new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Failure
        };
        var combined = results.Combine();

        combined.ShouldBeFailure();
    }
    
    [Fact]
    public async Task Should_Combine_Task_IEnumerable_Of_ValueResults()
    {
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        });
        var combined = await resultsTask.Combine();

        combined.IsSuccess.Should().BeTrue();
        combined.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_Combine_IEnumerable_Of_Task_ValueResults()
    {
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        };
        var combined = await resultTasks.Combine();

        combined.IsSuccess.Should().BeTrue();
        combined.Value.Should().HaveCount(2);
        combined.Value.Should().Contain(TestValues.Alpha1);
        combined.Value.Should().Contain(TestValues.Alpha2);
    }
    
    [Fact]
    public async Task Should_Combine_Task_IEnumerable_Of_Task_ValueResults()
    {
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result<Types.Alpha>>>>(new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        });
        var combined = await resultTasksTask.Combine();

        combined.IsSuccess.Should().BeTrue();
        combined.Value.Should().HaveCount(2);
        combined.Value.Should().Contain(TestValues.Alpha1);
        combined.Value.Should().Contain(TestValues.Alpha2);
    }
}

