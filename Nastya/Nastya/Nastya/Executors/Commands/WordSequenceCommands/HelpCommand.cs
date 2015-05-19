using System;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands
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
