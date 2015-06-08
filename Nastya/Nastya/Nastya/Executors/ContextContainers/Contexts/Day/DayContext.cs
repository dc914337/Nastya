

using System.Threading;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day
{
    public class DayContext : BaseContext
    {
        public bool Greeted { get; set; } = false;
        private Schedule _schedule = new Schedule();
        private Thread _scheduleThread;
        
        public void AddTaskToSchedule(ScheduleTask task)
        {
            _schedule.AddTask(task);
        }

    }
}
