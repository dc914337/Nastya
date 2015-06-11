using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.Wordseqence;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Messenger;
using Nastya.Utils.Datatypes;
using Nastya.Utils.Methods;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands
{
    public abstract class WordSequenceCommand : NastyaCommand
    {
        private static int longestPossibleWordsSequance = 100;

        public List<WordSequence> Sequences { get; set; } //sort sequences

        protected WordSequenceCommand()
        {
            Sequences = new List<WordSequence>();
        }

        public override CheckResult CheckCommandFits(Message command)
        {
            var words = Words.GetCleanWords(command.MessageBody);

            var longestFittingSeq = GetLongestFittingSequence(words);
            if (longestFittingSeq == null)
                return new CheckResult(Fits.DoesNot);
            var result = new CheckResult(Fits.Probably, Percents.CountPercents(0, longestPossibleWordsSequance, longestFittingSeq.Sequence.Length));
            return result;
        }

        private WordSequence GetLongestFittingSequence(string[] inputSequence)
        {
            WordSequence maxSequence = null;
            foreach (var currSequence in Sequences)
            {
                if (!currSequence.InSequence(inputSequence)) continue;

                if (maxSequence == null)
                    maxSequence = currSequence;
                else if (maxSequence.Sequence.Length < currSequence.Sequence.Length)
                    maxSequence = currSequence;
            }
            return maxSequence;
        }
        
        protected String GetRandomStringFromList(string[] responses)
        {
            var num = ContextManager.GetOrCreateContext<RandomContext>(Contexts.GlobalContext).Rnd.Next(0, responses.Length);
            return responses[num];
        }
    }
}
