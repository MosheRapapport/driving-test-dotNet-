﻿using System;
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
    /// Interaction logic for update_tester_Window.xaml
    /// </summary>
    public partial class update_tester_Window : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
     //   Tester myTester;
        public update_tester_Window()
        {
            InitializeComponent();
            
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.carType));
            this.gearTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearType));
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                  bl.UpdateTester((Tester)DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Close();       
        }

       

        
    }
}
