using System;
using System.Collections.Generic;

namespace VocabHub.Data.Models;

public partial class UserWordKnowledge
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int WordId { get; set; }

    public int KnowledgeLevel { get; set; }

    public int ReviewCount { get; set; }

    public DateTime? LastReviewedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Word Word { get; set; } = null!;
}
