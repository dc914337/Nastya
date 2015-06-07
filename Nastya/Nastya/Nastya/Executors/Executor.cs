
using System;
using Nastya.Nastya.Configs;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;
using Nastya.Utils.Datatypes;

namespace Nastya.Nastya.Executors
{
    class Executor
    {
        private NastyaCommand[] _nastyaCommands;

        public Executor(Config config)
        {
            ContextManager contextManager = new ContextManager();
            _nastyaCommands = config.Commands;
            foreach (var command in _nastyaCommands)
            {
                command.ContextManager = contextManager;
            }
            Array.Sort(_nastyaCommands);
            Array.Reverse(_nastyaCommands);
        }



        public void ProcessMessage(Message message)
        {
            Logger.Out("Processing MessageBody \"{0}\" from {1}({2})", MessageType.Verbose, message.MessageBody, message.From, message.Source);
            ExecuteCommand(message);
        }

        private void ExecuteCommand(Message message)
        {
            NastyaCommand selectedCommand = SelectCommand(message);

            if (selectedCommand == null)
            {
                Logger.Out("Didn't find any command.. {0}", MessageType.Error, message.MessageBody);
            }
            else
            {
                Logger.Out("Found command: {0}. Source MessageBody: {1}", MessageType.Debug, selectedCommand.CommandId, message.MessageBody);
                selectedCommand.Execute(message);
            }

        }


        private NastyaCommand SelectCommand(Message message)
        {
            NastyaCommand priorCommand = null;
            Percents maxRate = null;
            foreach (var nastyaCommand in _nastyaCommands)
            {
                var checkResult = nastyaCommand.CheckCommandFits(message);
                if (checkResult == null || checkResult.Fits == Fits.DoesNot) continue;

                if (checkResult.Fits == Fits.Perfectly)
                {
                    priorCommand = nastyaCommand;
                    break;
                }

                if ( priorCommand != null && checkResult.PercentsFits <= maxRate ) continue;
                priorCommand = nastyaCommand;
                maxRate = checkResult.PercentsFits;
            }
            return priorCommand;
        }
    }
}

