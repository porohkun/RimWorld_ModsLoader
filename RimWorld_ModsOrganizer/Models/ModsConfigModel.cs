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
    [XmlRoot("ModsConfigData")]
    public class ModsConfigModel
    {
        [XmlElement("buildNumber")]
        public int BuildNumber;

        [XmlArray("activeMods")]
        [XmlArrayItem("li")]
        public string[] ActiveMods;
    }
}
