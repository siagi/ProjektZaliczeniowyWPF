using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test1.Commands;

namespace Test1.ViewModels
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        public ICommand AddNewCustomerViewCommand { get; set; }
        public ICommand NewCustomerCommand { get; set; }
        public ICommand OrdersListViewCommand { get; set; }
        public ICommand OrderViewCommand { get; set; }
        public ICommand ProductsListViewCommand { get; set; }
        public ICommand ProductViewCommand { get; set; }
        public ICommand UserControl1ViewCommand { get; set; }

        public ICommand SupplierViewCommand { get; set; }
        public ICommand CostViewCommand { get; set; }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value;OnPropertyChanged("SelectedViewModel"); }
        }

        public NavigationViewModel()
        {
            AddNewCustomerViewCommand = new BaseCommand(OpenAddNewCustomerView);
            NewCustomerCommand = new BaseCommand(OpenNewCustomerCommand);
            OrdersListViewCommand = new BaseCommand(OpenOrdersListView);
            OrderViewCommand = new BaseCommand(OpenOrderView);
            ProductsListViewCommand = new BaseCommand(OpenProductsListView);
            ProductViewCommand = new BaseCommand(OpenProductView);
            UserControl1ViewCommand = new BaseCommand(OpenUserControl1View);
            SupplierViewCommand = new BaseCommand(OpenSupplierView);
            CostViewCommand = new BaseCommand(OpenCostView);
        }

        private void OpenAddNewCustomerView(object obj)
        {
            SelectedViewModel = new CustomerViewModelSecond();
        }

        private void OpenNewCustomerCommand(object obj)
        {
            SelectedViewModel = new CustomerViewModel();
        }

        private void OpenOrdersListView(object obj)
        {
            SelectedViewModel = new OrderViewModelSecond();
        }
        private void OpenOrderView(object obj)
        {
            SelectedViewModel = new OrderViewModel();
        }
        private void OpenProductsListView(object obj)
        {
            SelectedViewModel = new ProductViewModel();
        }
        private void OpenProductView(object obj)
        {
            SelectedViewModel = new ProductViewModel();
        }

        private void OpenUserControl1View(object obj)
        {
            SelectedViewModel = new UserControl1();
        }

        private void OpenSupplierView(object obj)
        {
            SelectedViewModel = new SupplierViewModel();
        }

        private void OpenCostView(object obj)
        {
            SelectedViewModel = new CostViewModel();
        }





        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
