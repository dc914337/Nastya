using System;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day;
using Nastya.Nastya.Executors.ContextManagement;
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
            var userContext = GetDayContext(command);
            

            String response = GetRandomStringFromList(
               userContext.DayStarted ?
                 AlreadyGreetedResponses :
                 Responses);

            userContext.DayStarted = true;
            userContext.Kicker.Start(
                ContextManager.GetOrCreateContext<CommonScheduleContext>(Contexts.CommonScheduleContext).DefaultSchedule,
                ContextManager.GetOrCreateUsersContext<AnswerContext>(Contexts.AnswerContext, userId),
                ContextManager.GetOrCreateUsersContext<DayContext>(Contexts.DayContext, userId)
                );
            try
            {
                await command.Source.SendMessage(response, userId);
            }
            catch (Exception ex)
            {
                Logger.Out("HelloCommand: error sending message to {0}. Message: {1}", MessageType.Error, userId, ex.Message);
            }

            return true;
        }

        private void InitDayContextIfNotInited(Message command)
        {
            
        }






    }
}
