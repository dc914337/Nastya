using Nastya.Nastya.Executors.ContextContainers.Contexts;

namespace Nastya.Nastya.Executors.ContextContainers
{
    public class CommonContextContainer<T> : ContextContainer where T : BaseContext, new()       //new MUST come last
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
