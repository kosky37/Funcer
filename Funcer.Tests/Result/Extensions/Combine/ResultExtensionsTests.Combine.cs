using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Combine;

using Result = Funcer.Result;

public class ResultExtensionsTests_Combine
{
    [Fact]
    public void Should_Combine_Result_With_Other_Results()
    {
        var result = TestResult.Success.Combine(TestResult.Alpha.Success.V1, TestResult.Beta.Success.V1);

        result.ShouldBeSuccess();
    }
    
    [Fact]
    public void Should_Combine_Result_With_Other_Results_And_Return_Failure_When_One_Fails()
    {
        var result = TestResult.Success.Combine(TestResult.Alpha.Failure, TestResult.Beta.Success.V1);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_Combine_Result_With_ValueResults()
    {
        var result = TestResult.Success.Combine(TestResult.Alpha.Success.V1, TestResult.Alpha.Success.V2);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        result.Value.Should().Contain(TestValues.Alpha1);
        result.Value.Should().Contain(TestValues.Alpha2);
    }
    
    [Fact]
    public void Should_Combine_Result_With_ValueResults_And_Return_Failure_When_One_Fails()
    {
        var result = TestResult.Success.Combine(TestResult.Alpha.Failure, TestResult.Alpha.Success.V1);

        result.ShouldBeFailure();
    }
    
    [Fact]
    public void Should_Combine_IEnumerable_Of_Results()
    {
        var results = new List<Result> { TestResult.Success, TestResult.Success, TestResult.Success };
        var combined = results.Combine();

        combined.ShouldBeSuccess();
    }
    
    [Fact]
    public void Should_Combine_IEnumerable_Of_Results_And_Return_Failure_When_One_Fails()
    {
        var results = new List<Result> { TestResult.Success, TestResult.Failure, TestResult.Success };
        var combined = results.Combine();

        combined.ShouldBeFailure();
    }
    
    [Fact]
    public async Task Should_Combine_Task_IEnumerable_Of_Results()
    {
        var resultsTask = Task.FromResult<IEnumerable<Result>>(new List<Result> { TestResult.Success, TestResult.Success });
        var combined = await resultsTask.Combine();

        combined.ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Should_Combine_IEnumerable_Of_Task_Results()
    {
        var resultTasks = new List<Task<Result>>
        {
            TestResult.Async.Success,
            TestResult.Async.Success
        };
        var combined = await resultTasks.Combine();

        combined.ShouldBeSuccess();
    }
    
    [Fact]
    public async Task Should_Combine_Task_IEnumerable_Of_Task_Results()
    {
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result>>>(new List<Task<Result>>
        {
            TestResult.Async.Success,
            TestResult.Async.Success
        });
        var combined = await resultTasksTask.Combine();

        combined.ShouldBeSuccess();
    }
}

