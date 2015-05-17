using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Nastya.executor.context
{
    public class NastyaContextManager
    {
        private Dictionary<String, DefaultCommandContext> _contexts;

        public Nastya Nastya { get; set; }


        public NastyaContextManager(Nastya nastya)
        {
            _contexts = new Dictionary<string, DefaultCommandContext>();
            Nastya = nastya;
        }

        public DefaultCommandContext GetOrCreateContext(String contextId, DefaultCommandContext context)
        {
            if (_contexts.ContainsKey(contextId))
            {
                return _contexts[contextId];
            }
            else
            {
                _contexts.Add(contextId, context);
                return context;
            }
        }
    }
}
