using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

namespace RimWorld_ModsOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateData();
        }

        public class FileWithDate
        {
            public string Filename;
            public DateTime LastEdited;
        }

        private void UpdateData()
        {
            UpdateSaves();
        }

        void UpdateSaves()
        {
            List<FileWithDate> files = new List<FileWithDate>();
            files.AddRange(Directory.GetFiles(Settings.RimSavesPath, "*.rws", SearchOption.TopDirectoryOnly)
                .Select(f => new FileWithDate()
                {
                    Filename = f,
                    LastEdited = File.GetLastWriteTime(f)
                }));

            foreach (var file in from f in files orderby f.LastEdited descending select f.Filename)
            {
                savesBox.Items.Add(new SaveGameControl(file));
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            //MessageBox.Show(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)));
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            var settings = new SettingsWindow();
            settings.ShowDialog();
            //MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Settings.RimPath))
            {
                RimVersion version = File.ReadAllText(Settings.RimVersionPath);
                var save = savesBox.SelectedItem as SaveGameControl;
                var modsConfig = new ModsConfigModel()
                {
                    BuildNumber = version.Build,
                    ActiveMods = save.Save.Meta.ModIds
                };
                File.WriteAllText(Settings.RimModsConfigPath, SerializationTool.SerializeXml(modsConfig));
                //Process.Start(Settings.RimPath);
            }
            else
                MessageBox.Show("Set Steam path in settings for run game");
        }
        
        private void AddSet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var editModSet = new EditModSetWindow();
                editModSet.ShowDialog();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
