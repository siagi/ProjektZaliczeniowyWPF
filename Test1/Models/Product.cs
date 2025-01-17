namespace Test1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Product : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string specification;
        public string Specification
        {
            get { return specification; }
            set { specification = value; OnPropertyChanged("Specification"); }
        }

        private decimal price6_10;
        public decimal Price6_10
        {
            get { return price6_10; }
            set { price6_10 = value; OnPropertyChanged("Price6_10"); }
        }
        private decimal price11_25;
        public Nullable<decimal> Price11_25
        {
            get { return price11_25; }
            set { price11_25 = (decimal)value; OnPropertyChanged("Price11_25"); }
        }
        private decimal price26_50;
        public Nullable<decimal> Price26_50
        {
            get { return price26_50; }
            set { price26_50 = (decimal)value; OnPropertyChanged("Price26_50"); }
        }

        private decimal price51_100;
        public Nullable<decimal> Price51_100
        {
            get { return price51_100; }
            set { price51_100 = (decimal)value; OnPropertyChanged("Price51_100"); }
        }

        private decimal price101_250;
        public Nullable<decimal> Price101_250
        {
            get { return price101_250; }
            set { price101_250 = (decimal)value; OnPropertyChanged("Price101_250"); }
        }
        private decimal price251_500;
        public Nullable<decimal> Price251_500
        {
            get { return price251_500; }
            set { price251_500 = (decimal)value; OnPropertyChanged("Price251_500"); }
        }

        private byte[] image;
        public byte[] Image { get { return image; } set { image = value; OnPropertyChanged("Image"); } }
        private string fileName;
        public string FileName { get { return fileName; } set { fileName = value; OnPropertyChanged("FileName"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                SetUpStaticPropertyProduct(this);
            }
        }

        public void SetUpStaticPropertyProduct(Product prod)
        {
            ViewModels.ProductViewModel.temporaryProduct = prod;
        }
    }
}
