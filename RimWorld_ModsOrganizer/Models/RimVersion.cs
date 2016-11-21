using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RimWorld_ModsOrganizer
{
    public struct RimVersion : IXmlSerializable
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public int Build { get; private set; }
        public int Revision { get; private set; }

        public string Long { get { return string.Format("{0}.{1}.{2} rev{3}", Major, Minor, Build, Revision); } }
        public string Short { get { return string.Format("{0}.{1}.{2}", Major, Minor, Build); } }

        public RimVersion(int major, int minor, int build, int revision = 0)
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }

        public static implicit operator string(RimVersion value)
        {
            return value.ToString();
        }

        public static implicit operator RimVersion(string value)
        {
            var vs = value.Replace(" rev", ".").Split('.');
            if (vs.Length == 4)
                return new RimVersion(int.Parse(vs[0]), int.Parse(vs[1]), int.Parse(vs[2]), int.Parse(vs[3]));
            else
                return new RimVersion(int.Parse(vs[0]), int.Parse(vs[1]), int.Parse(vs[2]));
        }

        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            var value = reader.ReadElementContentAsString();
            var vs = value.Replace(" rev", ".").Split('.');
            Major = int.Parse(vs[0]);
            Minor = int.Parse(vs[1]);
            Build = int.Parse(vs[2]);
            Revision = vs.Length == 4 ? int.Parse(vs[3]) : 0;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(this);
        }

        public override string ToString()
        {
            if (Revision == 0)
                return Short;
            else
                return Long;
        }

    }
}
