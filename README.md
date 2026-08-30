[![](https://img.shields.io/nuget/v/soenneker.utils.string.cosinesimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.cosinesimilarity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.string.cosinesimilarity/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.string.cosinesimilarity/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.string.cosinesimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.cosinesimilarity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.string.cosinesimilarity/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.string.cosinesimilarity/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.String.CosineSimilarity
A whitespace-token frequency cosine similarity calculator for comparing strings.

## Installation

```bash
dotnet add package Soenneker.Utils.String.CosineSimilarity
```

## Usage

```csharp
using Soenneker.Utils.String.CosineSimilarity;

var text1 = "This is a test";
var text2 = "This is another test";

double score = CosineSimilarityStringUtil.CalculateSimilarity(text1, text2);
double percentage = CosineSimilarityStringUtil.CalculateSimilarityPercentage(text1, text2);

// score == 0.75
// percentage == 75
```

The result measures overlap between token-count vectors. `CalculateSimilarity` returns a score from `0` to `1`; `CalculateSimilarityPercentage` returns the same score multiplied by 100. Identical strings, including two empty strings, return `1` (or `100%`). If only one input is empty, the result is `0`.

## Tokenization and comparison rules

- Tokens are separated only by whitespace.
- Token matching is ordinal and case-insensitive.
- Repeated tokens increase their vector weight.
- Punctuation is retained, so `"test"` and `"test."` are different tokens.
- Word order is ignored.

This is lexical frequency comparison, not semantic similarity. It does not stem words, remove stop words, normalize punctuation, or understand synonyms. Normalize inputs before calling it when your application needs those behaviors.

The methods require non-null strings and throw when passed `null`.
