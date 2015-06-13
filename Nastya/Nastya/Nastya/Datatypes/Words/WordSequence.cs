﻿using System;
using System.Collections.Generic;
using System.Linq;
using Nastya.Nastya.Datatypes.Words.Comparer;

namespace Nastya.Nastya.Datatypes.Words
{
    public class WordSequence
    {
        public String[] Sequence { get; set; }
        public SequenceType Type { get; set; }
        public WordsComparer Comparer { get; set; }


        public WordSequence()
        {
            //for xml serializer
        }

        public WordSequence(WordsComparer comparer)
        {
            Comparer = comparer;
        }

        public WordSequence(WordsComparer comparer, SequenceType type, String[] sequence)
        {
            Comparer = comparer;
            Type = type;
            Sequence = sequence;
        }

        public bool InSequence(IEnumerable<string> inputSeq)
        {
            switch (Type)
            {
                case SequenceType.Unordered:
                    return ChechUnorderedSequence(inputSeq);
                case SequenceType.Ordered:
                    return ChechOrderedSequence(inputSeq);
                default:
                    return false;
            }
        }



        private bool ChechUnorderedSequence(IEnumerable<string> inputSeq)
        {
            return Sequence.All(word => inputSeq.FirstOrDefault(inputWord => Comparer.Equal(word, inputWord)) != null);
        }

        private bool ChechOrderedSequence(IEnumerable<string> inputSeq)
        {
            var pointer = 0;

            var seqWord = Sequence[pointer];
            var success = false;

            foreach (var inputWord in inputSeq)
            {
                if (!Comparer.Equal(inputWord, seqWord)) continue;

                pointer++;
                if (pointer < Sequence.Length)
                    seqWord = Sequence[pointer];
                else
                {
                    success = true;
                    break;
                }
            }

            return success;
        }


    }
}
