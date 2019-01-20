using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for add_trainee_Window.xaml
    /// </summary>
    public partial class add_trainee_Window : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        Trainee trainee;
        public add_trainee_Window()
        {
            InitializeComponent();
            trainee = new Trainee {DayOfBirth= new DateTime(2000,1,1), Address=new Address(), CarTrained=new CarType(), Name=new Name(),Instructor=new Name() };
            this.DataContext = trainee;

            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.carType));
            this.gearTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearType));

        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddTrainee(trainee);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);

            }
            Close();
        }
        private void iDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (iDTextBox.Text.Length != 9 || !Regex.IsMatch(iDTextBox.Text, @"^[0-9]+$"))
            {
                iDTextBox.Foreground = Brushes.Red;
                iDTextBox.Text = "The id must be 9 digits";
            }
        }

        private void idTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            iDTextBox.Text = null;
            iDTextBox.Foreground = Brushes.Black;

        }

    }
}
