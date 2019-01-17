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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for addTest.xaml
    /// </summary>
    public partial class addTest : Window
    {
        public static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        Test test;
        public addTest()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test =((Test)DataContext);
            gif.Visibility = Visibility.Visible;
            new Thread(() =>
            
          {
              try
              {
                       
                       bl.AddDrivingTest(test);
                       
                       MessageBox.Show(test.ToString(), "Your test:");
                      
              }
               catch (Exception m)
               {
                 // gif.Visibility = Visibility.Hidden;
                  MessageBox.Show(m.Message);
               }
              Dispatcher.Invoke(new Action(() =>
              {
                  try
                  {
                      gif.Visibility = Visibility.Hidden;
                      Close();
                  }
                  catch (Exception n)
                  {
                      MessageBox.Show(n.Message);
                  }
              }));
              
          }).Start();
          
           
        }
    }
}
