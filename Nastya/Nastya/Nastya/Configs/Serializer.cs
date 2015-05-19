using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.Configs.Mapper;

namespace Nastya.Nastya.Configs
{
    class Serializer
    {
        public static Config GetConfigFromString(String serialized)
        {
            return XMLSerializer.GetConfigFromXml(serialized);
        }
    }
}
