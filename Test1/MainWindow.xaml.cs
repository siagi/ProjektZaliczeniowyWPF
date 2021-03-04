using System;
using System.Collections.Generic;
using System.Globalization;
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
using Test1.Models;
using Test1.ViewModels;

namespace Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ProductViewModel productViewModel;
        //CustomerViewModel customerViewModel;
        //OrderViewModel orderViewModel;
        //ProductViewModel productsListViewModel;
        //CustomerViewModel addNewCustomerViewModel;

        public MainWindow()
        {
            //MainViewMode mvidemo = new MainViewMode();
            //InitializeComponent();
            //mvidemo.name = "Main form";
            //mvidemo.usmode = new US1Mode() { name = "UserControl form" };
            //this.
            //CombinedData combData = new CombinedData();
            InitializeComponent();
            this.DataContext = new NavigationViewModel();

            //CultureInfo.CurrentCulture = new CultureInfo("pl-PL", false);
            //Database1Entities db = new Database1Entities();
            //productViewModel = new ProductViewModel();
            //productData.DataContext = productViewModel;
            //productsListViewModel = new ProductViewModel();
            //productsListData.DataContext = productsListViewModel;
            //customerViewModel = new CustomerViewModel();
            //us1.DataContext = customerViewModel;

            //addNewCustomerViewModel = new CustomerViewModel();
            //AddNewCustomer.DataContext = addNewCustomerViewModel;

            //DataContext = combData;
            //customerViewModel.CustomersList = combData.cVMData.CustomersList;
            //this.DataContext = productViewModel;
            //this.DataContext = customerViewModel;
            //orderViewModel = new OrderViewModel();
            //us2.DataContext = orderViewModel;



        }

    }
    
}
