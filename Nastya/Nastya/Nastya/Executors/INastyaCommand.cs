using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors
{
    interface INastyaCommand
    {
        int Priority { get; }
        String CommandId { get; }
        CommandType Type { get; }
        Task<bool> Execute(Message command);
        CheckResult CheckCommandFits(Message command);
    }
}
