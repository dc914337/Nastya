using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.ContextContainer.Context;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands
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
