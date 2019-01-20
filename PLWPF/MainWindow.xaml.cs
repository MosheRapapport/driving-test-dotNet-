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
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();

        public MainWindow()
        {
            InitializeComponent();
            SetVisibiltyHidden();
        }
        private void SetVisibiltyHidden()
        {
            video.Visibility = Visibility.Hidden;
            video.LoadedBehavior = MediaState.Pause;
            add.Visibility = Visibility.Hidden;
            log_in.Visibility = Visibility.Hidden;
            log_in.update_tester.Visibility = Visibility.Hidden;
            log_in.update_trainee.Visibility= Visibility.Hidden;
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
            video.Visibility = Visibility.Visible;
            video.LoadedBehavior = MediaState.Play;
            string a = "";
            foreach (Person item in bl.GetAllPersons())
            {
                if (item is Trainee)
                    a += "\ntrainee:   ";
                if (item is Tester)
                    a += "\ntester:    ";
                a += item.Name.ToString() +" "+item.ID.ToString();
            }
            a += "\n\n TESTS:\n";
            foreach (Test item in bl.GetTests())
            {
                a +=item.codeOfTest+ " Tester id: " + item.Tester_ID + " Trainee id " + item.Trainee_ID+item.Date+"\n";
            }
            MessageBox.Show(a);
            
        }
      
       
       
      
        
    }
}
