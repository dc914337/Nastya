using System;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.messenger;

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
            var userContext = GetOrCreateUserContext(command.From);

            String response = GetRandomStringFromList(
                userContext.Greeted ?
                 AlreadyGreetedResponses :
                 Responses);
            try
            {
                userContext.Greeted = true;
                await command.Source.SendMessage(response, command.From);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }

            return true;
        }





    }
}
