using System;
using System.Xml.Serialization;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands;

namespace Nastya.Nastya.Executors.ContextContainers.Context
{
    [XmlInclude(typeof(DayContext))]
    public class DefaultCommandContext
    {
        public Random Rnd { get; set; }
        
        public DefaultCommandContext()
        {
            Rnd = new Random();
        }
    }
}
