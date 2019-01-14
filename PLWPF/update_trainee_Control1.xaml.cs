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
    /// Interaction logic for update_trainee_Control1.xaml
    /// </summary>
    public partial class update_trainee_Control1 : UserControl
    {
        public static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        Trainee trainee;
        public update_trainee_Control1()
        {
            InitializeComponent();
        }

        private void remove_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("r u shure");
            try
            {
                bl.RemoveTrainee((Trainee)DataContext);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
       

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            update_trainee_Window window = new update_trainee_Window();
            window.DataContext = this.DataContext;
           
            window.Show();
        }

        private void add_test_button_Click(object sender, RoutedEventArgs e)
        {
            Test atest = new Test();
            trainee = (Trainee)this.DataContext;
            atest.Trainee_ID = trainee.ID;


            atest.Date = DateTime.Today;
            atest.Date = atest.Date.AddHours(9);
            addTest window = new addTest();
            window.DataContext = atest;

            window.Show();

        }
    }
}
