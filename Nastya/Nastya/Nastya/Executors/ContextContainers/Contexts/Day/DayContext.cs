

using System.Threading;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day
{
    public class DayContext : BaseContext
    {

        private bool _dayStarted = false;
        public bool DayStarted
        {
            get
            {
                return _dayStarted;
            }
            set
            {
                _dayStarted = value;
                if (_dayStarted)
                    Kicker.Start();
                else
                    Kicker.Stop();
            }
        }

        public Kicker Kicker = new Kicker();
    }
}
