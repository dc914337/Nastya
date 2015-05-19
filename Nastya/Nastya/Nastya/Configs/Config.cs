using System;
using System.Collections.Generic;
using System.IO;
using Nastya.Nastya.Executors.Commands;

namespace Nastya.Nastya.Configs
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
