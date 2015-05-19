using System;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands
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
