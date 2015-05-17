using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.executor.context;
using Nastya.Nastya.messenger;
using Nastya.Nastya.vk;

namespace Nastya.Nastya.executor
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
