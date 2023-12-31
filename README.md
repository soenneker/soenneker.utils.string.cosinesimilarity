[![](https://img.shields.io/nuget/v/soenneker.utils.string.cosinesimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.cosinesimilarity/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.string.cosinesimilarity/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.string.cosinesimilarity/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.string.cosinesimilarity.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.string.cosinesimilarity/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.String.CosineSimilarity
### A utility library for comparing strings via Cosine Similarity

## Installation

```
dotnet add package Soenneker.Utils.String.CosineSimularity
```

## Why?

Imagine you have two sentences or documents. Cosine similarity helps you figure out how similar they are by looking at the **-words-** they share. Here's why it's handy:

### Easy to Understand:
Cosine similarity is easy to understand. It's a number between 0 and 1 that represents how similar two documents are. The closer to 1, the more similar they are.

### Not Bothered by Length: 
Whether a text is long or short doesn't throw off cosine similarity. It cares more about the words and their relationships than the total number of words.

### Meaning, Not Just Frequency:
It focuses on the meaning of words, not just how often they show up. So, even if one document has a lot more words than another, they might still be considered similar if they share important terms.

### Efficient for Big Tasks:
When you're dealing with lots of documents or a ton of text, cosine similarity is efficient. It doesn't get bogged down by complicated calculations, making it a practical choice for large datasets.

## Usage

```csharp
var text1 = "This is a test";
var text2 = "This is another test";

double result = CosineSimilarityStringUtil.CalculateSimilarityPercentage(text1, text2); // 75
```