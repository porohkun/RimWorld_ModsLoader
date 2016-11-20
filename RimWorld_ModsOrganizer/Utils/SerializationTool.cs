
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RimWorld_ModsOrganizer
{
    public static class SerializationTool
    {
        public sealed class StringWriterWithEncoding : System.IO.StringWriter
        {
            private readonly System.Text.Encoding encoding;

            public StringWriterWithEncoding(System.Text.StringBuilder sb) : base(sb)
            {
                this.encoding = System.Text.Encoding.Unicode;
            }


            public StringWriterWithEncoding(System.Text.Encoding encoding)
            {
                this.encoding = encoding;
            }

            public StringWriterWithEncoding(System.Text.StringBuilder sb, System.Text.Encoding encoding) : base(sb)
            {
                this.encoding = encoding;
            }

            public override System.Text.Encoding Encoding
            {
                get { return encoding; }
            }
        }

        private static Dictionary<Type, XmlSerializer> _serializers = new Dictionary<Type, XmlSerializer>();

        public static string SerializeXml<T>(T obj, string rootRename = null, bool toFile = false)
        {
            if (typeof(T) == typeof(String))
                return obj != null ? obj.ToString() : "";
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                CloseOutput = false,
                Encoding = Encoding.UTF8,
                //NamespaceHandling = NamespaceHandling.OmitDuplicates
            };

            var x = new XmlSerializer(typeof(T), rootRename == null ? null : new XmlRootAttribute(rootRename) { Namespace = "" });

            using (var stream = new StringWriterWithEncoding(settings.Encoding))
            {
                using (var writer = XmlTextWriter.Create(stream, settings))
                //using (var writer = new XmlTextWriter(stream., settings.Encoding))
                {
                    x.Serialize(writer, obj, emptyNamepsaces);
                    return stream.ToString();
                }
            }
        }

        public static T DeserializeXml<T>(string serData)
        {
            var x = new XmlSerializer(typeof(T), "");
            using (var sreader = new StringReader(serData))
            {
                using (var reader = XmlReader.Create(sreader))
                {
                    return (T)x.Deserialize(reader);
                }
            }
        }

    }
}
