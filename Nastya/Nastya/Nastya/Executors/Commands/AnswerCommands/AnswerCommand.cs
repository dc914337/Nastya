using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Datatypes.Words;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;
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
        public QuestionTask Question { get; set; } = new QuestionTask();

        protected AnswerContext AnswerContext { get; set; }

        public override void OnLoad()
        {
            Logger.Out("Additional onload from {0}. ", MessageType.Debug, CommandName);
            AnswerContext = ContextManager.GetOrCreateContext<AnswerContext>(Contexts.AnswerContext);
            base.OnLoad();
        }

        public override Task<bool> Execute(Message command)
        {
            throw new NotImplementedException();
        }

        public override CheckResult CheckCommandFits(Message command)
        {
            if (AnswerContext.AskedQuestion != Question)  //if not our task asked question then return that command does not fits
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
