using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Combine;

using Result = Funcer.Result;

public class ResultTests_Combine
{
    public static TheoryData<List<IResult>, bool> TestData => new()
    {
        { [TestResult.Success, TestResult.Alpha.Success.V1, TestResult.Beta.Success.V1], true },
        { [TestResult.Failure, TestResult.Alpha.Success.V1, TestResult.Beta.Success.V1], false },
        { [TestResult.Success, TestResult.Alpha.Failure, TestResult.Beta.Success.V1], false },
        { [TestResult.Success, TestResult.Success, TestResult.Success], true },
        { [TestResult.Failure, TestResult.Success, TestResult.Success], false },
        { [TestResult.Success, TestResult.Failure, TestResult.Success], false }
    };

    [Theory, MemberData(nameof(TestData))]
    public void Combine_List_Of_Results(List<IResult> results, bool isSuccess)
    {
        var result = Result.Combine(results);

        result.IsSuccess.Should().Be(isSuccess);
    }
    
    [Fact]
    public void Result_Combine_Success()
    {
        var result = Result.Combine(TestResult.Success, TestResult.Alpha.Success.V1, TestResult.Beta.Success.V1);

        result.IsSuccess.Should().BeTrue();
    }
    
    [Fact]
    public void Result_Combine_Failure()
    {
        var result = Result.Combine(TestResult.Success, TestResult.Alpha.Failure, TestResult.Beta.Success.V1);

        result.IsSuccess.Should().BeFalse();
    }
}