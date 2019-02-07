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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        public GroupWindow()
        {
            InitializeComponent();
        }

        private void GetTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                setVisibility();
                this.All_tests.Visibility = Visibility.Visible;
                AllTests uc = new AllTests();
               uc.Source = bl.GetTests();
                this.page.Content = uc;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }

        private void TestersExpertise_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                setVisibility();
                this.All_testers_by_expertise.Visibility = Visibility.Visible;
                AllTasters uc = new AllTasters() { Source = bl.GetTesters() };
                //uc.Source = bl.GetTesters();
                this.page.Content = uc;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }

        private void traineesByNumOfTests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                setVisibility();
                this.All_trainees.Visibility = Visibility.Visible;
                AllTrainees uc = new AllTrainees();
                uc.Source = bl.GetTrainees();
            //    uc.Source = bl.traineesByNumOfTests();
                this.page.Content = uc;

            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }
        public void setVisibility()
        {
            this.All_testers_by_expertise.Visibility = Visibility.Hidden;
            this.All_tests.Visibility = Visibility.Hidden;
            this.All_trainees.Visibility = Visibility.Hidden;
        }
    }
}
