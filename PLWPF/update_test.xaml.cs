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
    /// Interaction logic for update_test.xaml
    /// </summary>
    public partial class update_test : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        Test theTest;
        public update_test()
        {
            InitializeComponent();
            theTest=new Test();
        }

        private void select_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            theTest = select.SelectedItem as Test;
            update_Test_use.DataContext = theTest as Test;
            update_Test_use.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.UpdateDrivingTest(theTest);
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

     
    }

      
}
