using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHub.Providers.WordDictionary.DictionaryAPI
{
    internal class Phonetic
    {
        public string Text { get; set; }
        public string Audio { get; set; }
        public string SourceUrl { get; set; }
        public License License { get; set; }
    }
}
