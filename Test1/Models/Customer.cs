namespace Test1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

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
        private string street;
        public string Street { get { return street; } set { street = value; OnPropertyChanged("Street"); } }
        private string postcode;
        public string Postcode { get { return postcode; } set { postcode = value; OnPropertyChanged("Postcode"); } }
        private string city;
        public string City { get { return city; } set { city = value; OnPropertyChanged("City"); } }
        private string country;
        public string Country { get { return country; } set { country = value; OnPropertyChanged("Country"); } }
        private string email;
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }

        private string nip;

        public string NIP
        {
            get { return nip; }
            set { nip = value; OnPropertyChanged("NIP"); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<Order> orders;
        public ICollection<Order> Orders { get { return orders; } set { orders = value; OnPropertyChanged("Orders"); } }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
