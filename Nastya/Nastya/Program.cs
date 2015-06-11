using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Nastya.Nastya.Configs;
using Nastya.Nastya.Configs.Mapper;
using Nastya.Nastya.Datatypes.Words;
using Nastya.Nastya.Datatypes.Words.Comparer;
using Nastya.Nastya.Executors;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.Commands.AnswerCommands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands;
using Nastya.Nastya.Executors.Commands.WordSequenceCommands.DayCommands;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Tasks;
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

            var comparer = new WordsComparer(0.5);
            var commands = new List<NastyaCommand>();

            var help = new HelpCommand
            {
                CommandName = "HelpCommand",
                HelpString = "somehelpstring",
                Priority = 1,
                Type = CommandType.Info,
                WordSequences = new WordSequences()
                {
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
                }
            };


            var answerWakeUp = new AnswerCommand()
            {
                CommandName = "WakeUpAnswer",
                Priority = 1,
                Type = CommandType.Info,
                Question = new QuestionTask()
                {
                    DelayFromDayStartSecs = 200,
                    ExpirationTimeSecs = 2000,
                    Messages = new List<String>
                    {
                        "Вставай, пидар",
                        "Тебе следует встать",
                        "Ты уже встал?"
                    },
                    NevermindSentences = new List<string>
                    {
                         "Ну и лежи дальше блядь. Ты умрешь в одиночестве"
                    }
                }
                ,
                AcceptSequences = new WordSequences()
                {
                    Sequences = new List<WordSequence>()
                 {
                     new WordSequence(
                         comparer,
                         SequenceType.Ordered,
                         new String[]
                         {
                             "да",
                             "Встаю"
                         } )
                 }
                },
                RefuceSequences = new WordSequences()
                {
                    Sequences = new List<WordSequence>()
                 {
                     new WordSequence(
                         comparer,
                         SequenceType.Disordered,
                         new String[]
                         {
                             "проваливай"
                         }),
                         new WordSequence(
                         comparer,
                         SequenceType.Ordered,
                         new String[]
                         {
                             "не",
                             "встану"
                         })
                 }
                },
                SkipSequences = new WordSequences()
                {
                    Sequences = new List<WordSequence>()
                 {
                     new WordSequence(
                         comparer,
                         SequenceType.Disordered,
                         new String[]
                         {
                             "иди",
                             "нахуй"
                         } )
                 }
                }
            };


            commands.Add(answerWakeUp);


            /*
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
             hi.WordSequences = new List<WordSequence>()
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
             bye.WordSequences = new List<WordSequence>()
                     {
                         new WordSequence(comparer, SequenceType.Ordered, new String[] { "спокойной", "ночи" }),
                         new WordSequence(comparer, SequenceType.Disordered, new String[] { "пока"})
                     };
             //commands.Add(bye);

             ByeCommand rudeBye = new ByeCommand();
             rudeBye.CommandName = "RudeByeCommand";
             rudeBye.Priority = 2;
             rudeBye.Type = CommandType.Dialog;
             rudeBye.Responses = new string[] { "уебывай" };
             rudeBye.WordSequences = new List<WordSequence>()
                     {
                         new WordSequence(comparer, SequenceType.Disordered, new String[] { "иди", "нахуй" }),
                          new WordSequence(comparer, SequenceType.Disordered, new String[] { "иди", "на","хуй" })
                     };
             //commands.Add(rudeBye);
*/
            cfg.Commands = commands.ToArray();
            return XMLSerializer.GetXmlFromConfig(cfg);

        }

    }
}
