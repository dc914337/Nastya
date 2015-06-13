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
    public class AnswerCommand : NastyaCommand
    {
        public WordSequences RefuceSequences { get; set; }
        public WordSequences AcceptSequences { get; set; }
        public WordSequences SkipSequences { get; set; }
        public QuestionEvent Question { get; set; } = new QuestionEvent();

        public override void OnLoad()
        {
            Logger.Out("Additional onload from {0}. ", MessageType.Debug, CommandName);
            ContextManager.GetOrCreateContext<CommonScheduleContext>(Contexts.CommonScheduleContext).DefaultSchedule.Add(Question);
            base.OnLoad();
        }

        public override Task<bool> Execute(Message command)
        {
            var dayContext = ContextManager.GetOrCreateUsersContext<DayContext>(Contexts.DayContext, command.From);
            var answerContext = ContextManager.GetOrCreateUsersContext<AnswerContext>(Contexts.AnswerContext, command.From);
            answerContext.AskedQuestion = null;

            return null;
        }

        public override CheckResult CheckCommandFits(Message command)
        {
            var answerContext = ContextManager.GetOrCreateUsersContext<AnswerContext>(Contexts.AnswerContext, command.From);
            if (answerContext.AskedQuestion != Question)  //if not our task asked question then return that command does not fits
                return new CheckResult(Fits.DoesNot);

            String message = command.MessageBody;

            if (RefuceSequences.GetLongestFittingSequence(message) != null
                 || AcceptSequences.GetLongestFittingSequence(message) != null
                 || SkipSequences.GetLongestFittingSequence(message) != null)
                return new CheckResult(Fits.Perfectly);
            return new CheckResult(Fits.DoesNot);
        }

    }
}
