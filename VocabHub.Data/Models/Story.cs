using System;
using System.Collections.Generic;

namespace VocabHub.Data.Models;

public partial class Story
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedByUserId { get; set; }

    public virtual ICollection<StoryWord> StoryWords { get; set; } = new List<StoryWord>();
}
