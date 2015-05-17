using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.logger;
using Nastya.Nastya.messenger.userId;

namespace Nastya.Nastya.executor.context
{
    public class DayContext : DefaultCommandContext
    {
        Dictionary<IUserId, UserContext> _greetedList = new Dictionary<IUserId, UserContext>();

        public UserContext GetOrCreateUserContext(IUserId id, Thread kickingThread)
        {
            Logger.Out("Created day context(new user) ", MessageType.Debug);
            if (_greetedList.ContainsKey(id))
            {
                return _greetedList[id];
            }
            else
            {
                var newContext = new UserContext(kickingThread);
                _greetedList.Add(id, newContext);
                return newContext;
            }
        }

    }
}
