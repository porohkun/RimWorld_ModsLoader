using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace RimWorld_ModsOrganizer
{
    [XmlRoot("ModMetaData")]
    public class ModMetaData
    {
        [XmlElement("name")]
        public string Name;

        [XmlElement("targetVersion")]
        public RimVersion TargetVersion;

        [XmlElement("author")]
        public string Author;

        [XmlElement("url")]
        public string Url;

        [XmlElement("description")]
        public string Description;
    }
}
