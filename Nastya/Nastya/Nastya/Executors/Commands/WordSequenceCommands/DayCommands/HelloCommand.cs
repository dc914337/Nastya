using System;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands
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

            var userContext = GetDayContext(userId);

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
