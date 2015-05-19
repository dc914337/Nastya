using System.Collections.Generic;
using Nastya.Nastya.Executors.ContextContainers.Context;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextContainers
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
