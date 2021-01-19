using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class OrderOperations
    {
        Database1Entities db;
        public OrderOperations()
        {
            db = new Database1Entities();
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                var getAllCustomersQuery = from customer in db.Customers
                                           select customer;
                foreach (var customer in getAllCustomersQuery)
                {
                    customerList.Add(customer);
                }
                return customerList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<OrderDetailsList> GetAllDetailProductList()
        {
            List<OrderDetailsList> detailProductList = new List<OrderDetailsList>();
            try
            {
                var getAllDetailProductQuery = from orderDetail in db.OrderDetailsLists
                                               where orderDetail.OrderId==null
                                               select orderDetail;
                foreach (var orderDetail in getAllDetailProductQuery)
                {
                    detailProductList.Add(orderDetail);
                }
                return detailProductList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Order> GetAllOrders()
        {
            List <Order> ordersList = new List<Order>();
            try
            {
                var getAllOrdersQuery = from order in db.Orders
                                               select order;
                foreach (var order in getAllOrdersQuery)
                {
                    ordersList.Add(order);
                }
                return ordersList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool AddProductToDg(int id,Product selectedProduct, int quantity, decimal price, decimal totalValue/*, int orderId*/)
        {
            bool isAdded = false;
            
            
            try
            {
                var newOrderDetail = new OrderDetailsList();
                newOrderDetail.Id = id;
                newOrderDetail.ProductId = selectedProduct.Id;
                newOrderDetail.ProductName = selectedProduct.Name;
                newOrderDetail.Quantity = quantity;
                newOrderDetail.Price = price;
                newOrderDetail.Value = totalValue;
                //newOrderDetail.OrderId = orderId;
                db.OrderDetailsLists.Add(newOrderDetail);
                var rowEffected = db.SaveChanges();
                isAdded = rowEffected > 0;
                return isAdded;

                

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool AddOrder(DateTime createData, DateTime dispatchData, Customer currentCustomer)
        {
            bool isAdded = false;
            try
            {
                var newOrder = new Order();
                newOrder.OrderCreate = createData;
                newOrder.DispatchDate = dispatchData;
                newOrder.CustomerId = currentCustomer.Id;
                db.Orders.Add(newOrder);
                var rowEffected = db.SaveChanges();
                isAdded = rowEffected > 0;
                return isAdded;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetLastOrderIndex()
        {
            if (db.Orders.Count() < 1 || db.Orders.Count().Equals(null))
            {
                return 0;
            }
            else
            {
                return db.Orders.Count();
            }
        }

        public void UpdateOrderIdInDetailList(ObservableCollection<OrderDetailsList> list)
        {

            ////List<OrderDetailsList> listToUpdateOrderId = new List<OrderDetailsList>();
            //   var listToUpdateOrderId = from item in db.OrderDetailsLists
            //                          select item;

            //foreach (var item in listToUpdateOrderId)
            //{
            //    item.OrderId = 1;
            //}

            foreach (var item in list)
            {
                var detailOrderList = db.OrderDetailsLists.Find(item.Id);
                Console.WriteLine($"Przed : {detailOrderList.ProductName} = {detailOrderList.OrderId}");
                Console.WriteLine("Ustawiam Indeks");
                detailOrderList.OrderId = GetLastOrderIndex();
                Console.WriteLine($"Po : {detailOrderList.ProductName} = {detailOrderList.OrderId}");
                Console.WriteLine("Ustawilem Indeks");
                db.SaveChanges();
                Console.WriteLine("Zapisałem Indeks");
            }

        }

        public int GetLastDetailOrderIndex()
        {
            return db.OrderDetailsLists.Count();
        }


    }
}
