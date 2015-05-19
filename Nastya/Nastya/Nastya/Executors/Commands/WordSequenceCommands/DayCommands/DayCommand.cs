using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Context;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands
{
    public abstract class DayCommand : WordSequenceCommand
    {
        public string[] Responses { get; set; }

        public override ContextContainer ContextContainer
        {
            get
            {
                return _contextContainer;
            }

            set
            {
                _contextContainer = (UserContextsContainer<DayContext>)value;
            }
        }

        private UserContextsContainer<DayContext> _contextContainer = new UserContextsContainer<DayContext>();

        protected DayContext GetContext(IUserId userId)
        {
            return _contextContainer.GetOrCreateContext(userId);
        }

    }
}
