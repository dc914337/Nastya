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
        public CheckResult(Fits fits, Percents percentsFits)
        {
            PercentsFits = percentsFits;
            Fits = fits;
        }

        public CheckResult(Fits fits)
        {
            Fits = fits;
            switch (fits)
            {
                case Fits.DoesNot:
                case Fits.Probably:
                    PercentsFits = new Percents(0);
                    break;
                case Fits.Perfectly:
                    PercentsFits = new Percents(Percents.MaxValue);
                    break;
            }
        }

        public Percents PercentsFits { get; }
        public Fits Fits { get; }

    }
}
