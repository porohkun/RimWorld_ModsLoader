using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace RimWorld_ModsOrganizer
{
    public class Settings
    {
        private static Settings _instance;
        private static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (File.Exists(SettingsFilePath))
                        try
                        {
                            _instance = SerializationTool.DeserializeXml<Settings>(File.ReadAllText(SettingsFilePath));
                        }
                        catch { }

                    if (_instance == null)
                        _instance = new Settings();
                }
                return _instance;
            }
        }

        [XmlElement("SteamPath")]
        public string _steamPath;

        public static string RuntimePath { get { return AppDomain.CurrentDomain.BaseDirectory; } }
        public static string SettingsFilePath { get { return Path.Combine(RuntimePath, "settings.xml"); } }
        public static string RimAppDataPath { get { return Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)), "LocalLow", "Ludeon Studios", "RimWorld"); } }
        public static string RimConfigPath { get { return Path.Combine(RimAppDataPath, "Config"); } }
        public static string RimSavesPath { get { return Path.Combine(RimAppDataPath, "Saves"); } }
        public static string RimModsConfigPath { get { return Path.Combine(RimConfigPath, "ModsConfig.xml"); } }

        public static string SteamPath
        {
            get { return Instance._steamPath; }
            set { Instance._steamPath = value; }
        }

        public static string RimPath { get { return Path.Combine(SteamPath, "SteamApps", "common", "RimWorld", "RimWorldWin.exe"); } }
        public static string RimVersionPath { get { return Path.Combine(SteamPath, "SteamApps", "common", "RimWorld", "Version.txt"); } }
        public static string SteamModsPath { get { return Path.Combine(SteamPath, "SteamApps", "workshop", "content", "294100"); } }

        public static void Save()
        {
            File.WriteAllText(SettingsFilePath, SerializationTool.SerializeXml<Settings>(Instance));
        }
    }
}
