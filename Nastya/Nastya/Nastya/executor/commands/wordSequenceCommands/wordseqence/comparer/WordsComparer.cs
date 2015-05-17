using System;

namespace Nastya.Nastya.executor.commands.wordSequenceCommands.wordseqence.comparer
{
    public class WordsComparer
    {
        public double Threshold { get; set; }//0.525

        public WordsComparer()
        {
        }

        public WordsComparer(double threshold)
        {
            Threshold = threshold;
        }

        public bool Equal(string s, string t)
        {
            int maxLength = Math.Max(s.Length, t.Length);

            return LevenshteinDistance.Compare(s, t) / ((double)maxLength) < Threshold;
        }
    }
}
