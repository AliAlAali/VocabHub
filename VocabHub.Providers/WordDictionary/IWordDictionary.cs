using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHub.Data.Models;

namespace VocabHub.Providers.WordDictionary
{
    public interface IWordDictionary
    {
        public Task<Word> GetWord(string word);
    }
}
