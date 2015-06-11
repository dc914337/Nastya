using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Nastya.Nastya.Configs;
using Nastya.Nastya.Configs.Mapper;
using Nastya.Nastya.Executors;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.Wordseqence;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.Wordseqence.Comparer;
using Nastya.Nastya.Log;
using Nastya.Nastya.Messenger;
using Nastya.Nastya.Messenger.UserId;

namespace Nastya
{
    static class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(CreateSampleConfig());

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
            var cfg = new Config
            {
                VkToken = "vkToken"
            };

            var comparer = new WordsComparer(0.525);
            var commands = new List<NastyaCommand>();

            var help = new HelpCommand
            {
                CommandName = "HelpCommand",
                HelpString = "somehelpstring",
                Priority = 1,
                Type = CommandType.Info,
                Sequences = new List<WordSequence>()
                {
                    new WordSequence(
                        comparer,
                        SequenceType.Disordered,
                        new String[]
                        {
                            "помоги"
                        } )
                }
            };


            commands.Add(help);



            ChitChatCommand chat = new ChitChatCommand();
            chat.CommandName = "ChitChatCommand";
            chat.Priority = 0;
            chat.Responses = new string[] { "норм", "неплохо", "кек", "лол" };
            chat.Type = CommandType.Dialog;
            //commands.Add(chat);

            HelloCommand hi = new HelloCommand();
            hi.CommandName = "HelloCommand";
            hi.Priority = 2;
            hi.Type = CommandType.Dialog;
            hi.Responses = new string[] { "утро", "доброе утро" };
            hi.Sequences = new List<WordSequence>()
                    {
                        new WordSequence(comparer, SequenceType.Disordered, new String[] { "доброе", "утро" }),
                        new WordSequence(comparer, SequenceType.Disordered, new String[] { "привет"})
                    };
            //commands.Add(hi);

            ByeCommand bye = new ByeCommand();
            bye.CommandName = "ByeCommand";
            bye.Priority = 2;
            bye.Type = CommandType.Dialog;
            bye.Responses = new string[] { "пока", "спокойной ночи", "сладких" };
            bye.Sequences = new List<WordSequence>()
                    {
                        new WordSequence(comparer, SequenceType.Ordered, new String[] { "спокойной", "ночи" }),
                        new WordSequence(comparer, SequenceType.Disordered, new String[] { "пока"})
                    };
            //commands.Add(bye);

            ByeCommand rudeBye = new ByeCommand();
            rudeBye.CommandName = "RudeByeCommand";
            rudeBye.Priority = 2;
            rudeBye.Type = CommandType.Dialog;
            rudeBye.Responses = new string[] { "уебывай", "иди нахуй", "съеби" };
            rudeBye.Sequences = new List<WordSequence>()
                    {
                        new WordSequence(comparer, SequenceType.Disordered, new String[] { "иди", "нахуй" }),
                         new WordSequence(comparer, SequenceType.Disordered, new String[] { "иди", "на","хуй" })
                    };
            //commands.Add(rudeBye);

            cfg.Commands = commands.ToArray();
            return XMLSerializer.GetXmlFromConfig(cfg);
        }

    }
}
