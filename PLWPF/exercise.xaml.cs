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
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for exercise.xaml
    /// </summary>
    public partial class exercise : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        public exercise()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var v = bl.GetTests();
            foreach (var item in v)
            {
                this.AddChild(item);
            }
        }

      
    }
}
