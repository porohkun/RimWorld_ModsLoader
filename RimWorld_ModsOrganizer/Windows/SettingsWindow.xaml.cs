using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.ComponentModel;

namespace RimWorld_ModsOrganizer
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            steamTextBox.Text = Settings.SteamPath;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Save();
            base.OnClosing(e);
        }

        private void SteamPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "steam.dll|steam.dll" };

            if (openFileDialog.ShowDialog() == true)
                steamTextBox.Text = Path.GetDirectoryName(openFileDialog.FileName);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Settings.SteamPath = steamTextBox.Text;

            Close();
        }

    }
}
