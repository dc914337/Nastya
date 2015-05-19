using System;

namespace Nastya.Nastya.Executors.ContextContainer.Context
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
