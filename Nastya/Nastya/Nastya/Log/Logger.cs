using System;
using System.Collections.Generic;

namespace Nastya.Nastya.Log
{
    static class Logger
    {
        private static readonly List<MessageType> ToOutput = new List<MessageType>();

        public static void AddTypeToOutput(MessageType type)
        {
            ToOutput.Add(type);
        }

        public static void Out(String message, MessageType type, params Object[] parameters)
        {
            if (ToOutput.Contains(type))
                Console.WriteLine(AddPrefix(type, String.Format(message, parameters)));
        }

        private static String AddPrefix(MessageType type, String message)
        {
            return String.Format("[ {0} ] {1}", type, message);
        }
    }
}
