using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Commands;
using Test1.Models;

namespace Test1.ViewModels
{
    class SupplierViewModel : INotifyPropertyChanged
    {

        SupplierOperations supplierOperationsObj;

        public SupplierViewModel()
        {
            supplierOperationsObj = new SupplierOperations();
            currentSupplier = new Supplier();
            LoadData();
            addSupplier = new SupplierCommands(Add);
            searchSupplier = new SupplierCommands(Search);
            updateSupplier = new SupplierCommands(Update);
            deleteSupplier = new SupplierCommands(Delete);
            
        }

        private ObservableCollection<Supplier> suppliersList;

        public ObservableCollection<Supplier> SuppliersList
        {
            get { return suppliersList; }
            set { suppliersList = value; OnPropertyChanged("SuppliersList"); }
        }

        private void LoadData()
        {
            SuppliersList = new ObservableCollection<Supplier>(supplierOperationsObj.GetAllSuppliers());
        }

        private Supplier currentSupplier;

        public Supplier CurrentSupplier
        {
            get { return currentSupplier; }
            set { currentSupplier = value;OnPropertyChanged("CurrentSupplier"); }
        }

        #region Add supplier

        private SupplierCommands addSupplier;

        public SupplierCommands AddSupplier
        {
            get { return addSupplier; }
        }

        private void Add()
        {
            try
            {

                var isAdded = supplierOperationsObj.AddSupplier(CurrentSupplier);
                LoadData();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Search supplier

        private SupplierCommands searchSupplier;

        public SupplierCommands SearchSupplier
        {
            get { return searchSupplier; }
            
        }

        private void Search()
        {
            try
            {
                var searchSupplier = supplierOperationsObj.Searchsupplier(CurrentSupplier.Id);
                if(searchSupplier != null)
                {

                    CurrentSupplier.Id = searchSupplier.Id;
                    CurrentSupplier.Name = searchSupplier.Name;
                    CurrentSupplier.Street = searchSupplier.Street;
                    CurrentSupplier.Postcode = searchSupplier.Postcode;
                    CurrentSupplier.City = searchSupplier.City;
                    CurrentSupplier.Country = searchSupplier.Country;
                    CurrentSupplier.Nip = searchSupplier.Nip;
                    CurrentSupplier.Email = searchSupplier.Email;
                    CurrentSupplier.Phone = searchSupplier.Phone;
                    CurrentSupplier.Type = searchSupplier.Type;
                    currentSupplier.TurnOver = searchSupplier.TurnOver;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        #region Update supplier

        private SupplierCommands updateSupplier;

        public SupplierCommands UpdateSupplier
        {
            get { return updateSupplier; }
          
        }

        private void Update()
        {
            try
            {
                bool isUpdated = supplierOperationsObj.UpdateSupplier(CurrentSupplier);
                if (isUpdated)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Delete supplier

        private SupplierCommands deleteSupplier;

        public SupplierCommands DeleteSupplier
        {
            get { return deleteSupplier; }
        }

        private void Delete()
        {
            try
            {
                bool isDeleted = supplierOperationsObj.DeleteSupplier(CurrentSupplier.Id);
                if (isDeleted)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
