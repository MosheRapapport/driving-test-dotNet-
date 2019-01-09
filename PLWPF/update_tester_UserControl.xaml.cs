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

                MessageBox.Show(ex.ToString());
            }
             
        }

        private void update_tester_button_Click(object sender, RoutedEventArgs e)
        {
            update_tester_Window window = new update_tester_Window();
            window.DataContext = this.DataContext;
            window.Luz_user_control.DataContext= this.DataContext;
            window.Show();
        }
    }
}
