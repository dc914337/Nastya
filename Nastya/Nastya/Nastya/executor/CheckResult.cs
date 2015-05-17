using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Nastya.executor
{
    public class CheckResult
    {
        public CheckResult(CheckResults type, int rate)
        {
            Rate = rate;
            Type = type;
        }

        public CheckResult(CheckResults type)
        {
            Type = type;
            Rate = 0;
        }

        public int Rate { get; }
        public CheckResults Type { get; }

    }
}
