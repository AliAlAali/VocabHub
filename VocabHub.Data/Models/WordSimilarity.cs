using System;
using System.Collections.Generic;

namespace VocabHub.Data.Models;

public partial class WordSimilarity
{
    public int Id { get; set; }

    public int WordId { get; set; }

    public int SimilarWordId { get; set; }

    public string? RelationType { get; set; }

    public virtual Word SimilarWord { get; set; } = null!;

    public virtual Word Word { get; set; } = null!;
}
