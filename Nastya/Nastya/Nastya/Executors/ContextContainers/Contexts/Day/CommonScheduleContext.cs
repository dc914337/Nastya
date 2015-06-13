using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Events;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day
{
    class CommonScheduleContext : BaseContext
    {
        public List<ScheduleEvent> DefaultSchedule { get; set; } = new List<ScheduleEvent>();

    }
}
