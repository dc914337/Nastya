using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Nastya.executor.context
{
    public class CommonContextContainer<T> : ContextContainer where T : DefaultCommandContext, new()       //new MUST come last
    {
        private T _context;

        public CommonContextContainer()
        {
            _context = new T();
        }


        public T GetContext()
        {
            return _context;
        }
    }
}
