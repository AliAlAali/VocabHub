using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHub.Providers.WordDictionary.DictionaryAPI
{
    internal class DefinitionEntry
    {
        public string Definition { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> Antonyms { get; set; }
        public string Example { get; set; }
    }
}
