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
using Test1.ViewModels;

namespace Test1.Views
{
    /// <summary>
    /// Interaction logic for OrdersListView.xaml
    /// </summary>
    public partial class OrdersListView : UserControl
    {
        public OrdersListView()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }

        private void ComboBox_Initialized(object sender, EventArgs e)
        {

        }
    }
}
