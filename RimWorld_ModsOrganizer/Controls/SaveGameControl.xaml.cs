using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Globalization;

namespace RimWorld_ModsOrganizer
{
    /// <summary>
    /// Interaction logic for SaveGameControl.xaml
    /// </summary>
    public partial class SaveGameControl : UserControl
    {
        public SavegameModel Save { get; private set; }

        public SaveGameControl()
        {
            InitializeComponent();
        }

        public SaveGameControl(string filename) : this()
        {
            Save = SerializationTool.DeserializeXml<SavegameModel>(File.ReadAllText(filename));
            saveNameTB.Text = Path.GetFileNameWithoutExtension(filename);
            dateTB.Text = File.GetLastWriteTime(filename).ToString("g");
            versionTB.Text = Save.Meta.GameVersion.Short;
            foreach (var mod in Save.Meta.ModNames)
                tooltipPanel.Children.Add(new TextBlock() { Text = mod });
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
