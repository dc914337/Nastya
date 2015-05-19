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

        
        private UserContextsContainer<DayContext> _contextContainer = new UserContextsContainer<DayContext>();

        protected DayContext GetContext(IUserId userId)
        {
            return _contextContainer.GetOrCreateContext(userId);
        }
        
    }
}
