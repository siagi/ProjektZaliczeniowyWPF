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
    class CostViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        
        OrderOperations orderOperationsObj;
        SupplierOperations supplierOperationsObj;
        CostOperations costOperationObj;
        public CostViewModel()
        {
            currentCost = new Cost();
            orderOperationsObj = new OrderOperations();
            supplierOperationsObj = new SupplierOperations();
            costOperationObj = new CostOperations();
            LoadData();
            suppliersList = new ObservableCollection<Supplier>(supplierOperationsObj.GetAllSuppliers());
            ordersList = new ObservableCollection<Order>(orderOperationsObj.GetAllOrders());
            addCost = new CostCommands(Add);
            searchCost = new CostCommands(Search);
            updateCost = new CostCommands(Update);
            deleteCost = new CostCommands(Delete);
            currentCost.PurchaseDate = DateTime.Today;
           

            
            //Console.WriteLine($" nr faktury {CostsList[0].InvoiceNr}");

        }

        private ObservableCollection<Supplier> suppliersList;

        public ObservableCollection<Supplier> SuppliersList
        {
            get { return suppliersList; }
            set { suppliersList = new ObservableCollection<Supplier>(supplierOperationsObj.GetAllSuppliers());OnPropertyChanged("SuppliersList"); }
        }

        private ObservableCollection<Order> ordersList;

        public ObservableCollection<Order> OrdersList
        {
            get { return ordersList; }
            set { ordersList = new ObservableCollection<Order>(orderOperationsObj.GetAllOrders()); OnPropertyChanged("OrdersList"); }
        }


        private Cost currentCost;

        public Cost CurrentCost
        {
            get { return currentCost; }
            set { currentCost = value; OnPropertyChanged("CurrentCost"); }
        }

        #region Load costs list

        private ObservableCollection<Cost> costsList;

        public ObservableCollection<Cost> CostsList
        {
            get { return costsList; }
            set { costsList = value; OnPropertyChanged("CostsList"); }
        }

        private void LoadData()
        {
            CostsList = new ObservableCollection<Cost>(costOperationObj.GetAllCosts());
        }

        #endregion

        #region Add cost

        private CostCommands addCost;

        public CostCommands AddCost
        {
            get { return addCost; }
        }

        private void Add()
        {

            try
            {
                var isAdded = costOperationObj.AddCost(CurrentCost);
                Console.WriteLine("jestem tu");
                if (isAdded)
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

        #region Search cost

        private CostCommands searchCost;

        public CostCommands SearchCost
        {
            get { return searchCost; }
           
        }

        private void Search()
        {
            var searchCost = costOperationObj.SearchCost(currentCost.Id);
            if (searchCost != null)
            {
                CurrentCost.InvoiceNr = searchCost.InvoiceNr;
                CurrentCost.PurchaseDate = searchCost.PurchaseDate;
                CurrentCost.Description = searchCost.Description;
                CurrentCost.CostType = searchCost.CostType;
                CurrentCost.Supplier = searchCost.Supplier;
                CurrentCost.SupplierId = searchCost.SupplierId;
                CurrentCost.OrderId = searchCost.OrderId;
                CurrentCost.ValueNetto = searchCost.ValueNetto;

            }
        }


        #endregion

        #region Update cost

        private CostCommands updateCost;

        public CostCommands UpdateCost
        {
            get { return updateCost; }
        
        }

        private void Update()
        {
            try
            {
                bool isUpdated = costOperationObj.UpdateCost(CurrentCost);
                if (isUpdated)
                {
                    LoadData();
                }
            }
            catch (Exception ex )
            {

                throw ex;
            }

        }

        #endregion

        #region Delete cost

        private CostCommands deleteCost;

        public CostCommands DeleteCost
        {
            get { return deleteCost; }
         
        }

        private void Delete()
        {
            var isDeleted = costOperationObj.DeleteCost(CurrentCost.Id);
                if(isDeleted)
            {
                LoadData();
            }
        }


        #endregion

        private Order selectedOrder;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value;OnPropertyChanged("SelectedOrder"); CurrentCost.OrderId = SelectedOrder.Id; }
        }

        private Supplier selectedSupplier;

        public Supplier SelectedSupplier
        {
            get { return selectedSupplier; }
            set { selectedSupplier = value; OnPropertyChanged("SelectedSupplier"); CurrentCost.CostType = SelectedSupplier.Type.ToString().Trim(); CurrentCost.Supplier = SelectedSupplier.Name.ToString().Trim(); CurrentCost.SupplierId = SelectedSupplier.Id; }
        }



    }
}
