using System;
using System.Collections.Generic;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.Wordseqence;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks
{
    class QuestionTask : ScheduleTask
    {
        public List<WordSequence> AcceptWordSequences { get; set; }
        public List<WordSequence> RefuseWordSequences { get; set; }

        public List<String> StoppedWaitingForAnswerResponses{ get; set; }//what to answer if we are stopping waiting for the answer(time left more than MaxTimeWaitAnswerSecs)

        public int MaxTimeWaitAnswerSecs { get; set; }

        public int PeriodRefusesSecs { get; set; } //how many secs wait until re-asking when refused

        public int PeriodAcceptsSecs { get; set; } //how many secs wait until re-asking when accepted

    }
}
