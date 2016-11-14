using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.ComponentModel;

namespace RimWorld_ModsOrganizer
{
    /// <summary>
    /// Interaction logic for ModSetControl.xaml
    /// </summary>
    public partial class ModSetControl : BaseArrangableControl
    {

        #region INotifyPropertyChanged
        
        #endregion

        public ModSetControl()
        {
            InitializeComponent();
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            Focus();
        }

        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
