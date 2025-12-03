using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Combine;

using Result = Funcer.Result;

public class ResultExtensionsTests_Combine
{
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

