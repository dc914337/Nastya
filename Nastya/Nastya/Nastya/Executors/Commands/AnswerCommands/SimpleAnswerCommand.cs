using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Datatypes.Words;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Events;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors.Commands.AnswerCommands
{
    public class SimpleAnswerCommand : NastyaCommand
    {
        public WordSequences RefuceSequences { get; set; }
        public WordSequences AcceptSequences { get; set; }
        public WordSequences SkipSequences { get; set; }
        public QuestionEvent Question { get; set; } = new QuestionEvent();

        public int RefuseRepeatSeconds { get; set; }

        public override void OnLoad()
        {
            Logger.Out("Additional onload from {0}. ", MessageType.Debug, CommandName);
            ContextManager.GetOrCreateContext<CommonScheduleContext>(Contexts.CommonScheduleContext).DefaultSchedule.Add(Question);
            base.OnLoad();
        }

        public override CheckResult CheckCommandFits(Message command)
        {
            var answerContext = ContextManager.GetOrCreateUsersContext<AnswerContext>(Contexts.AnswerContext, command.From);
            if (answerContext.AskedQuestion != Question)  //if not our task asked question then return that command does not fits
                return new CheckResult(Fits.DoesNot);

            String message = command.MessageBody;

            if (InputSequence(message) != SequenceType.Unrecognised)
                return new CheckResult(Fits.Perfectly);

            return new CheckResult(Fits.DoesNot);
        }

        private SequenceType InputSequence(String message)
        {
            if (AcceptSequences.GetLongestFittingSequence(message) != null)
                return SequenceType.AcceptSequences;

            if (RefuceSequences.GetLongestFittingSequence(message) != null)
                return SequenceType.RefuceSequences;

            if (SkipSequences.GetLongestFittingSequence(message) != null)
                return SequenceType.SkipSequences;

            return SequenceType.Unrecognised;
        }

        public override Task<bool> Execute(Message command)
        {
            String message = command.MessageBody;
            var dayContext = ContextManager.GetOrCreateUsersContext<DayContext>(Contexts.DayContext, command.From);
            var answerContext = ContextManager.GetOrCreateUsersContext<AnswerContext>(Contexts.AnswerContext, command.From);

            switch (InputSequence(message))
            {
                case SequenceType.AcceptSequences:
                    DoAccept();
                    break;
                case SequenceType.RefuceSequences:
                    DoRefuce(dayContext);
                    break;
                case SequenceType.SkipSequences:
                    DoSkip();
                    break;
                default:
                    Logger.Out("WTF? It can't be. Executing unrecognisable sequnce. Message: {0}, Type: {1}", MessageType.Error, message, InputSequence(message));
                    break;
            }

            answerContext.AskedQuestion = null;
            return null;
        }

        private void DoRefuce(DayContext dayContext)
        {
            //reask question later
            Logger.Out("User refuced {0} question", MessageType.Verbose, CommandName);
            //reschedule
            var task = dayContext.Kicker.GetTaskByEvent(Question);
            task.AskTime = DateTime.Now.AddSeconds(15);
            task.Executed = false;
        }
        private void DoAccept()
        {
            Logger.Out("User accepted {0} question", MessageType.Verbose, CommandName);
        }
        private void DoSkip()
        {
            Logger.Out("User skipped {0} question", MessageType.Verbose, CommandName);
        }


        enum SequenceType
        {
            RefuceSequences,
            AcceptSequences,
            SkipSequences,
            Unrecognised
        }

    }
}
