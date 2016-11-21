using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimWorld_ModsOrganizer
{
    public class RimMod
    {
        public ModType Type;
        public ModMetaData Meta;
        public int SteamPublishedFileId;
    }

    public enum ModType
    {
        Local,
        Steam
    }
}
