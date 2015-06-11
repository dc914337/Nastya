using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;
using Nastya.Nastya.Log;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day
{
    public class Kicker
    {
        List<ScheduleTask> _schedule = new List<ScheduleTask>();
        private Thread _kickerThread;

        public void Start()
        {
            Logger.Out("Started kicker", MessageType.Debug);
            _kickerThread = new Thread(ProcessTasks);
            _kickerThread.Start();
        }

        public void Stop()
        {
            Logger.Out("Stopped kicker", MessageType.Debug);
            //todo check if thread is running
            _kickerThread.Abort();
        }

        public void AddTask(ScheduleTask task)
        {
            //todo make threadsafe
            _schedule.Add(task);
        }

        public void RemoveTask()
        {
            //todo make threadsafe

        }

        private static void ProcessTasks()
        {
            //stub
            int count = 0;
            do
            {
                Logger.Out("Kicker kicking {0}", MessageType.Verbose, count++);
                Thread.Sleep(1000);
            } while (true);
        }
    }
}
