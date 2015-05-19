using System;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.messenger;

namespace Nastya.Nastya.executor.commands.wordSequenceCommands.dayCommands
{
    public class ByeCommand : DayCommand, IRandomResponder
    {
        public ByeCommand()
        {
            //for xml serializer
        }



        public override async Task<bool> Execute(Message command)
        {
            var userContext = GetContext(command.From);

            String response = GetRandomStringFromList(Responses);

            userContext.Greeted = false;
            await command.Source.SendMessage(response, command.From);
            return true;
        }




    }
}
