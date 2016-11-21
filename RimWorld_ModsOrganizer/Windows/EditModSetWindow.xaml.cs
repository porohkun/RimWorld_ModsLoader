using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RimWorld_ModsOrganizer
{
    /// <summary>
    /// Interaction logic for EditModSetWindow.xaml
    /// </summary>
    public partial class EditModSetWindow : Window
    {
        ObservableCollection<ModControl> _modControls = new ObservableCollection<ModControl>();

        public EditModSetWindow()
        {
            InitializeComponent();
            UpdateModsList();
        }

        private void UpdateModsList()
        {
            if (steamModsButton.IsChecked.Value)
            {
                foreach (var dir in Directory.GetDirectories(Settings.SteamModsPath, "*", SearchOption.TopDirectoryOnly))
                {
                    var path = Path.Combine(dir, "About", "About.xml");
                    if (File.Exists(path))
                    {
                        ModMetaData meta = SerializationTool.DeserializeXml<ModMetaData>(File.ReadAllText(path));
                        ModControl cont = new ModControl(meta);
                        cont.MouseLeftButtonDown += Cont_MouseLeftButtonDown;
                        modsPanel.Children.Add(cont);
                    }
                }
            }
        }

        private void Cont_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModControl cont = (ModControl)sender;
            modName.Text = cont.Meta.Name;
            modAuthor.Text = cont.Meta.Author;
            modVersion.Text = "Required version: " + cont.Meta.TargetVersion.Short;
            modLink.Text = cont.Meta.Url;
            modDesctiption.Text = cont.Meta.Description;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void modWorkshop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
