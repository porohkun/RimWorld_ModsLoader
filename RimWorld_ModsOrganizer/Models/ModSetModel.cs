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
    [XmlRoot("modset")]
    public class ModSetModel
    {
        [XmlElement("name")]
        public string Name;

        [XmlArray("mods")]
        [XmlArrayItem("li")]
        public List<string> Mods;
    }
}
