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

        public List<OrderDetailsList> GetAllDetailProductListFromBase()
        {
            List<OrderDetailsList> detailProductList = new List<OrderDetailsList>();
            try
            {
                var getAllDetailProductQuery = from orderDetail in db.OrderDetailsLists
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

        public bool AddProductToDg(int id,Product selectedProduct, int quantity, decimal price, decimal totalValue, int[] sizes, byte[] image)
        {
            bool isAdded = false;
            foreach (var item in sizes)
            {
                
                Console.WriteLine($"Add item to DG : {item}");
                
            }

            try
            {
                var newOrderDetail = new OrderDetailsList();
                newOrderDetail.Id = id;
                
                newOrderDetail.ProductId = selectedProduct.Id;
                newOrderDetail.ProductName = selectedProduct.Name;
                newOrderDetail.Quantity = quantity;
                newOrderDetail.Price = price;
                newOrderDetail.Value = totalValue;
                newOrderDetail.MaleXS = sizes[0];
                newOrderDetail.MaleS = sizes[1];
                newOrderDetail.MaleM = sizes[2];
                newOrderDetail.MaleL = sizes[3];
                newOrderDetail.MaleXL = sizes[4];
                newOrderDetail.MaleXXL = sizes[5];
                newOrderDetail.MaleXXXL = sizes[6];
                newOrderDetail.FemaleXS = sizes[7];
                newOrderDetail.FemaleS = sizes[8];
                newOrderDetail.FemaleM = sizes[9];
                newOrderDetail.FemaleL = sizes[10];
                newOrderDetail.FemaleXL = sizes[11];
                newOrderDetail.FemaleXXL = sizes[12];
                newOrderDetail.FemaleXXXL = sizes[13];
                newOrderDetail.Image = image;
                //newOrderDetail.OrderId = orderId;
                db.OrderDetailsLists.Add(newOrderDetail);
                
                //{ 
                //ProductId = newOrderDetail.ProductId,
                //ProductName = newOrderDetail.ProductName,
                //Quantity = newOrderDetail.Quantity,
                //Price = newOrderDetail.Price,
                //Value = newOrderDetail.Value,
                //MaleXS = newOrderDetail.MaleXS,
                //MaleS = newOrderDetail.MaleS,
                //MaleM = newOrderDetail.MaleM,
                //MaleL= newOrderDetail.MaleL,
                //MaleXL=newOrderDetail.MaleXL,
                //MaleXXL = newOrderDetail.MaleXXL,
                //MaleXXXL=newOrderDetail.MaleXXXL,
                //FemaleXS=newOrderDetail.FemaleXS,
                //FemaleS=newOrderDetail.FemaleS,
                //FemaleM=newOrderDetail.FemaleM,
                //FemaleL=newOrderDetail.FemaleL,
                //FemaleXL=newOrderDetail.FemaleXL,
                //FemaleXXL=newOrderDetail.FemaleXXL,
                //FemaleXXXL=newOrderDetail.FemaleXXXL
                //});
                var rowEffected = db.SaveChanges();
                isAdded = rowEffected > 0;
                return isAdded;
               


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool AddOrder(DateTime createData, DateTime dispatchData, Customer currentCustomer, decimal total, Enum.OrderStatus.Statuses status, string dName, string dStreet, string dPostcode, string dCity, string dCountry)
        {
            bool isAdded = false;
            try
            {
                Console.WriteLine($"Nazwa do wysyłki: {dName}");
                Console.WriteLine($"Nazwa klienta: {currentCustomer.Name}");
                var newOrder = new Order();
                newOrder.OrderCreate = createData;
                newOrder.DispatchDate = dispatchData;
                newOrder.CustomerId = currentCustomer.Id;
                newOrder.CustomerName = currentCustomer.Name;
                newOrder.TotalAmount = total;
                newOrder.Status = status.ToString().Trim();
                newOrder.DeliveryName = dName;
                newOrder.DeliveryStreet = dStreet;
                newOrder.DeliveryPostcode = dPostcode;
                newOrder.DeliveryCity = dCity;
                newOrder.DeliveryCountry = dCountry;
                Console.WriteLine($"STATUS : {status.ToString()}");
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

        public bool UpdateOrder(Order orderToUpdate)
        {
            bool isUpdated = false;
            try
            {
                var order = db.Orders.Find(orderToUpdate.Id);
                Console.WriteLine($"Order to Update status : {orderToUpdate.Status}");
                order.Status = orderToUpdate.Status;
                var rowEffected = db.SaveChanges();
                isUpdated = rowEffected > 0;
                Console.WriteLine("aktualizacja w bazie?");
                Console.WriteLine($"stataus : {order.Status}");
                return isUpdated;
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
                throw new Exception();
            }
            else
            {
                return db.Orders.Count();
            }
                //{
                //    return 0;
                //}
                //else
                //{
                //return db.Orders.Count()-1;
            //}
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
                int tempId = GetLastOrderIndex();
                detailOrderList.OrderId = tempId;
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
