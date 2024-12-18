using FluentAssertions;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Utils.String.CosineSimilarity.Tests;

[Collection("Collection")]
public class CosineSimilarityStringUtilTests : FixturedUnitTest
{

    public CosineSimilarityStringUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Theory]
    [InlineData("", "", 1)]
    [InlineData("abc", "", 0)]
    [InlineData("", "xyz", 0)]
    [InlineData("kitten", "sitting", 0)]
    [InlineData("kitten", "kitten", 1)]
    [InlineData("abc", "def", 0)]
    [InlineData("abcdef", "abc", 0)]
    [InlineData("abc", "abcd", 0)]
    [InlineData("this is sitting on a porch", "this is sitting", .7071)]
    [InlineData("the cat sat on a hat", "sad on a hat", .6123)]
    [InlineData("this is a test", "this is another test", .75)]
    public void CalculateSimilarity_Returns_Correct_Similarity_Score(string str1, string str2, double expectedScore)
    {
        double similarityScore = CosineSimilarityStringUtil.CalculateSimilarity(str1, str2);

        similarityScore.Should().BeApproximately(expectedScore, 0.001);
    }


    [Theory]
    [InlineData("", "", 100.0)]
    [InlineData("abc", "", 0.0)]
    [InlineData("", "xyz", 0.0)]
    [InlineData("kitten", "sitting", 0)]
    [InlineData("kitten", "kitten", 100.0)]
    [InlineData("abc", "def", 0.0)]
    [InlineData("abcdef", "abc", 0.0)]
    [InlineData("this is sitting on a porch", "this is sitting", 70.71)]
    public void CalculateSimilarityPercentage_Returns_Correct_Percentage(string str1, string str2, double expectedPercentage)
    {
        double similarityPercentage = CosineSimilarityStringUtil.CalculateSimilarityPercentage(str1, str2);

        similarityPercentage.Should().BeApproximately(expectedPercentage, 0.001);
    }
}