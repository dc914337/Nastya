using System;
using System.Xml.Serialization;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts
{
    //[XmlInclude(typeof(DayContext))]
    public class RandomContext : BaseContext
    {
        public Random Rnd { get; }

        public RandomContext()
        {
            Rnd = new Random();
        }
    }
}
