using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Events;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day
{
    public class Kicker
    {
        List<ScheduleTask> _schedule = new List<ScheduleTask>();
        private Thread _kickerThread;
        private DateTime _dayStarted;
        private AnswerContext _answerContext;
        private DayContext _dayContext;


        public void Start(IEnumerable<ScheduleEvent> events, AnswerContext answerContext, DayContext dayContext)
        {
            Logger.Out("Started kicker", MessageType.Debug);
            AddTasksToSchedule(events);
            _answerContext = answerContext;
            _dayContext = dayContext;

            if (_kickerThread != null && _kickerThread.IsAlive) return;
            _kickerThread = new Thread(() => ProcessTasks(this));
            _dayStarted = DateTime.Now;
            _kickerThread.Start();
        }

        private void AddTasksToSchedule(IEnumerable<ScheduleEvent> events)
        {
            foreach (var scheduleEvent in events)
            {
                _schedule.Add(new ScheduleTask(scheduleEvent));
            }
        }


        public void Stop()
        {
            Logger.Out("Stopped kicker", MessageType.Debug);
            if (_kickerThread.IsAlive)
                _kickerThread.Abort();
        }

        //---------------

        private static void ProcessTasks(Kicker kicker)
        {
            List<ScheduleTask> schedule = kicker._schedule;
            var answerContext = kicker._answerContext;
            var dayContext = kicker._dayContext;
            do
            {
                SetUnsetTimes(schedule, kicker._dayStarted);
                var nextTask = GetTaskToExecute(schedule, answerContext);

                if (nextTask == null)
                {
                    Thread.Sleep(1000);
                    Logger.Out("Tick", MessageType.Debug);
                    continue;
                }
                nextTask.Execute(dayContext);
                if (nextTask.Event.GetType() == typeof(QuestionEvent))
                    answerContext.AskedQuestion = (QuestionEvent)nextTask.Event;
            } while (true);

        }

        private static ScheduleTask GetTaskToExecute(List<ScheduleTask> schedule, AnswerContext answerContext)
        {
            Sort(schedule);
            return schedule.FirstOrDefault(a => !a.Executed && a.AskTime <= DateTime.Now && answerContext.AskedQuestion == null);
        }

        private static void SetUnsetTimes(List<ScheduleTask> schedule, DateTime dayStarted)
        {
            foreach (var task in schedule.Where(task => task.AskTime == null))
            {
                task.AskTime = dayStarted.AddSeconds(task.Event.DelayFromDayStartSecs);
            }
        }

        private static void Sort(List<ScheduleTask> schedule)
        {
            schedule.Sort((a, b) => DateTime.Compare(a.AskTime.Value, b.AskTime.Value)); //can't be null
        }

        public ScheduleTask GetTaskByEvent(ScheduleEvent scheduleEvent)
        {
            return _schedule.FirstOrDefault( a => a.Event == scheduleEvent );
        }
    }



}
