using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nastya.Nastya.Executors;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors.Commands
{
    [XmlInclude(typeof(HelpCommand))]
    [XmlInclude(typeof(ChitChatCommand))]
    [XmlInclude(typeof(HelloCommand))]
    [XmlInclude(typeof(ByeCommand))]
    public abstract class NastyaCommand : INastyaCommand
    {
        public NastyaCommand()
        {
            //for xml serializer
        }

        public int Priority { get; set; }
        public string CommandId { get; set; }
        public CommandType Type { get; set; }
        public abstract ContextContainer ContextContainer { get; set; }

        public abstract Task<bool> Execute(Message command);
        public abstract CheckResult CheckCommandFits(Message command);

    }
}
