using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class SupplierOperations
    {
        Database1Entities db;
        public SupplierOperations()
        {
            db = new Database1Entities();
        }

        #region Get All Suppliers

        public List<Supplier> GetAllSuppliers()
        {
          
            List<Supplier> SuppliersList = new List<Supplier>();
            try
            {
                var getSuppliers = from supplier in db.Suppliers
                                   select supplier;

                foreach (var supplier in getSuppliers)
                {
                    SuppliersList.Add(new Supplier { Id = supplier.Id, Name = supplier.Name, Street = supplier.Street, Postcode = supplier.Postcode, City = supplier.City, Country = supplier.Country, Nip = supplier.Nip, Email = supplier.Email, Phone = supplier.Phone, TurnOver = supplier.TurnOver, Type = supplier.Type });
                }
                return SuppliersList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Add Supplier

        public bool AddSupplier(Supplier supplier)
        {
            
            bool isAdded;
            try
            {
                Supplier newSupplier = new Supplier()
                {
                    Name = supplier.Name,
                    Street = supplier.Street,
                    Postcode = supplier.Postcode,
                    City = supplier.City,
                    Country = supplier.Country,
                    Nip = supplier.Nip,
                    Email = supplier.Email,
                    Phone = supplier.Phone,
                    
                    TurnOver = supplier.TurnOver,
                };
                newSupplier.Type = supplier.Type;
                db.Suppliers.Add(newSupplier);
                var rowEffected = db.SaveChanges();
                isAdded = rowEffected > 0;
                Console.WriteLine(isAdded);
                return isAdded;
            }
            catch (Exception ex)
            {
                Console.WriteLine("BłAD ?");
                throw ex;
            }
        }

        #endregion

        #region Search Supplier

        public Supplier Searchsupplier(int id)
        {
            Supplier supplier = null;
            Supplier searchingSupplier = db.Suppliers.Find(id);
            if(searchingSupplier != null)
            {
                supplier = new Supplier()
                {
                    Name = searchingSupplier.Name,
                    Street = searchingSupplier.Street,
                    Postcode = searchingSupplier.Postcode,
                    City = searchingSupplier.City,
                    Country = searchingSupplier.Country,
                    Nip = searchingSupplier.Nip,
                    Email = searchingSupplier.Email,
                    Phone = searchingSupplier.Phone,
                    Type = searchingSupplier.Type,
                    TurnOver = searchingSupplier.TurnOver,
                };
                
            }
            return supplier;

        }

        #endregion

        #region Update Supplier

        public bool UpdateSupplier(Supplier supplierToUpdate)
        {
            bool isUpdated = false;
            try
            {

                Supplier supplier = db.Suppliers.Find(supplierToUpdate.Id);
                supplier.Name = supplierToUpdate.Name;
                supplier.Street = supplierToUpdate.Street;
                supplier.Postcode = supplierToUpdate.Postcode;
                supplier.City = supplierToUpdate.City;
                supplier.Country = supplierToUpdate.Country;
                supplier.Nip = supplierToUpdate.Nip;
                supplier.Email = supplierToUpdate.Email;
                supplier.Phone = supplierToUpdate.Phone;
                supplier.Type = supplierToUpdate.Type;
                supplier.TurnOver = supplierToUpdate.TurnOver;

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

        #region Delete Supplier

        public bool DeleteSupplier(int id)
        {
            bool isDeleted = false;
            try
            {
                Supplier supplierToDelete = db.Suppliers.Find(id);
                db.Suppliers.Remove(supplierToDelete);
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
