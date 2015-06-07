using System;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;
using Nastya.Utils.Datatypes;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands
{
    public class ChitChatCommand : NastyaCommand, IRandomResponder
    {
        public string[] Responses { get; set; }

        private CommonContextContainer<RandomContext> _contextContainer = new CommonContextContainer<RandomContext>();

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
            return new CheckResult(Fits.Probably, new Percents(0));
        }

        private async Task<bool> Respond(IMessenger messenger, IUserId userId)
        {
            String response = Responses[_contextContainer.GetContext().Rnd.Next(0, Responses.Length)];
            await messenger.SendMessage(response, userId);
            return true;
        }


    }
}
