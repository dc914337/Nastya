using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.messenger.userId;

namespace Nastya.Nastya.executor.commands.wordSequenceCommands.dayCommands
{
    class Kicker
    {
        private Nastya _nastya;
        private IUserId user;


        public Kicker(NastyaContextManager contextManager, IUserId from)
        {
            _nastya = contextManager.Nastya;
        }

        public async void Start()
        {
            _nastya.Pause();
            Console.WriteLine("paused");
            for ( int i = 0; i < 10; i++ )
            {
                await _nastya.Vk.SendMessage("kick", user);
                Thread.Sleep(1000);
            }
            Console.WriteLine("unpaused");
            _nastya.Resume();
        }
    }
}
