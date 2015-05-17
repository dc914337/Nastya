using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Nastya.executor.context
{
    public class DefaultCommandContext
    {
        public Random Rnd { get; set; }
        
        public DefaultCommandContext()
        {
            Rnd = new Random();
        }
    }
}
