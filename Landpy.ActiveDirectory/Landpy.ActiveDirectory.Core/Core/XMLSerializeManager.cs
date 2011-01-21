using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Landpy.ActiveDirectory.Core
{
    static class XMLSerializeManager<T> where T : class
    {
        public static T GenerateInstatce(string serializedXml)
        {
            T instance = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(serializedXml);
            instance = xmlSerializer.Deserialize(reader) as T;
            return instance;
        }

        public static string GenerateSerializedXml(T instance)
        {
            string serializedXml = String.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringBuilder buffer = new StringBuilder();
            StringWriter writer = new StringWriter(buffer);
            xmlSerializer.Serialize(writer, instance);
            writer.Close();
            serializedXml = buffer.ToString();
            return serializedXml;
        }
    }
}
