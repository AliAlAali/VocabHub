using System;
using System.Collections.Generic;

namespace VocabHub.Data.Models;

public partial class Word
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public string? Pronunciation { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<StoryWord> StoryWords { get; set; } = new List<StoryWord>();

    public virtual ICollection<UserWordKnowledge> UserWordKnowledges { get; set; } = new List<UserWordKnowledge>();

    public virtual ICollection<WordMeaning> WordMeanings { get; set; } = new List<WordMeaning>();

    public virtual ICollection<WordSimilarity> WordSimilaritySimilarWords { get; set; } = new List<WordSimilarity>();

    public virtual ICollection<WordSimilarity> WordSimilarityWords { get; set; } = new List<WordSimilarity>();
}
