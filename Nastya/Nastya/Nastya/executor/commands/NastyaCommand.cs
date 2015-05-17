using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nastya.Nastya.executor.commands.wordSequenceCommands;
using Nastya.Nastya.executor.commands.wordSequenceCommands.dayCommands;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.messenger;

namespace Nastya.Nastya.executor.commands
{
    [XmlInclude(typeof(HelpCommand))]
    [XmlInclude(typeof(ChitChatCommand))]
    [XmlInclude(typeof(HelloCommand))]
    [XmlInclude(typeof(ByeCommand))]
    public abstract class NastyaCommand : INastyaCommand
    {
        public NastyaCommand()
        {

        }

        protected DefaultCommandContext _context;
        protected NastyaContextManager _contextManager;

        public string ContextId { get; set; }
        public int Priority { get; set; }
        public string CommandId { get; set; }
        public CommandType Type { get; set; }

        public abstract Task<bool> Execute(Message command);
        public abstract CheckResult CheckCommandFits(Message command);

        public virtual void SetContext(NastyaContextManager contextManager)
        {
            _contextManager = contextManager;
            _context = contextManager.GetOrCreateContext(ContextId, new DefaultCommandContext());
        }

    }
}
