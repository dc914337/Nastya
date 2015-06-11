using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;

namespace Nastya.Nastya.Datatypes.Words
{
    public class WordSequences
    {
        public List<WordSequence> Sequences { get; set; }

        public WordSequence GetLongestFittingSequence(String message)
        {
            var words = GetCleanWords(message);
            return GetLongestFittingSequence(words);
        }

        public WordSequence GetLongestFittingSequence(string[] inputSequence)
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

        private static char[] delimiters = new char[] { '\r', '\n', ' ' };

        private static string[] GetCleanWords(String str)
        {
            var removedSymbols = GetCleanText(str);
            var words = removedSymbols.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Where(a => !String.IsNullOrWhiteSpace(a)).Select(a => a.Trim()).ToArray();
            return words;
        }
    }
}
