using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHub.Providers.WordDictionary.DictionaryAPI
{
    internal class Meaning
    {
        public string PartOfSpeech { get; set; }
        public List<DefinitionEntry> Definitions { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> Antonyms { get; set; }
    }
}
