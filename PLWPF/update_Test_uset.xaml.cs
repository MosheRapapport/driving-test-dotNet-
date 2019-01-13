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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for update_Test_uset.xaml
    /// </summary>
    public partial class update_Test_uset : UserControl
    {
        public static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        public update_Test_uset()
        {
            InitializeComponent();
        }

       
    }
}
