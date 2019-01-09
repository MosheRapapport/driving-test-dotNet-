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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Luz_UserControl1.xaml
    /// </summary>
    public partial class Luz_UserControl1 : UserControl
    {
        Tester myTester;
        public Luz_UserControl1()
        {
            InitializeComponent();
            this.comboBox_days.ItemsSource = Enum.GetValues(typeof (BE.Day));

            myTester = new Tester();
            this.DataContext = myTester;
        }
    }
}
