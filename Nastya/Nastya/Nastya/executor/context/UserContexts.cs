using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.messenger.userId;

namespace Nastya.Nastya.executor.context
{
    class UserContextsContainer<T> : ContextContainer where T : DefaultCommandContext, new()         //new MUST come last
    {
        private Dictionary<IUserId, T> _contexts = new Dictionary<IUserId, T>();

        public T GetOrCreateContext(IUserId userId)
        {
            if (_contexts.ContainsKey(userId))
                return _contexts[userId];
            return CreateContext(userId);
        }

        private T CreateContext(IUserId userId)
        {
            var newContext = new T();
            _contexts.Add(userId, newContext);
            return newContext;
        }

    }
}
