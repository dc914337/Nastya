using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Messenger;

namespace Nastya.Nastya.Executors
{
    interface INastyaCommand
    {
        int Priority { get; }
        String CommandName { get; }
        CommandType Type { get; }
        Task<bool> Execute(Message command);
        CheckResult CheckCommandFits(Message command);
    }
}
