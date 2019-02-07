using System;
using System.Windows;
using BE;
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
            //sendMessage();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ERROR())
                return;
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

        private bool ERROR()
        {
            if (((Test)DataContext).Date.DayOfWeek == (DayOfWeek)6 || ((Test)DataContext).Date.DayOfWeek == (DayOfWeek)7)
            {
                MessageBox.Show("You can only select between Sunday and Thursday and between 9 and 14full hour", "ERROR");
                return false;
            }
            if (((Test)DataContext).Date.Hour < 9 || ((Test)DataContext).Date.Hour > 14)
            {
                MessageBox.Show("You can only select between Sunday and Thursday and between 9 and 14full hour", "ERROR");
                return false;
            }
            if (((Test)DataContext).Date.Minute != 0 && ((Test)DataContext).Date.Second != 0)
            {
                MessageBox.Show("You can only select between Sunday and Thursday and between 9 and 14full hour", "ERROR");
                return false;
            }
            return true;
        }
        //public void sendMessage()
        //{
        //    var client = new Client("test", "000000");
        //    var link = client.SendMessage("Hello from TextMagic API", "+97542520196");
        //    if (link.Success)
        //    {
        //        MessageBox.Show("Message ID {0} has been successfully sent");
        //    }
        //    else
        //    {
        //        MessageBox.Show(link.ClientException.Message.ToString());
        //    }
        //}
    }
}
