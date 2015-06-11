using System;
using System.Collections.Generic;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.Wordseqence;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks
{
    public class QuestionTask : ScheduleTask
    {
        public List<String> NevermindSentences { get; set; }//what to answer if we are stopping waiting for the answer
        public int ExpirationTimeSecs { get; set; } //how many time to wait for the answer

        protected DateTime Expires { get; set; }
    }
}
