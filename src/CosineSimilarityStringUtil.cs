using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;
using System.Linq;

namespace Soenneker.Utils.String.CosineSimilarity;

/// <summary>
/// A utility library for comparing strings via Cosine Similarity
/// </summary>
public static class CosineSimilarityStringUtil
{
    /// <summary>
    /// Calculates the similarity percentage between two strings via Cosine Similarity
    /// </summary>
    /// <param name="s1">The first string.</param>
    /// <param name="s2">The second string.</param>
    /// <returns>The similarity percentage between the two strings.</returns>
    [Pure]
    public static double CalculateSimilarityPercentage(string s1, string s2)
    {
        double similarity = CalculateSimilarity(s1, s2);
        double percentageMatch = similarity * 100;

        return percentageMatch;
    }

    /// <summary>
    /// Calculates the similarity score between two strings via Cosine Similarity
    /// </summary>
    /// <param name="s1">The first string.</param>
    /// <param name="s2">The second string.</param>
    /// <returns>The similarity score between the two strings.</returns>
    [Pure]
    public static double CalculateSimilarity(string s1, string s2)
    {
        if (s1 == s2)
            return 1;

        string[] words1 = s1.Split();
        string[] words2 = s2.Split();

        Dictionary<string, int> vector1 = GetWordVector(words1);
        Dictionary<string, int> vector2 = GetWordVector(words2);

        IEnumerable<string> intersection = new HashSet<string>(vector1.Keys).Intersect(vector2.Keys);

        double dotProduct = 0;
        double magnitude1 = 0;
        double magnitude2 = 0;

        foreach (string word in intersection)
        {
            dotProduct += vector1[word] * vector2[word];
        }

        foreach (int value in vector1.Values)
        {
            magnitude1 += value * value;
        }

        foreach (int value in vector2.Values)
        {
            magnitude2 += value * value;
        }

        magnitude1 = Math.Sqrt(magnitude1);
        magnitude2 = Math.Sqrt(magnitude2);

        if (magnitude1 == 0 || magnitude2 == 0)
        {
            return 0; // To handle division by zero
        }

        return dotProduct / (magnitude1 * magnitude2);
    }

    private static Dictionary<string, int> GetWordVector(IReadOnlyCollection<string> words)
    {
        var wordVector = new Dictionary<string, int>(words.Count, StringComparer.OrdinalIgnoreCase);

        foreach (string word in words)
        {
            string key = word.ToLower();
            if (wordVector.TryGetValue(key, out int count))
            {
                wordVector[key] = count + 1;
            }
            else
            {
                wordVector[key] = 1;
            }
        }

        return wordVector;
    }
}