using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastya.Nastya.Messenger.UserId
{
    public interface IUserId
    {
        bool Equals( object obj );

        string ToString();


        int GetHashCode();
    }
}
