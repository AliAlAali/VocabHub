using System;
using System.Collections.Generic;

namespace VocabHub.Data.Models;

public partial class WordExample
{
    public int Id { get; set; }

    public string ExampleSentence { get; set; } = null!;

    public int? MeaningId { get; set; }

    public virtual WordMeaning? Meaning { get; set; }

}
