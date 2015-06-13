using System;
using System.Collections.Generic;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Events
{
    public class QuestionEvent : ScheduleEvent
    {
        public List<string> NevermindSentences { get; set; }//what to answer if we are stopping waiting for the answer
        public int ExpirationTimeSecs { get; set; } //how many time to wait for the answer


        public override void Execute(IMessenger messenger, IUserId userId)
        {
            String question = GetRandomMessage();
            Logger.Out("Asking question: {0} to user: {1}", MessageType.Verbose, question, userId);
            messenger.SendMessage(question, userId);
        }

    }
}
