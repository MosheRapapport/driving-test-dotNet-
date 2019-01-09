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
    /// Interaction logic for add_tester_Window.xaml
    /// </summary>
    public partial class add_tester_Window : Window
    {
        private static BL.IBL bl = BL.FactorySingletonBL.getInstance();
        Tester newTester;
        public add_tester_Window()
        {
            InitializeComponent();
            newTester = new Tester { Address = new Address(), Expertise = new CarType(), Name = new Name(), Luz=new Schedule() };
            this.DataContext = newTester;
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.carTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.carType));
            this.gearTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearType));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddTester(newTester);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
    }
}
