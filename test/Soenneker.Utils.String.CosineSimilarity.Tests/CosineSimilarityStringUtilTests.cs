using AwesomeAssertions;
using Soenneker.Tests.HostedUnit;


namespace Soenneker.Utils.String.CosineSimilarity.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class CosineSimilarityStringUtilTests : HostedUnitTest
{

    public CosineSimilarityStringUtilTests(Host host) : base(host)
    {
    }

    [Test]
    [Arguments("", "", 1)]
    [Arguments("abc", "", 0)]
    [Arguments("", "xyz", 0)]
    [Arguments("kitten", "sitting", 0)]
    [Arguments("kitten", "kitten", 1)]
    [Arguments("abc", "def", 0)]
    [Arguments("abcdef", "abc", 0)]
    [Arguments("abc", "abcd", 0)]
    [Arguments("this is sitting on a porch", "this is sitting", .7071)]
    [Arguments("the cat sat on a hat", "sad on a hat", .6123)]
    [Arguments("this is a test", "this is another test", .75)]
    public void CalculateSimilarity_Returns_Correct_Similarity_Score(string str1, string str2, double expectedScore)
    {
        double similarityScore = CosineSimilarityStringUtil.CalculateSimilarity(str1, str2);

        similarityScore.Should().BeApproximately(expectedScore, 0.001);
    }


    [Test]
    [Arguments("", "", 100.0)]
    [Arguments("abc", "", 0.0)]
    [Arguments("", "xyz", 0.0)]
    [Arguments("kitten", "sitting", 0)]
    [Arguments("kitten", "kitten", 100.0)]
    [Arguments("abc", "def", 0.0)]
    [Arguments("abcdef", "abc", 0.0)]
    [Arguments("this is sitting on a porch", "this is sitting", 70.71)]
    public void CalculateSimilarityPercentage_Returns_Correct_Percentage(string str1, string str2, double expectedPercentage)
    {
        double similarityPercentage = CosineSimilarityStringUtil.CalculateSimilarityPercentage(str1, str2);

        similarityPercentage.Should().BeApproximately(expectedPercentage, 0.001);
    }
}
