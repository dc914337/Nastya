using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Configs;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger.Vk;
using Nastya.Nastya.Executors;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya
{
    public class Nastya
    {
        private const int TimeCheckMessages = 5000;

        private const int TimeBetweenMessages = 1000;

        private Executor _executor;
        private Config _config;
        public NastyaVk Vk { get; private set; }


        private bool paused;

        public Nastya(String configPath)
        {
            //init
            _config = Config.GetFromFile(configPath);
            _executor = new Executor(_config);
            Vk = new NastyaVk(_config.VkToken);

        }


        public async Task Start()
        {
            paused = false;
            while (true)
            {

                if (paused)
                {
                    Thread.Sleep(TimeCheckMessages);
                    continue;
                }

                var messages = await Vk.GetNewMessages();
                if (!messages.Any())
                {
                    Thread.Sleep(TimeCheckMessages);
                    continue;
                }

                Logger.Out("Got {0} new messages", MessageType.Debug, messages.Count());

                var messageGroups = messages.Reverse().GroupBy(a => a.From);

                foreach (var messageGroup in messageGroups)
                {
                    _executor.ProcessMessage(GetMessageFromGroup(messageGroup));
                    Thread.Sleep(TimeBetweenMessages);

                }

            }
        }


        private Message GetMessageFromGroup(IEnumerable<Message> messageGroup)
        {
            StringBuilder fullBody = new StringBuilder();
            var sampleMessage = messageGroup.First();
            foreach (var message in messageGroup)
            {
                fullBody.Append(message.MessageBody);
                fullBody.Append(Environment.NewLine);
            }
            return new Message(
                fullBody.ToString(),
                sampleMessage.From,
                sampleMessage.Date,
                sampleMessage.Source);
        }

        public void Pause()
        {
            paused = true;
        }

        public void Resume()
        {
            paused = false;
        }
    }
}
