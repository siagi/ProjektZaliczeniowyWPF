
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test1.Models;
using System.Windows.Media;
using Test1.Views;
using Test1.Commands;

namespace Test1.ViewModels
{
    class OrderViewModelSecond : INotifyPropertyChanged
    {

        OrderOperations orderOperationsObj;
        ProductOperations productOperationObj;
        OrderDetailsList orderDetailListObj;
        //ConnectedOrder connectedOrders;


        public OrderViewModelSecond()
        {
            orderOperationsObj = new OrderOperations();
            productOperationObj = new ProductOperations();
            orderDetailListObj = new OrderDetailsList();
            currentOrder = new Order();
            listReadingOrder = new List<Order>();
            LoadCustomersList();
            LoadProductsList();
            selectedCustomer = new Customer();
            selectedProduct = ListOfProducts[0];
            LoadCurrentOrderDetalList();
            addProductToList = new OrderCommands(AddProductToDetailList);
            //addOrderToList = new OrderCommands(AddToOrder);
            addOrderToList = new OrderCommands(AddOrderToListMethod);
            LoadOrdersList();
            productSizesTable = new int[14];
            readingOrder = new Order();
            updateOrderStatus = new OrderCommands(updateOrderStatusMethod);
            //connectedOrders = new ConnectedOrder(OrdersList, CurrentOrderDetailList);
            //connectedOrders.sortedOrderInformation(OrdersList, CurrentOrderDetailList);
            //connectedOrders = new ConnectedOrder(OrdersList, CurrentOrderDetailList);
            //connectedOrderCol = connectedOrders.sortedOrderInformation(OrdersList, CurrentOrderDetailList);
            ListReadingOrderMethod();

            //Console.WriteLine($"Lista : {ListReadingOrder[0].OrderDetailsLists[0]}");





        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private ObservableCollection<Customer> listOfCustomers;

        public ObservableCollection<Customer> ListOfCustomers
        {
            get { return listOfCustomers; }
            set { listOfCustomers = value; OnPropertyChanged("ListOfCustomers"); }
        }

        private void LoadCustomersList()
        {
            ListOfCustomers = new ObservableCollection<Customer>(orderOperationsObj.GetAllCustomers());

        }

        private ObservableCollection<Product> listOfProducts;

        public ObservableCollection<Product> ListOfProducts
        {
            get { return listOfProducts; }
            set { listOfProducts = value; OnPropertyChanged("ListOfProducts"); }
        }


        private void LoadProductsList()
        {
            ListOfProducts = new ObservableCollection<Product>(productOperationObj.GetAllProducts());
        }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set { selectedCustomer = value; OnPropertyChanged("SelectedCustomer"); }
        }

        private Order currentOrder;

