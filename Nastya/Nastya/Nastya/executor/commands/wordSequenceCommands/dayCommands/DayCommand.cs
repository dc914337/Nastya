using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.messenger;
using Nastya.Nastya.messenger.userId;

namespace Nastya.Nastya.executor.commands.wordSequenceCommands.dayCommands
{
    public abstract class DayCommand : WordSequenceCommand
    {
        public string[] Responses { get; set; }


        public override void SetContext(NastyaContextManager contextManager)
        {
            _contextManager = contextManager;
            _context = contextManager.GetOrCreateContext(ContextId, new DayContext());
        }

        protected DayContext GetDayContext()
        {
            return (DayContext)_context;
        }

        protected static void KickingThread(NastyaContextManager contextManager, IUserId from)
        {
            Kicker kicker = new Kicker(contextManager, from);
            kicker.Start();
        }

        protected UserContext GetOrCreateUserContext(IUserId from)
        {
            return GetDayContext().GetOrCreateUserContext(from, new Thread(() => KickingThread(_contextManager, from)));
        }

    }
}
