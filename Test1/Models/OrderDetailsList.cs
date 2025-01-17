//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class OrderDetailsList : INotifyPropertyChanged
    {
        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        private Nullable<int> productId;
        public Nullable<int> ProductId { get { return productId; } set { productId = value; OnPropertyChanged("ProductId"); } }
        private string productName;
        public string ProductName { get { return productName; } set { productName = value; OnPropertyChanged("ProductName"); } }
        private Nullable<int> quantity;
        public Nullable<int> Quantity { get { return quantity; } set { quantity = value; OnPropertyChanged("Quantity"); } }
        private Nullable<decimal> price;
        public Nullable<decimal> Price { get { return price; } set { price = value; OnPropertyChanged("Price"); } }
        private Nullable<decimal> value;
        public Nullable<decimal> Value { get { return value; } set { this.value = value; OnPropertyChanged("Value"); } }
        private Nullable<int> orderId;
        public Nullable<int> OrderId { get { return orderId; } set { orderId = value; OnPropertyChanged("OrderId"); } }

        #region Male Sizes Properties

        private Nullable<int> maleXS;
        public Nullable<int> MaleXS { get { return maleXS; } set { maleXS = value; OnPropertyChanged("MaleXS"); } }

        private Nullable<int> maleS;
        public Nullable<int> MaleS { get { return maleS; } set { maleS = value; OnPropertyChanged("MaleS"); } }
        private Nullable<int> maleM;
        public Nullable<int> MaleM { get { return maleM; } set { maleM = value; OnPropertyChanged("MaleM"); } }
        private Nullable<int> maleL;
        public Nullable<int> MaleL { get { return maleL; } set { maleL = value; OnPropertyChanged("MaleL"); } }
        private Nullable<int> maleXL;
        public Nullable<int> MaleXL { get { return maleXL; } set { maleXL = value; OnPropertyChanged("MaleXL"); } }
        private Nullable<int> maleXXL;
        public Nullable<int> MaleXXL { get { return maleXXL; } set { maleXXL = value; OnPropertyChanged("MaleXXL"); } }
        private Nullable<int> maleXXXL;
        public Nullable<int> MaleXXXL { get { return maleXXXL; } set { maleXXXL = value; OnPropertyChanged("MaleXXXL"); } }

        #endregion

        #region Female Sizes Pproperties

        private Nullable<int> femaleXS;
        public Nullable<int> FemaleXS { get { return femaleXS; } set { femaleXS = value; OnPropertyChanged("FemaleXS"); } }

        private Nullable<int> femaleS;
        public Nullable<int> FemaleS { get { return femaleS; } set { femaleS = value; OnPropertyChanged("FemaleS"); } }
        private Nullable<int> femaleM;
        public Nullable<int> FemaleM { get { return femaleM; } set { femaleM = value; OnPropertyChanged("FemaleM"); } }
        private Nullable<int> femaleL;
        public Nullable<int> FemaleL { get { return femaleL; } set { femaleL = value; OnPropertyChanged("FemaleL"); } }
        private Nullable<int> femaleXL;
        public Nullable<int> FemaleXL { get { return femaleXL; } set { femaleXL = value; OnPropertyChanged("FemaleXL"); } }
        private Nullable<int> femaleXXL;
        public Nullable<int> FemaleXXL { get { return femaleXXL; } set { femaleXXL = value; OnPropertyChanged("FemaleXXL"); } }
        private Nullable<int> femaleXXXL;
        public Nullable<int> FemaleXXXL { get { return femaleXXXL; } set { femaleXXXL = value; OnPropertyChanged("FemaleXXXL"); } }

        #endregion
        private byte[] image;
        public byte[] Image { get { return image; } set { image = value; OnPropertyChanged("Image"); } }


        private Order order;
        public Order Order { get { return order; } set { order = value; OnPropertyChanged("Order"); } }

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

