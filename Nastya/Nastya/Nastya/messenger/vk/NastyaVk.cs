using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger.UserId;
using VKSharp;
using VKSharp.Core.Enums;
using VKSharp.Data.Api;
using MessageType = Nastya.Nastya.Log.MessageType;

namespace Nastya.Nastya.Messenger.Vk
{
    public class NastyaVk : IMessenger
    {
        private const int ApiDelay = 333; // delay between 2 vk api requests(3 in a second)
        private readonly VKApi _api;
        private readonly Random _rnd = new Random();

        //private static Stack<IMessageListener> 



        public NastyaVk(String vkToken)
        {
            _api = new VKApi();
            _api.AddToken(new VKToken(vkToken));
        }

        public Messengers Type => Messengers.VK;

        public async Task<Message[]> GetNewMessages()
        {
            var vkMessages = (await _api.Messages.Get()).Items.Where(a => a.ReadState == MessageReadState.Unread);
            Thread.Sleep(ApiDelay);
            await SetReadState(vkMessages);
            var nastyaMessages = vkMessages.Select(a => Message.GetMessageFromVk(a, this)).ToArray();
            return nastyaMessages;
        }

        private async Task<bool> SetReadState(IEnumerable<VKSharp.Core.Entities.Message> messages)
        {
            foreach (var message in messages)
            {
                await _api.Messages.MarkAsRead(message.UserId, message.Id);
                Thread.Sleep(ApiDelay);
            }
            return true;
        }

        public async Task SendMessage(String message, IUserId userId)
        {
            try
            {
                await _api.Messages.Send(userId: ((VkUserId)userId).Id, message: message, guid: _rnd.Next());
            }
            catch (Exception ex)
            {
                Logger.Out("Error sending message: {0}", MessageType.Error, ex.Message);
            }

        }


    }
}
