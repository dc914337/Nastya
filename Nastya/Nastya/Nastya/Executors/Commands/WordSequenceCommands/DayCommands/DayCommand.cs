using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands
{
    public abstract class DayCommand : WordSequenceCommand
    {
        public string[] Responses { get; set; }

        protected DayContext GetDayContext(IUserId userId)
        {

            return ContextManager.GetOrCreateUsersContext<DayContext>(Contexts.DayContext, userId);

        }

    }
}
