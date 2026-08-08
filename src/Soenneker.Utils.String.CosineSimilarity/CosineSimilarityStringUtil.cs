using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System;

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
        return similarity * 100;
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

        Dictionary<string, int> vector1 = GetWordVector(s1);
        Dictionary<string, int> vector2 = GetWordVector(s2);

        double dotProduct = 0;
        double magnitude1 = 0;
        double magnitude2 = 0;

        Dictionary<string, int> smaller = vector1.Count <= vector2.Count ? vector1 : vector2;
        Dictionary<string, int> larger = ReferenceEquals(smaller, vector1) ? vector2 : vector1;

        foreach (KeyValuePair<string, int> pair in smaller)
        {
            if (larger.TryGetValue(pair.Key, out int otherCount))
                dotProduct += pair.Value * otherCount;
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

    private static Dictionary<string, int> GetWordVector(string value)
    {
        var wordVector = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        Dictionary<string, int>.AlternateLookup<ReadOnlySpan<char>> lookup = wordVector.GetAlternateLookup<ReadOnlySpan<char>>();
        ReadOnlySpan<char> span = value;
        var index = 0;

        while (index < span.Length)
        {
            while (index < span.Length && char.IsWhiteSpace(span[index]))
                index++;

            int start = index;
            while (index < span.Length && !char.IsWhiteSpace(span[index]))
                index++;

            if (start == index)
                continue;

            ReadOnlySpan<char> word = span[start..index];

            if (lookup.TryGetValue(word, out int count))
                lookup[word] = count + 1;
            else
                wordVector.Add(word.ToString(), 1);
        }

        return wordVector;
    }
}
