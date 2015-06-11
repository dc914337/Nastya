using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nastya.Nastya.Datatypes.Words;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Messenger;
using Nastya.Utils.Datatypes;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands
{
    public abstract class WordSequenceCommand : NastyaCommand
    {
        private const int LongestPossibleWordsSequance = 100;

        public WordSequences WordSequences { get; set; } //sort sequences

        protected WordSequenceCommand()
        {
            WordSequences = new WordSequences();
        }

        public override CheckResult CheckCommandFits(Message command)
        {
            var longestFittingSeq = WordSequences.GetLongestFittingSequence(command.MessageBody);
            if (longestFittingSeq == null)
                return new CheckResult(Fits.DoesNot);
            var result = new CheckResult(Fits.Probably, Percents.CountPercents(0, LongestPossibleWordsSequance, longestFittingSeq.Sequence.Length));
            return result;
        }


        protected String GetRandomStringFromList(string[] responses)
        {
            var num = ContextManager.GetOrCreateContext<RandomContext>(Contexts.GlobalContext).Rnd.Next(0, responses.Length);
            return responses[num];
        }
    }
}
