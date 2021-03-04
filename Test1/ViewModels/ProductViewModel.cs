using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Test1.Models;
using Test1.Commands;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows;

namespace Test1.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public static Product temporaryProduct;

        ProductOperations productOperationObj;
        
        public ProductViewModel()
        {
            productOperationObj = new ProductOperations();
            LoadData();
            CurrentProduct = new Product();
            saveProductCommand = new ProductCommands(Save);
            searchProductCommand = new ProductCommands(Search);
            updateProductCommand = new ProductCommands(Update);
            deleteProductCommand = new ProductCommands(Delete);
            updateTempProductCommand = new ProductCommands(UpdateTemp);
            openFileImageProductCommand = new ProductCommands(OpenFileDialog);
        }
        #region Display products
        private ObservableCollection<Product> productsList;

        public ObservableCollection<Product> ProductsList
        {
            get { return productsList; }
            set { productsList = value; OnPropertyChanged("ProductsList"); Console.WriteLine("zmiana tu"); }
        }

        private void LoadData()
        {
            ProductsList = new ObservableCollection<Product>(productOperationObj.GetAllProducts());
        }
        #endregion

        

        private Product currentProduct;

        public Product CurrentProduct
        {
            get { return currentProduct; }
            set { currentProduct = value; OnPropertyChanged("CurrentProduct"); }
        }

        private string productOperationResultMessage;

        public string ProductOperationResultMessage
        {
            get { return productOperationResultMessage; }
            set { productOperationResultMessage = value;OnPropertyChanged("ProductOperationResultMessage"); }
        }

        #region Add Product

        private ProductCommands saveProductCommand;

        public ProductCommands SaveProductCommand
        {
            get { return saveProductCommand; }
        }

        public void Save()
        {
            try
            {
                
                var isSaved = productOperationObj.AddProduct(currentProduct);
                LoadData();
                if (isSaved)
                {
                    ProductOperationResultMessage = "Product has been added";
                }
                else
                {
                    ProductOperationResultMessage = "Product has not been added";
                }
                
            }
            catch (Exception ex)
            {
                ProductOperationResultMessage = ex.Message;

            }
        }
        #endregion

        #region Search Product
        private ProductCommands searchProductCommand;

        public ProductCommands SearchProductCommand
        {
            get { return searchProductCommand; }
        }

        public void Search()
        {
            try
            {
                var productObj = productOperationObj.SearchProduct(currentProduct.Id);
                if(productObj != null)
                {
                    currentProduct.Id = productObj.Id;
                    currentProduct.Name = productObj.Name;
                    currentProduct.Specification = productObj.Specification;
                    currentProduct.Price6_10 = productObj.Price6_10;
                    currentProduct.Price11_25 = productObj.Price11_25;
                    currentProduct.Price26_50 = productObj.Price26_50;
                    currentProduct.Price51_100 = productObj.Price51_100;
                    currentProduct.Price101_250 = productObj.Price101_250;
                    currentProduct.Price251_500 = productObj.Price251_500;
                    currentProduct.FileName = productObj.FileName;
                    currentProduct.Image = productObj.Image;
                    ProductOperationResultMessage = "Product found";
                }
                else
                {
                    ProductOperationResultMessage = "Product did not find.";
                }
            }
            catch (Exception ex)
            {

                ProductOperationResultMessage = ex.Message;
            }
        }
        #endregion

        #region Update Product
        private ProductCommands updateProductCommand;

        public ProductCommands UpdateProductCommand
        {
            get { return updateProductCommand; }
        }

        private ProductCommands updateTempProductCommand;

        public ProductCommands UpdateTempProductCommand
        {
            get { return updateTempProductCommand; }
        }

        public void Update()
        {
            try
            {
                Console.WriteLine("odpalilem");
                bool isUpdated = false;
                isUpdated = productOperationObj.UpdateProductMethod(CurrentProduct);
                if(isUpdated)
                {
                    LoadData();
                    ProductOperationResultMessage = "Product has been updated";
                }
                else
                {
                    ProductOperationResultMessage = "Product has not been updated";
                }

            }
            catch (Exception ex)
            {

                ProductOperationResultMessage = ex.Message;
            }
        }

        public void UpdateTemp()
        {
            try
            {
                
                Console.WriteLine("temporary odpalilem");
                bool isUpdated = false;
                isUpdated = productOperationObj.UpdateProductMethod(temporaryProduct);
                if (isUpdated)
                {
                    LoadData();
                    ProductOperationResultMessage = "From Product has been updated";
                }
                else
                {
                    ProductOperationResultMessage = "Product has not been updated";
                }

            }
            catch (Exception ex)
            {

                ProductOperationResultMessage = ex.Message;
            }
        }

        #endregion

        #region Delete Product

        private ProductCommands deleteProductCommand;

        public ProductCommands DeleteProductCommand
        {
            get { return deleteProductCommand; }
        }

        public void Delete()
        {
            try
            {
                bool isDeleted = false;
                isDeleted = productOperationObj.DeleteProduct(CurrentProduct.Id);
                if(isDeleted)
                {
                    ProductOperationResultMessage = "Product has been deleted";
                    LoadData();
                }
                else
                {
                    ProductOperationResultMessage = "Product has not been deleted";
                }

            }
            catch (Exception ex)
            {

                ProductOperationResultMessage = ex.Message;
            }
        }

        private ProductCommands openFileImageProductCommand;

        public ProductCommands OpenFileImageProductCommand
        {
            get { return openFileImageProductCommand; }
        }
        private void OpenFileDialog()
        {
            Console.WriteLine("asdasd");
            OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
           
            if(ofd.ShowDialog() == true)
            {
                
                Console.WriteLine("asdasd");
                currentProduct.FileName = ofd.FileName;
                Console.WriteLine(currentProduct.FileName);
            }
            Console.WriteLine("zamiana na strumien byte");
            using (var stream = new MemoryStream())
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(new BitmapImage(new Uri(currentProduct.FileName))));
                encoder.Save(stream);
                CurrentProduct.Image = stream.ToArray();
                Console.WriteLine("udalo sie ");
                Console.WriteLine(CurrentProduct.Image);


            }

        }

        


        #endregion




    }
}
