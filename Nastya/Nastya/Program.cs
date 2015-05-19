using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Nastya.Nastya;
using Nastya.Nastya.config;
using Nastya.Nastya.config.mapper;
using Nastya.Nastya.executor;
using Nastya.Nastya.executor.commands;
using Nastya.Nastya.logger;
using Nastya;
using Nastya.Nastya.executor.commands.wordSequenceCommands;
using Nastya.Nastya.executor.commands.wordSequenceCommands.dayCommands;
using Nastya.Nastya.executor.commands.wordSequenceCommands.wordseqence;
using Nastya.Nastya.executor.commands.wordSequenceCommands.wordseqence.comparer;
using Nastya.Nastya.messenger;
using Nastya.Nastya.messenger.userId;

namespace Nastya
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = Stack.Synchronized(new Stack());


            //Thread addThread = new Thread(() => AddToStackThread(stack));
            //Thread foreachThread = new Thread(() => ForeachThread(stack));
            //addThread.Start();
            //foreachThread.Start();

            //Console.WriteLine(CreateSampleConfig());
            //Console.ReadKey();
            Logger.AddTypeToOutput(MessageType.Debug);
            Logger.AddTypeToOutput(MessageType.Error);
            Logger.AddTypeToOutput(MessageType.Verbose);

            var bot = new Nastya.Nastya(@"C: \Users\Smirnyaga\Desktop\testNastyaCfg.xml");
            bot.Start().Wait();
        }


        private static void AddToStackThread(Stack stack)
        {
            Random rnd = new Random();
            do
            {
                lock (stack)
                {
                    stack.Push(rnd.Next());
                    Console.WriteLine("added");
                }
            } while (true);
        }

        private static void ForeachThread(Stack stack)
        {
            do
            {
                int count = 0;
                lock (stack)
                {
                    foreach (var VARIABLE in stack)
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            } while (true);
        }


      


        static String CreateSampleConfig()
        {
            Config cfg = new Config();
            cfg.VkToken = "1c90280145a6a26a4bf544f525d324a10de5ff688867238cc5f413a2f0a3dfb951e0d0a12b206bbef7c98";

            WordsComparer comparer = new WordsComparer(0.525);
            var commands = new List<NastyaCommand>();

            HelpCommand help = new HelpCommand();
            help.CommandId = "HelpCommand";
            help.HelpString = "somehelpstring";
            help.Priority = 1;
            help.Type = CommandType.Info;

            help.Sequences = new List<WordSequence>()
            {
                new WordSequence(comparer,SequenceType.Disordered, new String[]{ "помоги"})
            };
            commands.Add(help);



            ChitChatCommand chat = new ChitChatCommand();
            chat.CommandId = "ChitChatCommand";
            chat.Priority = 0;
            chat.Responses = new string[] { "норм", "неплохо", "кек", "лол" };
            chat.Type = CommandType.Dialog;
            commands.Add(chat);

            HelloCommand hi = new HelloCommand();
            hi.CommandId = "HelloCommand";
            hi.Priority = 2;
            hi.Type = CommandType.Dialog;
            hi.Responses = new string[] { "утро", "доброе утро" };
            hi.Sequences = new List<WordSequence>()
            {
                new WordSequence(comparer, SequenceType.Disordered, new String[] { "доброе", "утро" }),
                new WordSequence(comparer, SequenceType.Disordered, new String[] { "привет"})
            };
            commands.Add(hi);

            ByeCommand bye = new ByeCommand();
            bye.CommandId = "ByeCommand";
            bye.Priority = 2;
            bye.Type = CommandType.Dialog;
            bye.Responses = new string[] { "пока", "спокойной ночи", "сладких" };
            bye.Sequences = new List<WordSequence>()
            {
                new WordSequence(comparer, SequenceType.Ordered, new String[] { "спокойной", "ночи" }),
                new WordSequence(comparer, SequenceType.Disordered, new String[] { "пока"})
            };
            commands.Add(bye);

            ByeCommand rudeBye = new ByeCommand();
            rudeBye.CommandId = "RudeByeCommand";
            rudeBye.Priority = 2;
            rudeBye.Type = CommandType.Dialog;
            rudeBye.Responses = new string[] { "уебывай", "иди нахуй", "съеби" };
            rudeBye.Sequences = new List<WordSequence>()
            {
                new WordSequence(comparer, SequenceType.Disordered, new String[] { "иди", "нахуй" }),
                 new WordSequence(comparer, SequenceType.Disordered, new String[] { "иди", "на","хуй" })
            };
            commands.Add(rudeBye);

            cfg.Commands = commands.ToArray();
            return XMLSerializer.GetXmlFromConfig(cfg);
        }

    }
}
