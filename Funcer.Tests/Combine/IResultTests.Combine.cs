using FluentAssertions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Combine;

public class IResultTests_Combine
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new List<IResult>
                {
                    Results.Success.Nothing,
                    Results.Success.Alpha1,
                    Results.Success.Beta1
                },
                true
            },
            new object[]
            {
                new List<IResult>
                {
                    Results.Failure.Nothing,
                    Results.Success.Alpha1,
                    Results.Success.Beta1
                },
                false
            }
            ,
            new object[]
            {
                new List<IResult>
                {
                    Results.Success.Nothing,
                    Results.Failure.Alpha,
                    Results.Success.Beta1
                },
                false
            }
        };

    [Theory, MemberData(nameof(TestData))]
    public void Should_Combine_Result_And_ValueResult(List<IResult> results, bool isSuccess)
    {
        var result = Result.Combine(results);

        result.IsSuccess.Should().Be(isSuccess);
    }
}