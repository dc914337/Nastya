using System;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya.Nastya.Messenger
{
    public class Message
    {
        public IUserId From { get; }
        public DateTime? Date { get; }
        public string MessageBody { get; }
        public IMessenger Source { get; }


        public Message(string messageBody, IUserId from, DateTime? Date, IMessenger source)
        {
            this.MessageBody = messageBody;
            this.From = from;
            this.Date = Date;
            Source = source;
        }

        public static Message GetMessageFromVk(VKSharp.Core.Entities.Message vkMessage, IMessenger source)
        {
            DateTime? date = null;
            if (vkMessage.Date != null)
            {
                date = DateTimeOffset.FromUnixTimeSeconds((long)((int)vkMessage.Date)).DateTime;
            }
            return new Message(vkMessage.Body, new VkUserId(vkMessage.UserId), date, source);
        }


        //mb picture
    }

}
