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


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for update_tester_Window.xaml
    /// </summary>
    public partial class update_tester_Window : Window
    {
        public update_tester_Window()
        {
            InitializeComponent();
            this.DataContext = (Tester)log_in_control.thePerson;
        }

        
    }
}
