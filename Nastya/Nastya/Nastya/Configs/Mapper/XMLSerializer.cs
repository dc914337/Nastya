using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Nastya.Nastya.Configs.Mapper
{
    class XMLSerializer
    {
        public static Config GetConfigFromXml(string serialized)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));
            
            var cfg = (Config)xs.Deserialize(ReadStreamFromString(serialized));
            return cfg;
        }

        public static string GetXmlFromConfig(Config cfg)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Config));

            MemoryStream memStream = new MemoryStream();
            xs.Serialize(memStream, cfg);

            return ReadStreamToString(memStream);
        }

        private static Stream ReadStreamFromString(string s)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(s);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
        }

        private static string ReadStreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
