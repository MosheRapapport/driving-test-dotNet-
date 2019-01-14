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
    /// Interaction logic for update_tester_Window.xaml
    /// </summary>
    public partial class update_tester_Window : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
    
        public update_tester_Window()
        {
            InitializeComponent();
            
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.carType));
            this.gearTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearType));
            
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ischeck();
            try
            {
                  bl.UpdateTester((Tester)DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Close();       
        }


        private void ischeck()
        {

            ((Tester)DataContext).Luz.data[0][0] = (bool)s0.IsChecked;
            ((Tester)DataContext).Luz.data[0][1] = (bool)s1.IsChecked;
            ((Tester)DataContext).Luz.data[0][2] = (bool)s2.IsChecked;
            ((Tester)DataContext).Luz.data[0][3] = (bool)s3.IsChecked;
            ((Tester)DataContext).Luz.data[0][4] = (bool)s4.IsChecked;
            ((Tester)DataContext).Luz.data[0][5] = (bool)s5.IsChecked;
                                                  
            ((Tester)DataContext).Luz.data[1][0] = (bool)m0.IsChecked;
            ((Tester)DataContext).Luz.data[1][1] = (bool)m1.IsChecked;
            ((Tester)DataContext).Luz.data[1][2] = (bool)m2.IsChecked;
            ((Tester)DataContext).Luz.data[1][3] = (bool)m3.IsChecked;
            ((Tester)DataContext).Luz.data[1][4] = (bool)m4.IsChecked;
            ((Tester)DataContext).Luz.data[1][5] = (bool)m5.IsChecked;
                                                 
            ((Tester)DataContext).Luz.data[2][0] = (bool)w0.IsChecked;
            ((Tester)DataContext).Luz.data[2][1] = (bool)w1.IsChecked;
            ((Tester)DataContext).Luz.data[2][2] = (bool)w2.IsChecked;
            ((Tester)DataContext).Luz.data[2][3] = (bool)w3.IsChecked;
            ((Tester)DataContext).Luz.data[2][4] = (bool)w4.IsChecked;
            ((Tester)DataContext).Luz.data[2][5] = (bool)w5.IsChecked;
                                                  
            ((Tester)DataContext).Luz.data[3][0] = (bool)t0.IsChecked;
            ((Tester)DataContext).Luz.data[3][1] = (bool)t1.IsChecked;
            ((Tester)DataContext).Luz.data[3][2] = (bool)t2.IsChecked;
            ((Tester)DataContext).Luz.data[3][3] = (bool)t3.IsChecked;
            ((Tester)DataContext).Luz.data[3][4] = (bool)t4.IsChecked;
            ((Tester)DataContext).Luz.data[3][5] = (bool)t5.IsChecked;
                                                 
            ((Tester)DataContext).Luz.data[4][0] = (bool)h0.IsChecked;
            ((Tester)DataContext).Luz.data[4][1] = (bool)h1.IsChecked;
            ((Tester)DataContext).Luz.data[4][2] = (bool)h2.IsChecked;
            ((Tester)DataContext).Luz.data[4][3] = (bool)h3.IsChecked;
            ((Tester)DataContext).Luz.data[4][4] = (bool)h4.IsChecked;
            ((Tester)DataContext).Luz.data[4][5] = (bool)h5.IsChecked;
        }

    }
}
