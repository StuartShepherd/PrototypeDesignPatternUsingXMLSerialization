using System;
using System.IO;
using System.Xml.Serialization;

namespace PrototypeUsingXMLSerialization.Prototype
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo()
        {
        }

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            using (var memoryStream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(memoryStream, self);
                memoryStream.Position = 0;
                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }
    }
}