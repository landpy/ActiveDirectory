using System.Collections.Generic;
using System.Xml;

namespace Landpy.TestFramwork.Configuration
{
    public class TF
    {
        private readonly string filename;
        private Dictionary<string, string> properties;
        private static TF configuration;
        private static readonly object LockOject = new object();

        public Dictionary<string, string> Properties
        {
            get
            {
                if (this.properties == null)
                {
                    this.properties = new Dictionary<string, string>();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(this.filename);
                    if (xmlDocument.DocumentElement != null)
                        foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
                        {
                            if (xmlNode.NodeType == XmlNodeType.Element && xmlNode.Name == "Properties")
                            {
                                foreach (XmlNode propertyXmlNode in xmlNode.ChildNodes)
                                {
                                    if (propertyXmlNode.NodeType == XmlNodeType.Element && propertyXmlNode.Name == "Property")
                                    {
                                        if (propertyXmlNode.Attributes != null)
                                        {
                                            string attributeKey = propertyXmlNode.Attributes["Key"].Value;
                                            string attributeValue = propertyXmlNode.Attributes["Value"].Value;
                                            if (this.properties.ContainsKey(attributeKey))
                                            {
                                                throw new KeyReduplicateException();
                                            }
                                            else
                                            {
                                                this.properties.Add(attributeKey, attributeValue);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                }
                return this.properties;
            }
        }

        private TF()
        {
            this.filename = "TestFramework.tfconfig.xml";
        }

        public static TF GetConfig()
        {
            lock (LockOject)
            {
                if (configuration == null)
                {
                    lock (LockOject)
                    {
                        configuration = new TF();
                    }
                }
            }
            return configuration;
        }
    }
}
