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
    [XmlRoot("savegame")]
    public class SavegameModel
    {
        [XmlElement("meta")]
        public SM_Meta Meta;

        public class SM_Meta
        {
            [XmlElement("gameVersion")]
            public RimVersion GameVersion;

            [XmlArray("modIds")]
            [XmlArrayItem("li")]
            public string[] ModIds;

            [XmlArray("modNames")]
            [XmlArrayItem("li")]
            public string[] ModNames;
        }

    }
}
