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
    /// Interaction logic for log_in_control.xaml
    /// </summary>
    public partial class log_in_control : UserControl
    {
        public static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        public Person thePerson;
        public log_in_control()
        {
            InitializeComponent();
            SetVisibiltyHidden();
            thePerson = new Person();
        }

        private void ID_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            thePerson = ID_comboBox.SelectedItem as Person;
        }

        private void SetVisibiltyHidden()
        {
            update_trainee.Visibility = Visibility.Hidden;
            update_tester.Visibility = Visibility.Hidden;
        }

        private void Button_ok_Click(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            if (thePerson is Trainee)
            {
                update_trainee.DataContext = thePerson as Trainee;
                update_trainee.Visibility = Visibility.Visible;
               

            }
            if (thePerson is Tester)
            {
              update_tester.DataContext= thePerson as Tester;
              update_tester.Visibility = Visibility.Visible;
              
            }
            ID_comboBox.Text = "";
            ID_comboBox.IsEnabled = false;
            radioButton2.IsChecked = true;

            ///button_ok.IsEnabled = false;

        }

        private void RadioButton_trainee_Checked(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            ID_comboBox.IsEnabled = true;
            try
            {
              ID_comboBox.ItemsSource = bl.GetTrainees();
            
            }
            catch (Exception x)
            {
               
                MessageBox.Show(x.Message);
                radioButton2.IsChecked = true;
                ID_comboBox.ItemsSource = null;
            }
            
        }

        private void RadioButton_tester_Checked(object sender, RoutedEventArgs e)
        {
            SetVisibiltyHidden();
            ID_comboBox.IsEnabled = true;
            try
            {
                ID_comboBox.ItemsSource = bl.GetTesters();
              
            }
            catch (Exception x)
            {
                
                MessageBox.Show(x.Message);
                radioButton2.IsChecked = true;
                ID_comboBox.ItemsSource = null;
            }
        }
    }
}
