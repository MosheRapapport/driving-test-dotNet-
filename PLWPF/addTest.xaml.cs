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
    /// Interaction logic for addTest.xaml
    /// </summary>
    public partial class addTest : Window
    {
        public static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        public addTest()
        {
            InitializeComponent();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((Test)DataContext).Date = ((Test)DataContext).Date.AddHours(9);
                

                bl.AddDrivingTest(((Test)DataContext));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource timePickerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("timePickerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // timePickerViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource cardClipConverterViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cardClipConverterViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // cardClipConverterViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource cardViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cardViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // cardViewSource.Source = [generic data source]
        }
    }
}
