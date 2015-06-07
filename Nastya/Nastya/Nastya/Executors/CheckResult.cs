using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors;
using Nastya.Utils.Datatypes;

namespace Nastya.Nastya.Executors
{
    public class CheckResult
    {
        public CheckResult(Fits fits, int percentsFits)
        {
            PercentsFits = new Percents(percentsFits);
            Fits = fits;
        }

        public CheckResult(Fits fits)
        {
            Fits = fits;
            PercentsFits = new Percents(0);
        }

        public Percents PercentsFits { get; }
        public Fits Fits { get; }

    }
}
