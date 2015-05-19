using System;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.ContextContainer;
using Nastya.Nastya.Executors.ContextContainer.Context;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands
{
    public class ChitChatCommand : NastyaCommand, IRandomResponder
    {
        public string[] Responses { get; set; }

        private CommonContextContainer<DefaultCommandContext> _contextContainer = new CommonContextContainer<DefaultCommandContext>();

        public ChitChatCommand()
        {
            //for xml serializer
        }
        
        public override async Task<bool> Execute(Message command)
        {
            return await Respond(command.Source, command.From);
        }

        public override CheckResult CheckCommandFits(Message command)
        {
            return new CheckResult(CheckResults.Success);
        }

        private async Task<bool> Respond(IMessenger messenger, IUserId userId)
        {
            String response = Responses[_contextContainer.GetContext().Rnd.Next(0, Responses.Length)];
            await messenger.SendMessage(response, userId);
            return true;
        }


    }
}
