using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.Models;

namespace Test1.ViewModels
{

    public class UserControl1 : INotifyPropertyChanged
    {
        OrderOperations raportOrderOperation;
      

        private int newOrderStatus;

        public int NewOrderStatus
        {
            get { return newOrderStatus; }
            set { newOrderStatus = value; OnPropertyChanged("NewOrderStatus"); }
        }

        private int productionOrderStatus;

        public int ProductionOrderStatus
        {
            get { return productionOrderStatus; }
            set { productionOrderStatus = value; OnPropertyChanged("ProductionOrderStatus"); }
        }

        private int deliveredOrderStatus;

        public int DeliveredOrderStatus
        {
            get { return deliveredOrderStatus; }
            set { deliveredOrderStatus = value; OnPropertyChanged("NewOrderStatus"); }
        }

        public UserControl1()
        {
            raportOrderOperation = new OrderOperations();
            LoadOrdersList();
            Console.WriteLine("Konstruktor");

            GetOrdersStatus();
            ConvertedObservableCollectionOrdersListToList();
            FirstToDispatchOrdersListMethod();
            //Console.WriteLine(OrdersList[0].Customer.Name);


        }

        private ObservableCollection<Order> ordersList;

        public ObservableCollection<Order> OrdersList
        {
            get { return ordersList; }
            set { ordersList = value; OnPropertyChanged("OrdersList"); }
        }

        private List<Order> listOrdersList;

        public List<Order> ListOrdersList
        {
            get { return listOrdersList; }
            set { listOrdersList = value; OnPropertyChanged("ListOrdersList"); }
        }


        public void ConvertedObservableCollectionOrdersListToList()
        {
            ListOrdersList = new List<Order>(OrdersList);
            ListOrdersList.Sort((x, y) => -x.Id.CompareTo(y.Id));

        }

        private List<Order> firstToDispatchOrdersList;

        public List<Order> FirstToDispatchOrdersList
        {
            get { return firstToDispatchOrdersList; }
            set { firstToDispatchOrdersList = value; OnPropertyChanged("FirstToDispatchOrdersList"); }
        }


        public void FirstToDispatchOrdersListMethod()
        {
            FirstToDispatchOrdersList = new List<Order>(OrdersList);
            FirstToDispatchOrdersList.Sort((x, y) => x.DispatchDate.CompareTo(y.DispatchDate));

        }

        private void LoadOrdersList()
        {
            OrdersList = new ObservableCollection<Order>(raportOrderOperation.GetAllOrders());
           
        }

       

      







        private void GetOrdersStatus()
        {
            int newOrderStatusIndex = 0;
            int productionOrderStatusIndex = 0;
            int deliveredOrderStatusIndex = 0;
            foreach (var item in OrdersList)
            {
                Console.WriteLine($"Item status name :{item.Status}:");
                
                
                if (item.Status.Trim() =="Nowe")
                {
                    newOrderStatusIndex = newOrderStatusIndex + 1;
                }
                else if(item.Status.Trim() == "Produkcja")
                {
                    productionOrderStatusIndex++;
                }

                else if(item.Status.Trim() == "Dostarczone")
                {
                    deliveredOrderStatusIndex++;
                }
               

            }
            NewOrderStatus = newOrderStatusIndex;
            ProductionOrderStatus = productionOrderStatusIndex;
            DeliveredOrderStatus = deliveredOrderStatusIndex;

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
