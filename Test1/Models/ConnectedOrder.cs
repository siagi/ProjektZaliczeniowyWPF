using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Models
{
   
   public  class ConnectedOrder
    {
        private ObservableCollection<Order> mainOrderInformation;

        public ObservableCollection<Order> MainOrderInformation
        {
            get { return mainOrderInformation; }
            set { mainOrderInformation = value; }
        }

        private ObservableCollection<OrderDetailsList> detailOrderInformation;

        public ObservableCollection<OrderDetailsList> DetailOrderInformation
        {
            get { return detailOrderInformation; }
            set { detailOrderInformation = value; }
        }

        public ConnectedOrder(ObservableCollection<Order> mainOrderInformation, ObservableCollection<OrderDetailsList> detailOrderInformation)
        {
            MainOrderInformation = mainOrderInformation;
            DetailOrderInformation = detailOrderInformation;
        }


        public ObservableCollection<ConnectedOrder> sortedOrderInformation(ObservableCollection<Order> mainOrderInfo, ObservableCollection<OrderDetailsList> detailOrderInfo)
        {
            ObservableCollection<ConnectedOrder> customList = new ObservableCollection<ConnectedOrder>();
            Console.WriteLine("odpalam");
            for (int i = 0; i < mainOrderInfo.Count; i++)
            {
                Console.WriteLine("odpalam2");
                foreach (var item in detailOrderInfo)
                {
                    if(mainOrderInfo[i].Id ==item.OrderId)
                    {
                        Console.WriteLine("odpalam3");
                    }
                }
            }
            return customList;
        }
    }
}
