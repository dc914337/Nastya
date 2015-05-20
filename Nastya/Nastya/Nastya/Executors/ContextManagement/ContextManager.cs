using System.Collections.Generic;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Context;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextManagement
{
    public class ContextManager
    {
        private Dictionary<Contexts, ContextContainer> _allContexts = new Dictionary<Contexts, ContextContainer>();

        public T GetOrCreateContext<T>(Contexts key) where T : ContextContainer, new()
        {
            if (_allContexts.ContainsKey(key))
                return (T)_allContexts[key];
            var newContext = new T();
            _allContexts.Add(key, newContext);
            return newContext;
        }

        public V GetOrCreateUsersContext<T, V>(Contexts key, IUserId userId)
            where T : UserContextsContainer<V>, new()
            where V : DefaultCommandContext, new()
        {
            if (_allContexts.ContainsKey(key))
                return ((T)_allContexts[key]).GetOrCreateContext(userId);
            var newContext = new T();
            _allContexts.Add(key, newContext);
            return newContext.GetOrCreateContext(userId);
        }

    }
}