        public Order CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; OnPropertyChanged("CurrentOrder"); }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged("SelectedProduct"); Console.WriteLine(selectedProduct); Update(); }
        }

        //private decimal selectedProductPrice;

        //public decimal SelectedProductPrice
        //{
        //    get
        //    {
        //        if (SelectedProduct != null)
        //        {
        //            if (SelectedProductQuantity < 10)
        //            {
        //                return SelectedProduct.Price6_10;
        //            }
        //            else
        //            {
        //                return (decimal)SelectedProduct.Price11_25;
        //            }
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }

        //}

        //private decimal selectedProductPrice;

        //public decimal SelectedProductPrice
        //{
        //    get { return (decimal)SelectedProduct.Price11_25; }
        //    set 
        //    {
        //        if (SelectedProduct != null)
        //        {
        //            if (SelectedProductQuantity < 20)
        //            {
        //                value = (decimal)SelectedProduct.Price11_25;
        //                selectedProductPrice = value;
        //            }
        //        }
        //        else
        //        {
        //            selectedProductPrice = 3;
        //        }
        //        OnPropertyChanged("SelectedProductPrice");
        //    }
        //}

        //private OrderCommands addOrderToList;

        //public OrderCommands AddOrderToList
        //{
        //    get { return addOrderToList; }
        //    set { addOrderToList = AddOrderToList; }
        //}

        //private void AddToOrder()
        //{
        //    Console.WriteLine("start");
        //    //var isAdded = orderOperationsObj.AddOrder((DateTime)CurrentOrder.OrderCreate, (DateTime)CurrentOrder.DispatchDate, SelectedCustomer);
        //    //try
        //    //{

        //    //    if (isAdded)
        //    //    {
        //    //        Console.WriteLine("Dodano zamówienie");
        //    //        Message = "Dodano zamówienie";
        //    //    }
        //    //    else
        //    //    {
        //    //        Console.WriteLine("Nie dodano zamówienia");
        //    //        Message = "Nie dodano zamówienia";
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    Message = ex.Message;
        //    //}


        //}

        private ObservableCollection<Order> ordersList;

        public ObservableCollection<Order> OrdersList
        {
            get { return ordersList; }
            set { ordersList = value; OnPropertyChanged("OrdersList"); }
        }

        private void LoadOrdersList()
        {
            OrdersList = new ObservableCollection<Order>(orderOperationsObj.GetAllOrders());
        }


        int productDetailListId;


        private decimal selectedProductPrice;

        public decimal SelectedProductPrice
        {
            get { return selectedProductPrice; }
            set { selectedProductPrice = value; OnPropertyChanged("SelectedProductPrice"); }
        }

        private int selectedProductQuantity;

        public int SelectedProductQuantity
        {
            get { return selectedProductQuantity; }
            set
            {
                selectedProductQuantity = value;
                OnPropertyChanged("SelectedProductQuantity"); Console.WriteLine(selectedProductQuantity);
                if (value <= 10) SelectedProductPrice = SelectedProduct.Price6_10;
                else if (value >= 11 && value < 25) SelectedProductPrice = (Decimal)SelectedProduct.Price11_25;
                else if (value >= 26 && value < 50) SelectedProductPrice = (Decimal)SelectedProduct.Price26_50;
                else if (value >= 51 && value < 100) SelectedProductPrice = (Decimal)SelectedProduct.Price51_100;
                else if (value >= 101 && value < 250) SelectedProductPrice = (Decimal)SelectedProduct.Price101_250;
                else if (value >= 251) SelectedProductPrice = (Decimal)SelectedProduct.Price251_500;

                SelectedProductTotalValue = SelectedProductQuantity * SelectedProductPrice;
            }
        }

        private void Update()
        {
            int value = SelectedProductQuantity;
            SelectedProductQuantity = value;
        }

        private decimal selectedProductTotalValue;

        public decimal SelectedProductTotalValue
        {
            get { return selectedProductTotalValue; }
            set
            {
                //value = SelectedProductQuantity * SelectedProductPrice;
                selectedProductTotalValue = value;
                OnPropertyChanged("SelectedProductTotalValue");
            }
        }

        //private int currentOrderId;

        //public int CurrentOrderId
        //{
        //    get { return currentOrderId; }
        //    set 
        //    {
        //        currentOrderId = CurrentOrder.Id;
        //    }
        //}

        private ObservableCollection<OrderDetailsList> currentOrderDetailList;

        public ObservableCollection<OrderDetailsList> CurrentOrderDetailList
        {
            get { return currentOrderDetailList; }
            set { currentOrderDetailList = value; OnPropertyChanged("CurrentOrderDetailList"); }
        }

        private void LoadCurrentOrderDetalList()
        {
            TotalOrderValue = 0;
            CurrentOrderDetailList = new ObservableCollection<OrderDetailsList>(orderOperationsObj.GetAllDetailProductList());
            foreach (var item in CurrentOrderDetailList)
            {
                TotalOrderValue += (decimal)item.Value;
            }
        }

        private OrderCommands addProductToList;

        public OrderCommands AddProductToList
        {
            get { return addProductToList; }
        }

        private void AddProductToDetailList()
        {
            if (orderOperationsObj.GetLastDetailOrderIndex() < 1)
            {
                productDetailListId = 0;
            }
            else
            {
                productDetailListId = orderOperationsObj.GetLastDetailOrderIndex();
            }

            //productDetailListId = orderOperationsObj.GetAllDetailProductList().Last().Id;
            foreach (var item in ProductSizesTable)
            {
                Console.WriteLine(item);
            }
            //int tempId = OrdersList.Last().Id + 1;
            bool isAdded = orderOperationsObj.AddProductToDg(++productDetailListId, SelectedProduct, SelectedProductQuantity, SelectedProductPrice, SelectedProductTotalValue, ProductSizesTable, SelectedProduct.Image);

            Console.WriteLine(orderDetailListObj.Id);

            LoadCurrentOrderDetalList();
            try
            {
                if (isAdded)
                {
                    Message = "Product has been added to the list";
                    Console.WriteLine("Dodano ");

                }
                else
                {
                    Message = "Product has not been added to the list";
                    Console.WriteLine("Nie Dodano ");
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
                Console.WriteLine("Bląd");
            }

        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private decimal totalOrderValue;

        public decimal TotalOrderValue
        {
            get { return totalOrderValue; }
            set
            {
                totalOrderValue = value; OnPropertyChanged("TotalOrderValue");
            }
        }

        private OrderCommands updateOrderStatus;
        public OrderCommands UpdateOrderStatus
        {
            get { return updateOrderStatus; }
        }
        public static Order TemporaryOrderHolder;




        //public Order TemporaryOrderHolder
        //{
        //    get { return temporaryOrderHolder; }
        //    set { temporaryOrderHolder = value;OnPropertyChanged("TemporaryOrderHolder"); }
        //}



        private void updateOrderStatusMethod()
        {
            if (TemporaryOrderHolder != null)
            {
                try
                {
                    Console.WriteLine($"{TemporaryOrderHolder.Status}");
                    bool isUpdated = orderOperationsObj.UpdateOrder(TemporaryOrderHolder);
                    if (isUpdated)
                    {
                        Console.WriteLine("updated status");
                        TemporaryOrderHolder = null;
                        LoadOrdersList();

                    }
                    else
                    {
                        Console.WriteLine("blad w updated status");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }


        private OrderCommands addOrderToList;

        public OrderCommands AddOrderToList
        {
            get { return addOrderToList; }
        }

        private void AddOrderToListMethod()
        {

            Console.WriteLine("asdasdasd");
            Console.WriteLine("start");
            Console.WriteLine($"{CurrentOrder.OrderCreate}, {CurrentOrder.DispatchDate}, {SelectedCustomer.Id}, lista : {CurrentOrderDetailList}, suma zamowienia:{CurrentOrder.TotalAmount}, status : {Enum.OrderStatus.Statuses.Nowe.ToString()}");

            try
            {
                Console.WriteLine($"{CurrentOrderDetailList.Last().ProductName}");
                var isAdded = orderOperationsObj.AddOrder(CurrentOrder.OrderCreate, CurrentOrder.DispatchDate, SelectedCustomer, TotalOrderValue, Enum.OrderStatus.Statuses.Nowe, CurrentOrder.DeliveryName, CurrentOrder.DeliveryStreet, CurrentOrder.DeliveryPostcode, CurrentOrder.DeliveryCity, CurrentOrder.DeliveryCountry);
                Console.WriteLine($"{orderOperationsObj.GetLastOrderIndex()}");
                orderOperationsObj.UpdateOrderIdInDetailList(CurrentOrderDetailList);
                LoadCurrentOrderDetalList();
                SelectedCustomer = null;
                SelectedProductQuantity = 0;
                SelectedProductPrice = 0;

                SameDeliveryAddressAsCustomerDetails(false);
                IsCheckedCheckbox = false;
                for (int i = 0; i < ProductSizesTable.Length; i++)
                {
                    ProductSizesTable[i] = 0;
                }



                if (isAdded)
                {
                    Console.WriteLine("Dodano zamówienie");
                    Message = "Dodano zamówienie";
                    Console.WriteLine($"Ostatni indeks zamowienia : {orderOperationsObj.GetLastOrderIndex()}");
                }
                else
                {
                    Console.WriteLine("Nie dodano zamówienia");
                    Message = "Nie dodano zamówienia";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }

        private int[] productSizesTable;

        public int[] ProductSizesTable
        {
            get { return productSizesTable; }
            set { productSizesTable = value; OnPropertyChanged("ProductSizesTable"); }
        }

        private int femaleXS;

        public int FemaleXS
        {
            get { return femaleXS; }
            set { femaleXS = value; OnPropertyChanged("FemaleXS"); }
        }

        //private ConnectedOrder connectedOrders;

        //public ConnectedOrder ConnectedOrders
        //{
        //    get { return connectedOrders; }
        //    set { connectedOrders = value; OnPropertyChanged("ConnectedOrders"); }
        //}

        //private ObservableCollection<ConnectedOrder> connectedOrderCol;

        //public ObservableCollection<ConnectedOrder> ConnectedOrderCol
        //{
        //    get { return connectedOrderCol; }
        //    set { connectedOrderCol = value;OnPropertyChanged("ConnectedOrderCol");}
        //}

        //private void joinTables()
        //{
        //    var joinTables 
        //}

        private Order readingOrder;

        public Order ReadingOrder
        {
            get { return readingOrder; }
            set { readingOrder = value; }
        }
        private List<Order> listReadingOrder;
        public List<Order> ListReadingOrder
        {
            get { return listReadingOrder; }
            set { listReadingOrder = value; OnPropertyChanged("ListReadingOrder"); }
        }
        private void ListReadingOrderMethod()
        {
            LoadOrdersList();
            var OrderDetailListFromBase = new ObservableCollection<OrderDetailsList>(orderOperationsObj.GetAllDetailProductListFromBase());
            Console.WriteLine($"Order Detail List : {OrderDetailListFromBase.Count}");
            Console.WriteLine($"Ilość zamówień w liście  {OrdersList.Count}");
            for (int i = 0; i < OrdersList.Count; i++)
            {
                Console.WriteLine($" Ilość ID  {OrdersList[i].Id}");
                OrdersList[i].TotalAmount = 0;
                ObservableCollection<OrderDetailsList> selectedItems = new ObservableCollection<OrderDetailsList>();
                Console.WriteLine("proba dodania do selected items");
                foreach (var item in OrderDetailListFromBase)
                {

                    if (OrdersList[i].Id == item.OrderId)
                    {
                        Console.WriteLine($"Czy rowna sie null image ? {item.Image == null}");
                        selectedItems.Add(item);
                        OrdersList[i].TotalAmount += item.Value;
                    }

                }

                Console.WriteLine(OrdersList[i].Status);
                ListReadingOrder.Add(new Order { Id = OrdersList[i].Id, OrderCreate = OrdersList[i].OrderCreate, DispatchDate = OrdersList[i].DispatchDate, CustomerId = OrdersList[i].CustomerId, TotalAmount = OrdersList[i].TotalAmount, OrderDetailsLists = selectedItems, Customer = OrdersList[i].Customer, Status = OrdersList[i].Status, DeliveryName = OrdersList[i].DeliveryName, DeliveryStreet = OrdersList[i].DeliveryStreet, DeliveryPostcode = OrdersList[i].DeliveryPostcode, DeliveryCity = OrdersList[i].DeliveryCity, DeliveryCountry = OrdersList[i].DeliveryCountry });
            }


        }

        private bool isCheckedCheckbox;

        public bool IsCheckedCheckbox
        {
            get { return isCheckedCheckbox; }
            set { isCheckedCheckbox = value; OnPropertyChanged("IsCheckedCheckbox"); SameDeliveryAddressAsCustomerDetails(IsCheckedCheckbox); }
        }

        public void SameDeliveryAddressAsCustomerDetails(bool option)
        {
            if (option == true && SelectedCustomer != null)
            {
                CurrentOrder.DeliveryName = SelectedCustomer.Name;
                CurrentOrder.DeliveryStreet = SelectedCustomer.Street;
                CurrentOrder.DeliveryPostcode = SelectedCustomer.Postcode;
                CurrentOrder.DeliveryCity = SelectedCustomer.City;
                CurrentOrder.DeliveryCountry = SelectedCustomer.Country;
            }
            else
            {
                CurrentOrder.DeliveryName = null;
                CurrentOrder.DeliveryStreet = null;
                CurrentOrder.DeliveryPostcode = null;
                CurrentOrder.DeliveryCity = null;
                CurrentOrder.DeliveryCountry = null;
            }
        }


























    }
}

