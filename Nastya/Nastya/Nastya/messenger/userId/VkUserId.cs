using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Nastya.Messenger.UserId
{
    class VkUserId : IUserId
    {
        public int Id { get; }

        public VkUserId(int id)
        {
            Id = id;
        }

        public override bool Equals(Object obj)
        {
            return Id == ((VkUserId)obj).Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
