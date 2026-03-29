using System;
using System.Collections.Generic;

namespace VocabHub.Data.Models;

public partial class WordMeaning
{
    public int Id { get; set; }

    public int WordId { get; set; }

    public string PartOfSpeech { get; set; } = null!;

    public string Definition { get; set; } = null!;

    public int OrderIndex { get; set; }

    public virtual Word Word { get; set; } = null!;

    public virtual ICollection<WordExample> WordExamples { get; set; } = new List<WordExample>();
}
