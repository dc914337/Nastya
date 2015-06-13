

using System.Runtime.Remoting.Messaging;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day
{
    public class DayContext : BaseContext
    {
        private bool _dayStarted = false;
        public bool DayStarted { get; set; }
        public IUserId UserId { get; set; }
        public IMessenger Messenger { get; set; }

        public Kicker Kicker { get; set; } = new Kicker();
    }
}
