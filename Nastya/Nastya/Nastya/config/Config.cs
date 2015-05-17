using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nastya.Nastya.executor;
using Nastya.Nastya.executor.commands;

namespace Nastya.Nastya.config
{
    public class Config
    {
        private String Path { get; set; }

        public NastyaCommand[] Commands { get; set; }
        public String VkToken { get; set; }

        public static Config GetFromFile(String path)
        {
            StreamReader sr = new StreamReader(path);
            String strConfig = sr.ReadToEnd();
            sr.Close();
            var config = Serializer.GetConfigFromString(strConfig);
            config.Path = path;
            return config;
        }


    }
}
