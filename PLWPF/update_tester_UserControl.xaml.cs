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
    /// Interaction logic for update_tester_UserControl.xaml
    /// </summary>
    public partial class update_tester_UserControl : UserControl
    {
        public static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        public update_tester_UserControl()
        {
            InitializeComponent();
        }
       

        private void remove_tester_button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("r u shure");
            try
            {
                
                bl.RemoveTester((Tester)DataContext);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
             
        }

        private void update_tester_button_Click(object sender, RoutedEventArgs e)
        {
            update_tester_Window window = new update_tester_Window();
            window.DataContext = this.DataContext;
       
            ischeck(window);
            window.Show();
        }

        private void ischeck(update_tester_Window window)
        {

            
            window.s0.IsChecked = ((Tester)DataContext).Luz.data[0][0];
            window.s1.IsChecked = ((Tester)DataContext).Luz.data[0][1];
            window.s2.IsChecked = ((Tester)DataContext).Luz.data[0][2];
            window.s3.IsChecked = ((Tester)DataContext).Luz.data[0][3];
            window.s4.IsChecked = ((Tester)DataContext).Luz.data[0][4];
            window.s5.IsChecked = ((Tester)DataContext).Luz.data[0][5];

            window.m0.IsChecked = ((Tester)DataContext).Luz.data[1][0];
            window.m1.IsChecked = ((Tester)DataContext).Luz.data[1][1];
            window.m2.IsChecked = ((Tester)DataContext).Luz.data[1][2];
            window.m3.IsChecked = ((Tester)DataContext).Luz.data[1][3];
            window.m4.IsChecked = ((Tester)DataContext).Luz.data[1][4];
            window.m5.IsChecked = ((Tester)DataContext).Luz.data[1][5];

            window.w0.IsChecked = ((Tester)DataContext).Luz.data[2][0];
            window.w1.IsChecked = ((Tester)DataContext).Luz.data[2][1];
            window.w2.IsChecked = ((Tester)DataContext).Luz.data[2][2];
            window.w3.IsChecked = ((Tester)DataContext).Luz.data[2][3];
            window.w4.IsChecked = ((Tester)DataContext).Luz.data[2][4];
            window.w5.IsChecked = ((Tester)DataContext).Luz.data[2][5];

            window.t0.IsChecked = ((Tester)DataContext).Luz.data[3][0];
            window.t1.IsChecked = ((Tester)DataContext).Luz.data[3][1];
            window.t2.IsChecked = ((Tester)DataContext).Luz.data[3][2];
            window.t3.IsChecked = ((Tester)DataContext).Luz.data[3][3];
            window.t4.IsChecked = ((Tester)DataContext).Luz.data[3][4];
            window.t5.IsChecked = ((Tester)DataContext).Luz.data[3][5];

            window.h0.IsChecked = ((Tester)DataContext).Luz.data[4][0];
            window.h1.IsChecked = ((Tester)DataContext).Luz.data[4][1];
            window.h2.IsChecked = ((Tester)DataContext).Luz.data[4][2];
            window.h3.IsChecked = ((Tester)DataContext).Luz.data[4][3];
            window.h4.IsChecked = ((Tester)DataContext).Luz.data[4][4];
            window.h5.IsChecked = ((Tester)DataContext).Luz.data[4][5];
        }

        private void update_test_button_Click(object sender, RoutedEventArgs e)
        {
            update_test window = new update_test();
            window.select.ItemsSource = bl.condition(test => ((Tester)DataContext).ID == test.Tester_ID);

            window.DataContext = this.DataContext;
            window.Show();

        }
    }
}
