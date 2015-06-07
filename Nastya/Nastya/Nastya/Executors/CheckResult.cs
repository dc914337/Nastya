using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors;

namespace Nastya.Nastya.Executors
{
    public class CheckResult
    {
        public CheckResult(Fits fits, int percentsFits)
        {
            PercentsFits = percentsFits;
            Fits = fits;
        }

        public CheckResult(Fits fits)
        {
            Fits = fits;
            PercentsFits = 0;
        }

        public int PercentsFits { get; }
        public Fits Fits { get; }

    }
}
