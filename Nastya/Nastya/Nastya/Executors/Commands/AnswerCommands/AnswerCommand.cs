using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors.Commands.AnswerCommands
{
    public class AnswerCommand : NastyaCommand
    {
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
