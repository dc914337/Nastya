using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nastya.Nastya.executor.commands.wordSequenceCommands.wordseqence;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.messenger;

namespace Nastya.Nastya.executor.commands.wordSequenceCommands
{
    public abstract class WordSequenceCommand : NastyaCommand
    {
        public List<WordSequence> Sequences { get; set; } //sort sequences

        protected WordSequenceCommand()
        {
            Sequences = new List<WordSequence>();
        }

        protected CommonContextContainer<DefaultCommandContext> CommonContextContainer = new CommonContextContainer<DefaultCommandContext>();

        private DefaultCommandContext Context => CommonContextContainer.GetContext();

        public override CheckResult CheckCommandFits(Message command)
        {
            var words = GetCleanWords(command.MessageBody);
            var longestFittingSeq = GetLongestFittingSequence(words);
            if (longestFittingSeq == null)
                return new CheckResult(CheckResults.Fail);
            var result = new CheckResult(CheckResults.Success, longestFittingSeq.Sequence.Length);
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


        private static String GetCleanText(String text)
        {
            return CollectStringFromArray(text.Trim().Where(a => !Char.IsSymbol(a)));
        }

        private static String CollectStringFromArray(IEnumerable<char> array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in array)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        private static string[] GetCleanWords(String str)
        {
            var removedSymbols = GetCleanText(str);
            var words = removedSymbols.Split(' ').Where(a => !String.IsNullOrWhiteSpace(a)).Select(a => a.Trim()).ToArray();
            return words;
        }

        protected String GetRandomStringFromList(string[] responses)
        {
            var num = Context.Rnd.Next(0, responses.Length);
            return responses[num];
        }

    }
}
