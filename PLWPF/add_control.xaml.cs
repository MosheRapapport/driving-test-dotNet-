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
using BE;
using BL;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for add_control.xaml
    /// </summary>
    public partial class add_control : UserControl
    {
        public add_control()
        {
            InitializeComponent();
        }

        private void Add_trainee_button_Click(object sender, RoutedEventArgs e)
        {
            add_trainee_Window add_Trainee_Window = new add_trainee_Window();
            add_Trainee_Window.Show();
        }

        private void add_tester_button_Click(object sender, RoutedEventArgs e)
        {
            add_tester_Window add_tester_Window = new add_tester_Window();
            add_tester_Window.Show();
        }
    }
}
