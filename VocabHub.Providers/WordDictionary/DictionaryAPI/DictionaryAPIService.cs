using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHub.Data.Models;

namespace VocabHub.Providers.WordDictionary.DictionaryAPI
{
    public class DictionaryAPIService : IWordDictionary
    {
        private readonly IRestClient _client;

        public DictionaryAPIService(IRestClient client)
        {
            _client = client;
        }

        public async Task<Word> GetWord(string word)
        {
            var entry = await _client.ExecuteGetAsync<List<DictionaryEntry>>($"/{word}");
            var data = entry.Data;

            if (data is not null && data.Count > 0)
            {
                var result = new Word()
                {
                    Text = data[0].Word,
                    Pronunciation = data[0].Phonetic
                };

                result.WordMeanings = new List<WordMeaning>();
                foreach (var meaning in data[0].Meanings)
                {
                    foreach (var definition in meaning.Definitions)
                    {
                        var wordMeaning = new WordMeaning()
                        {
                            PartOfSpeech = meaning.PartOfSpeech,
                            Definition = definition.Definition,
                            OrderIndex = 1,
                        };

                        // Only add example if exists
                        if (!string.IsNullOrEmpty(definition.Example))
                        {
                            wordMeaning.WordExamples = new List<WordExample>()
                            {
                                new WordExample()
                                {
                                    ExampleSentence = definition.Example,
                                }
                            };
                        }

                        result.WordMeanings.Add(wordMeaning);
                    }

                }

                return result;
            }

            return null;
        }


    }
}
