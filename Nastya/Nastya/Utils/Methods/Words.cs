using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Utils.Methods
{
    public static class Words
    {
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

        private static char[] delimiters = new char[] { '\r', '\n', ' '};

        public static string[] GetCleanWords(String str)
        {
            var removedSymbols = GetCleanText(str);
            var words = removedSymbols.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Where(a => !String.IsNullOrWhiteSpace(a)).Select(a => a.Trim()).ToArray();
            return words;
        }
    }
}
