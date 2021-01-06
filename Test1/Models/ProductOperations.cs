using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Models
{
    class ProductOperations
    {
        Database1Entities db;
        public ProductOperations()
        {

            db = new Database1Entities();
        }
        #region GetAllProductsMethod
        public List<Product> GetAllProducts()
        {
           List<Product> ProductsList = new List<Product>();
            try
            {
                var getAllQuery = from product in db.Products
                                  select product;
                foreach(var product in getAllQuery)
                {
                    ProductsList.Add(new Product { Id = product.Id, Name = product.Name, Specification = product.Specification, Price6_10 = product.Price6_10, Price11_25 = product.Price11_25, Price26_50 = product.Price26_50, Price51_100 = product.Price51_100, Price101_250 = product.Price101_250, Price251_500 = product.Price251_500 });
                }

                return ProductsList;
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }
        #endregion

        #region AddProductMethod

        public bool AddProduct(Product product)
        {
            bool isAdded = false;
            try
            {
                var newProduct = new Product();
                newProduct.Name = product.Name;
                newProduct.Specification = product.Specification;
                newProduct.Price6_10 = product.Price6_10;
                newProduct.Price11_25 = product.Price11_25;
                newProduct.Price26_50 = product.Price26_50;
                newProduct.Price51_100 = product.Price51_100;
                newProduct.Price101_250 = product.Price101_250;
                newProduct.Price251_500 = product.Price251_500;

                db.Products.Add(newProduct);
                var rowsEffected = db.SaveChanges();
                isAdded = rowsEffected > 0;
               

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isAdded;
        }

        #endregion

        #region SearchProductMethod

        public Product SearchProduct(int id)
        {
            Product product = null;
            try
            {

                var productToFind = db.Products.Find(id);
                if(productToFind != null)
                {
                    product = new Product()
                    {
                        Id = productToFind.Id,
                        Name = productToFind.Name,
                        Specification = productToFind.Specification,
                        Price6_10 = productToFind.Price6_10,
                        Price11_25 = productToFind.Price11_25,
                        Price26_50 = productToFind.Price26_50,
                        Price51_100 = productToFind.Price51_100,
                        Price101_250 = productToFind.Price101_250,
                        Price251_500 = productToFind.Price251_500,
                    };
                    
                }
                return product;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region UpdateProductMethod

        public bool UpdateProductMethod(Product productToUpdate)
        {
            bool isUpdated = false;

            try
            {
                var product = db.Products.Find(productToUpdate.Id);

                product.Name = productToUpdate.Name;
                product.Specification = productToUpdate.Specification;
                product.Price6_10 = productToUpdate.Price6_10;
                product.Price11_25 = productToUpdate.Price11_25;
                product.Price26_50 = productToUpdate.Price26_50;
                product.Price51_100 = productToUpdate.Price51_100;
                product.Price101_250 = productToUpdate.Price101_250;
                product.Price251_500 = productToUpdate.Price251_500;

                var rowsEffected = db.SaveChanges();
                isUpdated = rowsEffected > 0;
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isUpdated;
            

        }

        #endregion

        #region DeleteProductMethod

        public bool DeleteProduct(int id)
        {
            bool isDeleted = false;

            try
            {
                var productToDelete = db.Products.Find(id);
                db.Products.Remove(productToDelete);
                var rowsEffected = db.SaveChanges();
                isDeleted = rowsEffected > 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return isDeleted;


        }

        #endregion


    }
}
