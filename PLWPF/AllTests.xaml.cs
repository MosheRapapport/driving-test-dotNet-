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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AllTests.xaml
    /// </summary>
    public partial class AllTests : UserControl
    {
        private IEnumerable source;

        public IEnumerable Source
        {
            get { return source; }
            set
            {
                source = value;
                this.listView.ItemsSource = source;
            }
        }
        public AllTests()
        {
            InitializeComponent();
        }
    }
}
