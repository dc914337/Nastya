﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Executors.Commands;
using Nastya.Nastya.Executors.ContextContainers.Contexts.Day.Schedules.Events;

namespace Nastya.Nastya.Executors.ContextContainers.Contexts
{
    public class AnswerContext : BaseContext
    {
        public QuestionEvent AskedQuestion { get; set; }
    }
}
