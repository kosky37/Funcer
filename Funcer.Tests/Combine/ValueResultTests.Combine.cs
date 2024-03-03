using FluentAssertions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Combine;

public class ValueResultTests_Combine
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new List<Result<Types.Beta>>
                {
                    Results.Success.Beta1,
                    Results.Success.Beta2,
                    Results.Success.Beta3
                },
                new List<Types.Beta>
                {
                    Values.Beta1,
                    Values.Beta2,
                    Values.Beta3
                },
                true
            },
            new object[]
            {
                new List<Result<Types.Beta>>
                {
                    Results.Failure.Beta,
                    Results.Success.Beta1,
                    Results.Success.Beta2
                },
                new List<Types.Beta>(),
                false
            },
            new object[]
            {
                new List<Result<Types.Beta>>
                {
                    Results.Success.Beta2,
                    Results.Failure.Beta,
                    Results.Success.Beta1
                },
                new List<Types.Beta>(),
                false
            }
        };

    [Theory, MemberData(nameof(TestData))]
    public void Should_Return_Combined_Result(List<Result<Types.Beta>> results, List<Types.Beta> expectedValues,
        bool isSuccess)
    {
        var result = Result.Combine(results);

        result.IsSuccess.Should().Be(isSuccess);

        result.Tap(values => values.Intersect(expectedValues).Count().Should().Be(expectedValues.Count));
    }
}