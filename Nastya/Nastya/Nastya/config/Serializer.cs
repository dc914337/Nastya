using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.config.mapper;
using Nastya.Nastya.executor;
using Nastya.Nastya.executor.commands;

namespace Nastya.Nastya.config
{
    class Serializer
    {
        public static Config GetConfigFromString(String serialized)
        {
            return XMLSerializer.GetConfigFromXml(serialized);
        }
    }
}
