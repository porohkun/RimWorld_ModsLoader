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

namespace RimWorld_ModsOrganizer
{
    /// <summary>
    /// Interaction logic for ModControl.xaml
    /// </summary>
    public partial class ModControl : UserControl
    {
        public ModMetaData Meta;

        public ModControl()
        {
            InitializeComponent();
        }

        public ModControl(ModMetaData meta):this()
        {
            this.Meta = meta;
            modNameTB.Text = meta.Name;
        }
    }
}
