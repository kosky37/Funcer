using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.MapAll;

using Result = Funcer.Result;

public class MapAllTests_Task
{
    [Fact]
    public async Task Should_MapAll_Task_IEnumerable_Of_ValueResults()
    {
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        });
        
        var mapped = await resultsTask.MapAll(x => Result.Success(x.Value));

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
        mapped.Value.Should().Contain(true);
        mapped.Value.Should().Contain(false);
    }
    
    [Fact]
    public async Task Should_MapAll_Task_IEnumerable_Of_ValueResults_And_Return_Failure_When_One_Fails()
    {
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Failure
        });
        
        var mapped = await resultsTask.MapAll(x => Result.Success(x.Value));

        mapped.ShouldBeFailure();
    }
    
    [Fact]
    public async Task Should_MapAll_Task_IEnumerable_Of_ValueResults_With_Simple_Mapper()
    {
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        });
        
        var mapped = await resultsTask.MapAll(x => x.Value);

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
        mapped.Value.Should().Contain(true);
        mapped.Value.Should().Contain(false);
    }
    
    [Fact]
    public async Task Should_MapAll_Task_IEnumerable_Of_ValueResults_With_Task_Mapper()
    {
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        });
        
        var mapped = await resultsTask.MapAll(async x => 
        {
            await Task.Delay(1);
            return Result.Success(x.Value);
        });

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_MapAll_IEnumerable_Of_Task_ValueResults()
    {
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        };
        
        var mapped = await resultTasks.MapAll(x => Result.Success(x.Value));

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
        mapped.Value.Should().Contain(true);
        mapped.Value.Should().Contain(false);
    }
    
    [Fact]
    public async Task Should_MapAll_IEnumerable_Of_Task_ValueResults_And_Return_Failure_When_One_Fails()
    {
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Failure
        };
        
        var mapped = await resultTasks.MapAll(x => Result.Success(x.Value));

        mapped.ShouldBeFailure();
    }
    
    [Fact]
    public async Task Should_MapAll_IEnumerable_Of_Task_ValueResults_With_Simple_Mapper()
    {
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        };
        
        var mapped = await resultTasks.MapAll(x => x.Value);

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_MapAll_IEnumerable_Of_Task_ValueResults_With_Task_Mapper()
    {
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        };
        
        var mapped = await resultTasks.MapAll(async x => 
        {
            await Task.Delay(1);
            return Result.Success(x.Value);
        });

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_MapAll_Task_IEnumerable_Of_Task_ValueResults()
    {
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result<Types.Alpha>>>>(new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        });
        
        var mapped = await resultTasksTask.MapAll(x => Result.Success(x.Value));

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
        mapped.Value.Should().Contain(true);
        mapped.Value.Should().Contain(false);
    }
    
    [Fact]
    public async Task Should_MapAll_Task_IEnumerable_Of_Task_ValueResults_With_Simple_Mapper()
    {
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result<Types.Alpha>>>>(new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        });
        
        var mapped = await resultTasksTask.MapAll(x => x.Value);

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_MapAll_Task_IEnumerable_Of_Task_ValueResults_With_Task_Mapper()
    {
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result<Types.Alpha>>>>(new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        });
        
        var mapped = await resultTasksTask.MapAll(async x => 
        {
            await Task.Delay(1);
            return Result.Success(x.Value);
        });

        mapped.IsSuccess.Should().BeTrue();
        mapped.Value.Should().HaveCount(2);
    }
}

