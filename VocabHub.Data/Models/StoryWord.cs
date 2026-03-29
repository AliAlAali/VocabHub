using System;
using System.Collections.Generic;

namespace VocabHub.Data.Models;

public partial class StoryWord
{
    public int Id { get; set; }

    public int StoryId { get; set; }

    public int WordId { get; set; }

    public int PositionInStory { get; set; }

    public virtual Story Story { get; set; } = null!;

    public virtual Word Word { get; set; } = null!;
}
