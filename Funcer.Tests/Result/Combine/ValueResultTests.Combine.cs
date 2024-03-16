using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Combine;

using Result = Funcer.Result;

public class ValueResultTests_Combine
{
    public static TheoryData<List<Result<Types.Beta>>, List<Types.Beta>, bool> TestData => new()
    {
        {
            [TestResult.Beta.Success.V1, TestResult.Beta.Success.V2, TestResult.Beta.Success.V3],
            [TestValues.Beta1, TestValues.Beta2, TestValues.Beta3],
            true
        },
        {
            [TestResult.Beta.Failure, TestResult.Beta.Success.V1, TestResult.Beta.Success.V2],
            [],
            false
        },
        {
            [TestResult.Beta.Success.V2, TestResult.Beta.Failure, TestResult.Beta.Success.V1],
            [],
            false
        }
    };

    [Theory, MemberData(nameof(TestData))]
    public void Should_Return_Combined_Result(List<Result<Types.Beta>> results, List<Types.Beta> expectedValues, bool isSuccess)
    {
        var result = Result.Combine(results);

        result.IsSuccess.Should().Be(isSuccess);

        result.Tap(values => values.Intersect(expectedValues).Count().Should().Be(expectedValues.Count));
    }
}