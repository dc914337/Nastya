
using System;
using Nastya.Nastya.Configs;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.ContextManagement;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;


namespace Nastya.Nastya.Executors
{
    class Executor
    {
        private NastyaCommand[] nastyaCommands;

        public Executor(Config config)
        {
            //master commit
            ContextManager contextManager = new ContextManager();
            nastyaCommands = config.Commands;
            foreach (var command in nastyaCommands)
            {
                command.ContextManager = contextManager;
            }
        }

        public void ProcessMessage(Message message)
        {
            Logger.Out("Processing MessageBody \"{0}\" from {1}({2})", MessageType.Verbose, message.MessageBody, message.From, message.Source);
            ExecuteCommands(message);
        }

        private void ExecuteCommands(Message message)
        {
            NastyaCommand priorCommand = null;
            int maxRate = -1;
            foreach (var nastyaCommand in nastyaCommands)
            {
                var checkResult = nastyaCommand.CheckCommandFits(message);
                if (checkResult == null || checkResult.Fits != Fits.Perfectly) continue;

                if (priorCommand == null ||
                    priorCommand.Priority < nastyaCommand.Priority ||
                    (priorCommand.Priority == nastyaCommand.Priority && (int)checkResult.PercentsFits > maxRate))
                {
                    priorCommand = nastyaCommand;
                    maxRate = checkResult.PercentsFits;
                }
            }

            if (priorCommand == null)
            {
                Logger.Out("Didn't find any command.. {0}", MessageType.Debug, message.MessageBody);
            }
            else
            {
                Logger.Out("Found command: {0}. Source MessageBody: {1}", MessageType.Debug, priorCommand.CommandId, message.MessageBody);
                priorCommand.Execute(message);
            }

        }
    }
}

