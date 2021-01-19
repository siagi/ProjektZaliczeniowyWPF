using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class CustomerOperations
    {
        Database1Entities db;
        public CustomerOperations()
        {
            db = new Database1Entities();
        }

        #region Get All Customers

        public List<Customer> GetAllCustomers()
        {
            List<Customer> CustomersList = new List<Customer>();
            try
            {
                var getAllCustomers = from customer in db.Customers
                                      select customer;
                foreach (var customer in getAllCustomers)
                {
                    CustomersList.Add(new Customer { Id = customer.Id, Name = customer.Name, Street = customer.Street, Postcode = customer.Postcode, City = customer.City, Country = customer.Country, Email = customer.Email });
                }
                Console.WriteLine("Done");

                return CustomersList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        #endregion

        #region Add Customer Method
        public bool AddCustomer(Customer customer)
        {
            bool isAdded = false;
            try
            {
                var newCustomer = new Customer()
                {
                    Name = customer.Name,
                    Street = customer.Street,
                    Postcode = customer.Postcode,
                    City = customer.City,
                    Country = customer.Country,
                    Email = customer.Email,

                };
                db.Customers.Add(newCustomer);
                var rowEffected = db.SaveChanges();
                isAdded = rowEffected > 0;
                return isAdded;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Search Customer Method
        
        public Customer SearchCustomer(int id)
        {
            Customer customer = null;
            try
            {
                var customerToFind = db.Customers.Find(id);
                if (customerToFind !=null)
                {
                    customer = new Customer()
                    {
                        Id = customerToFind.Id,
                        Name = customerToFind.Name,
                        Street = customerToFind.Street,
                        Postcode = customerToFind.Postcode,
                        City = customerToFind.City,
                        Country = customerToFind.Country,
                        Email = customerToFind.Email,
                    };
                }
                return customer;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Update Customer Method
        public bool UpdateCustomer(Customer customerToUpdate)
        {
            bool isUpdated = false;
            try
            {
                var customer = db.Customers.Find(customerToUpdate.Id);
                customer.Name = customerToUpdate.Name;
                customer.Street = customerToUpdate.Street;
                customer.Postcode = customerToUpdate.Postcode;
                customer.City = customerToUpdate.City;
                customer.Country = customerToUpdate.Country;
                customer.Email = customerToUpdate.Email;

                var rowEffected = db.SaveChanges();
                isUpdated = rowEffected > 0;
                return isUpdated;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete Customer Method
        public bool DeleteProduct(int id)
        {
            bool isDeleted = false;
            try
            {
                var customerToDelete = db.Customers.Find(id);
                db.Customers.Remove(customerToDelete);
                var rowEffected = db.SaveChanges();
                isDeleted = rowEffected > 0;
                return isDeleted;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
