using System;
using System.Threading.Tasks;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.messenger;
using Nastya.Nastya.messenger.userId;

namespace Nastya.Nastya.executor.commands.wordSequenceCommands
{
    public class HelpCommand : WordSequenceCommand
    {
        public String HelpString { get; set; }
        
        public HelpCommand()
        {
            //for xml serializer
        }

        public override async Task<bool> Execute(Message command)
        {
            return await Respond(command.Source, command.From);
        }

        private async Task<bool> Respond(IMessenger messenger, IUserId userId)
        {
            await messenger.SendMessage(HelpString, userId);
            return true;
        }
    }
}
