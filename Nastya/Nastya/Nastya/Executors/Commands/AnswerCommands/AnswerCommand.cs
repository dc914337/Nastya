using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.Wordseqence;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors.Commands.AnswerCommands
{
    public class AnswerCommand : NastyaCommand
    {
        public List<WordSequence> RefuceSequences { get; set; }
        public List<WordSequence> AcceptSequences { get; set; }
        public List<WordSequence> SkipSequences { get; set; }
        public QuestionTask Task { get; set; }


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
            if (AnswerContext.AskedQuestion != Task)  //if not our task asked question then return false
                return new CheckResult(Fits.DoesNot);
            return null;//stub
            // if(RefuceSequences.)
        }
    }
}
