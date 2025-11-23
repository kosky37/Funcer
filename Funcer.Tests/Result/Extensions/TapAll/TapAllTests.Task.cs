using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.TapAll;

using Result = Funcer.Result;

public class TapAllTests_Task
{
    [Fact]
    public async Task Should_TapAll_Task_IEnumerable_Of_ValueResults_With_Action()
    {
        var tappedValues = new List<bool>();
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        });
        
        var result = await resultsTask.TapAll(x => tappedValues.Add(x.Value));

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        tappedValues.Should().HaveCount(2);
        tappedValues.Should().Contain(true);
        tappedValues.Should().Contain(false);
    }
    
    [Fact]
    public async Task Should_TapAll_Task_IEnumerable_Of_ValueResults_With_Action_And_Return_Failure_When_One_Fails()
    {
        var tappedValues = new List<bool>();
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Failure
        });
        
        var result = await resultsTask.TapAll(x => tappedValues.Add(x.Value));

        result.ShouldBeFailure();
        tappedValues.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Should_TapAll_Task_IEnumerable_Of_ValueResults_With_Func_Result()
    {
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        });
        
        var result = await resultsTask.TapAll(x => Result.Success());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_TapAll_Task_IEnumerable_Of_ValueResults_With_Task_Action()
    {
        var tappedValues = new List<bool>();
        var resultsTask = Task.FromResult<IEnumerable<Result<Types.Alpha>>>(new List<Result<Types.Alpha>>
        {
            TestResult.Alpha.Success.V1,
            TestResult.Alpha.Success.V2
        });
        
        var result = await resultsTask.TapAll(async x => 
        {
            await Task.Delay(1);
            tappedValues.Add(x.Value);
        });

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        tappedValues.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_TapAll_IEnumerable_Of_Task_ValueResults_With_Action()
    {
        var tappedValues = new List<bool>();
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        };
        
        var result = await resultTasks.TapAll(x => tappedValues.Add(x.Value));

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        tappedValues.Should().HaveCount(2);
        tappedValues.Should().Contain(true);
        tappedValues.Should().Contain(false);
    }
    
    [Fact]
    public async Task Should_TapAll_IEnumerable_Of_Task_ValueResults_And_Return_Failure_When_One_Fails()
    {
        var tappedValues = new List<bool>();
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Failure
        };
        
        var result = await resultTasks.TapAll(x => tappedValues.Add(x.Value));

        result.ShouldBeFailure();
        tappedValues.Should().HaveCount(0);
    }
    
    [Fact]
    public async Task Should_TapAll_IEnumerable_Of_Task_ValueResults_With_Func_Result()
    {
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        };
        
        var result = await resultTasks.TapAll(x => Result.Success());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_TapAll_IEnumerable_Of_Task_ValueResults_With_Task_Action()
    {
        var tappedValues = new List<bool>();
        var resultTasks = new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        };
        
        var result = await resultTasks.TapAll(async x => 
        {
            await Task.Delay(1);
            tappedValues.Add(x.Value);
        });

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        tappedValues.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_TapAll_Task_IEnumerable_Of_Task_ValueResults_With_Action()
    {
        var tappedValues = new List<bool>();
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result<Types.Alpha>>>>(new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        });
        
        var result = await resultTasksTask.TapAll(x => tappedValues.Add(x.Value));

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        tappedValues.Should().HaveCount(2);
        tappedValues.Should().Contain(true);
        tappedValues.Should().Contain(false);
    }
    
    [Fact]
    public async Task Should_TapAll_Task_IEnumerable_Of_Task_ValueResults_With_Func_Result()
    {
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result<Types.Alpha>>>>(new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        });
        
        var result = await resultTasksTask.TapAll(x => Result.Success());

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task Should_TapAll_Task_IEnumerable_Of_Task_ValueResults_With_Task_Action()
    {
        var tappedValues = new List<bool>();
        var resultTasksTask = Task.FromResult<IEnumerable<Task<Result<Types.Alpha>>>>(new List<Task<Result<Types.Alpha>>>
        {
            TestResult.Alpha.Async.Success.V1,
            TestResult.Alpha.Async.Success.V2
        });
        
        var result = await resultTasksTask.TapAll(async x => 
        {
            await Task.Delay(1);
            tappedValues.Add(x.Value);
        });

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(2);
        tappedValues.Should().HaveCount(2);
    }
}

