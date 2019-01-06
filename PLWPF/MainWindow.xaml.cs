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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetVisibiltyHidden();
        }
        private void SetVisibiltyHidden()
        {
            add.Visibility = Visibility.Hidden;
            log_in.Visibility = Visibility.Hidden;
        }
        private void New_user_butten_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            add.Visibility = Visibility.Visible;
        }

        private void Log_in_button_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            log_in.Visibility = Visibility.Visible;
            
        }

        private void Video_butten_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
        }
    }
}
