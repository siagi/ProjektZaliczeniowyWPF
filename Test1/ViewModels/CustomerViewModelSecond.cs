
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Models;
using Test1.Commands;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Test1.ViewModels
{
    public class CustomerViewModelSecond : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        CustomerOperations customerOperationsObj;
        public CustomerViewModelSecond()
        {
            customerOperationsObj = new CustomerOperations();
            LoadData();
            addCustomerCommand = new CustomerCommands(Add);
            searchCustomerCommand = new CustomerCommands(Search);
            updateCustomerCommand = new CustomerCommands(Update);
            CurrentCustomer = new Customer();
        }

        private string customerOperationResultMessage;

        public string CustomerOperationResultMessage
        {
            get { return customerOperationResultMessage; }
            set { customerOperationResultMessage = value; OnPropertyChanged("CustomerOperationResultMessage"); }
        }


        private ObservableCollection<Customer> customersList;

        public ObservableCollection<Customer> CustomersList
        {
            get { return customersList; }
            set { customersList = value; OnPropertyChanged("CustomersList"); }
        }

        private void LoadData()
        {
            CustomersList = new ObservableCollection<Customer>(customerOperationsObj.GetAllCustomers());
        }

        private Customer currentCustomer;

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; OnPropertyChanged("CurrentCustomer"); }
        }

        #region Add Customer
        private CustomerCommands addCustomerCommand;

        public CustomerCommands AddCustomerCommands
        {
            get { return addCustomerCommand; }
        }

        public void Add()
        {
            try
            {
                var isSaved = customerOperationsObj.AddCustomer(CurrentCustomer);
                LoadData();
                if (isSaved)
                {
                    CustomerOperationResultMessage = "Customer has been added";
                }
                else
                {
                    CustomerOperationResultMessage = "Customer has not been added";
                }


            }
            catch (Exception ex)
            {

                CustomerOperationResultMessage = ex.Message;
            }
        }


        #endregion

        #region Search Customer
        private CustomerCommands searchCustomerCommand;

        public CustomerCommands SearchCustomerCommand
        {
            get { return searchCustomerCommand; }
            set { searchCustomerCommand = value; }
        }

        public void Search()
        {
            try
            {
                var customerObj = customerOperationsObj.SearchCustomer(CurrentCustomer.Id);
                if (customerObj != null)
                {
                    CurrentCustomer.Id = customerObj.Id;
                    CurrentCustomer.Name = customerObj.Name;
                    CurrentCustomer.Street = customerObj.Street;
                    CurrentCustomer.Postcode = customerObj.Postcode;
                    CurrentCustomer.City = customerObj.City;
                    CurrentCustomer.Country = customerObj.Country;
                    CurrentCustomer.Email = customerObj.Email;
                    CustomerOperationResultMessage = "Customer has been found";

                }
                else
                {
                    CustomerOperationResultMessage = "Customer has not been found";
                }
            }
            catch (Exception ex)
            {

                CustomerOperationResultMessage = ex.Message;
            }
        }

        #endregion

        #region Update Customer

        private CustomerCommands updateCustomerCommand;

        public CustomerCommands UpdateCustomerCommand
        {
            get { return updateCustomerCommand; }
            set { updateCustomerCommand = value; }
        }

        public void Update()
        {
            bool isUpdated = false;
            try
            {
                isUpdated = customerOperationsObj.UpdateCustomer(CurrentCustomer);
                if (isUpdated)
                {
                    LoadData();
                    CustomerOperationResultMessage = "Customer has updated";
                }
                else
                {
                    CustomerOperationResultMessage = "Customer has not updated";
                }
            }
            catch (Exception ex)
            {

                CustomerOperationResultMessage = ex.Message;
            }

        }
        #endregion

        #region Delete Customer

        private CustomerCommands deleteCustomerCommand;

        public CustomerCommands DeleteCustomerCommand
        {
            get { return deleteCustomerCommand; }
            set { deleteCustomerCommand = value; }
        }

        public void Delete()
        {
            bool isDeleted;
            try
            {
                isDeleted = customerOperationsObj.DeleteProduct(CurrentCustomer.Id);
                if (isDeleted)
                {
                    LoadData();
                    CustomerOperationResultMessage = "Customer has beed deleted";

                }
                else
                {
                    CustomerOperationResultMessage = "Customer has not beed deleted";
                }
            }
            catch (Exception ex)
            {

                CustomerOperationResultMessage = ex.Message;
            }
        }


        #endregion




    }
}
