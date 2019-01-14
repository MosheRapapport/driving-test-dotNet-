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
    /// Interaction logic for add_tester_Window.xaml
    /// </summary>
    public partial class add_tester_Window : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        Tester newTester;
        public add_tester_Window()
        {
            InitializeComponent();
            newTester = new Tester { Address = new Address(), Expertise = new CarType(), Name = new Name(), Luz=new Schedule() };
            this.DataContext = newTester;
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.carType));
            this.gearTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearType));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ischeck();
            try
            {
                bl.AddTester(newTester);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
        private void ischeck()
        {

            //Sunday 
            newTester.Luz.data[0][0] = (bool)s0.IsChecked;
            newTester.Luz.data[0][1] = (bool)s1.IsChecked;
            newTester.Luz.data[0][2] = (bool)s2.IsChecked;
            newTester.Luz.data[0][3] = (bool)s3.IsChecked;
            newTester.Luz.data[0][4] = (bool)s4.IsChecked;
            newTester.Luz.data[0][5] = (bool)s5.IsChecked;
            //Monday 
            newTester.Luz.data[1][0] = (bool)m0.IsChecked;
            newTester.Luz.data[1][1] = (bool)m1.IsChecked;
            newTester.Luz.data[1][2] = (bool)m2.IsChecked;
            newTester.Luz.data[1][3] = (bool)m3.IsChecked;
            newTester.Luz.data[1][4] = (bool)m4.IsChecked;
            newTester.Luz.data[1][5] = (bool)m5.IsChecked;
            //Tuesday 
            newTester.Luz.data[2][0] = (bool)w0.IsChecked;
            newTester.Luz.data[2][1] = (bool)w1.IsChecked;
            newTester.Luz.data[2][2] = (bool)w2.IsChecked;
            newTester.Luz.data[2][3] = (bool)w3.IsChecked;
            newTester.Luz.data[2][4] = (bool)w4.IsChecked;
            newTester.Luz.data[2][5] = (bool)w5.IsChecked;
            //Wednesday 
            newTester.Luz.data[3][0] = (bool)t0.IsChecked;
            newTester.Luz.data[3][1] = (bool)t1.IsChecked;
            newTester.Luz.data[3][2] = (bool)t2.IsChecked;
            newTester.Luz.data[3][3] = (bool)t3.IsChecked;
            newTester.Luz.data[3][4] = (bool)t4.IsChecked;
            newTester.Luz.data[3][5] = (bool)t5.IsChecked;
            //Thursday
            newTester.Luz.data[4][0] = (bool)h0.IsChecked;
            newTester.Luz.data[4][1] = (bool)h1.IsChecked;
            newTester.Luz.data[4][2] = (bool)h2.IsChecked;
            newTester.Luz.data[4][3] = (bool)h3.IsChecked;
            newTester.Luz.data[4][4] = (bool)h4.IsChecked;
            newTester.Luz.data[4][5] = (bool)h5.IsChecked;
        }
    }
}
