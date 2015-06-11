using System;
using System.Collections.Generic;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks
{
    public class ScheduleTask
    {
        public List<String> Messages { get; set; } //question or reminder to ask
        public int DelayFromDayStartSecs { get; set; } //seconds from day start to ask question


        protected DateTime Ask { get; set; }
    }
}
