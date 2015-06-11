using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors.Commands.AnswerCommands
{
    public class AnswerCommand : NastyaCommand
    {
        public override void OnLoad()
        {
            Logger.Out("Additional onload from {0}. ", MessageType.Debug, CommandId);
            base.OnLoad();
        }

        public override Task<bool> Execute(Message command)
        {
            throw new NotImplementedException();
        }

        public override CheckResult CheckCommandFits(Message command)
        {
            throw new NotImplementedException();
        }
    }
}
