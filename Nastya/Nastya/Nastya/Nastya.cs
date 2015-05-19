using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Configs;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger.Vk;
using Nastya.Nastya.Executors;

namespace Nastya.Nastya
{
    public class Nastya
    {
        private const int TimeCheckMessages = 1000;

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
                foreach (var message in messages)
                {
                    Thread.Sleep(TimeBetweenMessages);
                    _executor.ProcessMessage(message);
                }

            }
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
