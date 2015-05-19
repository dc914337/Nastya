using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Messenger
{
    public interface IMessenger
    {
        Messengers Type { get; }
        Task<Message[]> GetNewMessages();
        Task SendMessage(String message, IUserId userId);
    }
}
