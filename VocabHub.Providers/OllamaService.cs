using Microsoft.Extensions.AI;
using OllamaSharp;
using OllamaSharp.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabHub.Providers
{
    public class OllamaService
    {
        private readonly IChatClient _client;

        public OllamaService()
        {
            _client = new OllamaApiClient("http://localhost:11434 ");


        }

        public void Chat(string message)
        {
            var chat = new ChatRequest()
            {
                Messages = new List<Message>()
                {
                    new Message()
                    {
                        Content = message,
                        Role = OllamaSharp.Models.Chat.ChatRole.User,
                    }
                }
            };

        }
    }
}
