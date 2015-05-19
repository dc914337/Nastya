using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.logger;
using Nastya.Nastya.messenger.userId;

namespace Nastya.Nastya.executor.context
{
    public class DayContext : DefaultCommandContext
    {
        public bool Greeted { get; set; } = false;
    }
}
