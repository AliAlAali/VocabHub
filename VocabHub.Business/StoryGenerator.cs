using Microsoft.Extensions.AI;
using OllamaSharp.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabHub.Data.Models;

namespace VocabHub.Business
{
    public class StoryGenerator
    {
        private readonly IChatClient _chatClient;

        public StoryGenerator(IChatClient chatClient)
        {
            _chatClient = chatClient;
        }

        public async Task<Story> GenerateStory(IEnumerable<Word> words)
        {
            var story = new Story()
            {
                CreatedAt = DateTime.Now,
                //Content = "In the quaint village of Ravenhurst, nestled in the rolling hills of the countryside, there lived a young apprentice named Eira. She was an enigmatic soul with an eclectic mix of interests and passions. Eira spent her days wandering through the narrow streets, taking in the sights and sounds of the old town.\r\n\r\nOne day, while exploring the village's ancient library, Eira stumbled upon an archaic tome bound in worn leather. The cover read \"The Quixotic Quest\" in elegant script. As she opened the book, a faint whisper echoed within its pages: \"Engender clarity amidst chaos.\" Suddenly, the room around her began to feel suffocating, and she felt an urge to capriciously leave it all behind.\r\n\r\nEira's thoughts were soon drawn to the charismatic figure of Lord Silas, a renowned scholar and diatribe-spewing wit. His candor was refreshing, but his words could also be piercing and hurtful. Some saw him as a catalyst for change, while others viewed him as an antagonist. Eira found herself both fascinated and intimidated by his presence.\r\n\r\nAs she delved deeper into the book, Eira encountered a cast of characters, each with their own agendas and motivations. There was the capricious Lady Aria, who seemed to change her mind every moment; the articulate yet audacious Lord Edgar, who spoke without mercy or compassion; and the dupe-like village elder, who appeared wise but was actually hiding a deep-seated malinger.\r\n\r\nEira's journey became increasingly complex as she navigated the labyrinthine world within the book. She began to feel like she was walking through a cacophony of conflicting emotions and ideas. Yet, amidst the chaos, she discovered a lucid voice that seemed to carry her toward a crescendo of understanding.\r\n\r\nAs she continued to study, Eira realized that the true enigma lay not in the characters or their actions but in the way they interacted with each other. The village was plagued by proliferation and antagonism, and it seemed as though no one could alleviate the suffering. But then, something shifted within her. She began to articulate a new perspective, one that would challenge the dogma and traditions of Ravenhurst.\r\n\r\nLord Silas took notice of Eira's transformation and saw an opportunity for himself to aggrandize his own influence. He began to castigate those who opposed him, using his words as a means to bolster his power. However, Eira was not swayed. She knew that the only way to alleviate the trepid and malingering emotions that plagued the village was to desiccate the festering wounds of despair.\r\n\r\nWith newfound courage, Eira stood before Lord Silas and addressed him with an audacious yet calm tone. \"Your words have been a catalyst for chaos,\" she said, \"but they do not have to be the only force driving our lives.\" She proposed an alternative: a path that balanced decorum with compassion, where art and wisdom could flourish without desultory indulgence.\r\n\r\nAs Eira spoke, the room began to dissemble around her. The cacophony of emotions slowly receded, replaced by a sense of discordant silence. Lord Silas, taken aback by her articulacy, felt his own words turn against him. He realized that he had been abating his own humanity in favor of grandstanding and self-aggrandizement.\r\n\r\nIn the end, Eira's words were met with a resounding applause from the villagers, who had long been waiting for someone to articulate a better way forward. The village began to dilate its horizons, embracing new ideas and perspectives that would bolster their resilience and strength.\r\n\r\nAs for Lord Silas, he was forced to confront his own contradictions and begin anew. He learned to assuage the suffering of others and to abate his own ego. And Eira? She continued on her journey, an embodiment of lucid wisdom, guiding Ravenhurst toward a brighter future, where art and compassion would forever be intertwined.\r\n\r\n\r\n",
            };

            // Use AI chat
            var wordsList = string.Join(", ", words.Select(w => w.Text));
            var prompt = "Create a short story to help me understand and study the following words. The story should clarify the meaning of the words. Only reply with the story content and nothing else: \n\n" + wordsList;
            var agent = _chatClient.AsAIAgent();
            var response = await agent.RunAsync(prompt);
            story.Content = response.Text;

            var enumerator = words.GetEnumerator();
            for (var i = 0; i < words.Count(); i++)
            {
                if (enumerator.MoveNext())
                {
                    var storyWord = new StoryWord()
                    {
                        PositionInStory = i,
                        WordId = enumerator.Current.Id,
                    };

                    story.StoryWords.Add(storyWord);
                }
            }

            // Create a custom title
            var titlePrompt = $"Suggest a title for the below story. Only include the title without double quotes and nothing else in your response, as i will copy it right away. \n\n {story.Content}";
            var titleResponse = await agent.RunAsync(titlePrompt);
            story.Title = titleResponse.Text;

            return story;
        }
    }
}
