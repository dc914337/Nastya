using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Events;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks
{
    class ScheduleTask
    {
        public TaskType Type { get; set; }      //i need this to avoid too many reflection
        public ScheduleEvent Event { get; set; }
        protected internal DateTime? AskTime { get; set; }
        public bool Executed { get; set; } = false;

        public ScheduleTask(ScheduleEvent scheduleEvent)
        {
            //aargkh! i didn't want to do that.. sorry.. but i think there will be only 2 classes. Notification and question. 
            var eventType = scheduleEvent.GetType();
            if (eventType == typeof(ScheduleEvent))
                Type = TaskType.NotificationTask;
            else if (eventType == typeof(QuestionEvent))
                Type = TaskType.QuestionTask;
            Event = scheduleEvent;
        }

        public void Execute(DayContext dayContext)
        {
            Event.Execute(dayContext.Messenger, dayContext.UserId);
        }

    }
}
