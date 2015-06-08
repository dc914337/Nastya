using System.Collections.Generic;
using Nastya.Nastya.Executors.ContextContainers;
using Nastya.Nastya.Executors.ContextContainers.Contexts;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Executors.ContextManagement
{
    public class ContextManager
    {
        private Dictionary<Contexts, ContextContainer> _allContexts = new Dictionary<Contexts, ContextContainer>();

        public T GetOrCreateContext<T>(Contexts key)
            where T : BaseContext, new()
        {
            if (_allContexts.ContainsKey(key))
                return ((CommonContextContainer<T>)_allContexts[key]).GetContext();
            var newContext = new CommonContextContainer<T>();
            _allContexts.Add(key, newContext);
            return newContext.GetContext();
        }

        public T GetOrCreateUsersContext<T>(Contexts key, IUserId userId)
            where T : BaseContext, new()
        {
            if (_allContexts.ContainsKey(key))
                return ((UserContextsContainer<T>)_allContexts[key]).GetOrCreateContext(userId);
            var newContext = new UserContextsContainer<T>();
            _allContexts.Add(key, newContext);
            return newContext.GetOrCreateContext(userId);
        }

    }
}
