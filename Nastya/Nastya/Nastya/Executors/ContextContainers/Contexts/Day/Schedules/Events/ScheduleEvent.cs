using System;
using System.Collections.Generic;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Events
{
    public class ScheduleEvent
    {
        public List<string> Messages { get; set; } //question or reminder to ask
        public int DelayFromDayStartSecs { get; set; } //seconds from day start to ask question


        private Random rnd = new Random();
        public String GetRandomMessage()
        {
            var randomMessage = Messages[rnd.Next(0, Messages.Count)];
            return randomMessage;
        }

        public virtual void Execute(IMessenger messenger, IUserId userId)
        {
            String notification = GetRandomMessage();
            Logger.Out("Sending notification: {0} to user: {1}", MessageType.Verbose, notification, userId);
            messenger.SendMessage(notification, userId);
        }
    }
}
