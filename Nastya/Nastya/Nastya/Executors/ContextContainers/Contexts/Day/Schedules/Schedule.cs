using System.Collections.Generic;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules
{
    class Schedule
    {
        List<ScheduleTask> _tasks = new List<ScheduleTask>();

        public void AddTask(ScheduleTask task)
        {
            _tasks.Add(task);
        }
    }
}
