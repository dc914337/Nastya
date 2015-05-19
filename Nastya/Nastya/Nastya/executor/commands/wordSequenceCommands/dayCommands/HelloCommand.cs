using System;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.logger;
using Nastya.Nastya.messenger;
using Nastya.Nastya.messenger.userId;

namespace Nastya.Nastya.executor.commands.wordSequenceCommands.dayCommands
{
    public class HelloCommand : DayCommand, IRandomResponder
    {
        public string[] AlreadyGreetedResponses { get; set; }



        public HelloCommand()
        {
            //for xml serializer
        }

        public async override Task<bool> Execute(Message command)
        {
            var userId = command.From;

            var userContext = GetContext(userId);

            String response = GetRandomStringFromList(
               userContext.Greeted ?
                 AlreadyGreetedResponses :
                 Responses);
            try
            {
                userContext.Greeted = true;
                await command.Source.SendMessage(response, userId);
            }
            catch (Exception ex)
            {
                Logger.Out("HelloCommand: error sending message to {0}", MessageType.Error, userId);
            }

            return true;
        }





    }
}
