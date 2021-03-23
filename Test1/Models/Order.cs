namespace Test1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Test1.ViewModels;

    public partial class Order : INotifyPropertyChanged, IComparable<Order>, IEquatable<Order>, IComparer<Order>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {

            //this.OrderDetailsLists = new HashSet<OrderDetailsList>();
        }

        private int id;
        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        private Nullable<int> customerId;
        public Nullable<int> CustomerId { get { return customerId; } set { customerId = value; OnPropertyChanged("CustomerId"); } }
        private DateTime orderCreate;
        public DateTime OrderCreate { get { return orderCreate; } set { orderCreate = value; OnPropertyChanged("OrderCreate"); } }
        private DateTime dispatchDate;
        public DateTime DispatchDate { get { return dispatchDate; } set { dispatchDate = value; OnPropertyChanged("DispatchDate"); } }
        private Customer customer;
        public Customer Customer { get { return customer; } set { customer = value; OnPropertyChanged("Customer"); } }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ObservableCollection<OrderDetailsList> orderDetailsLists;
        public ObservableCollection<OrderDetailsList> OrderDetailsLists { get { return orderDetailsLists; } set { orderDetailsLists = value; OnPropertyChanged("OrderDetailsLists"); } }

        private Nullable<decimal> totalAmount;
        public Nullable<decimal> TotalAmount { get { return totalAmount; } set { totalAmount = value; OnPropertyChanged("TotalAmount"); } }

        private string deliveryName;
        public string DeliveryName { get { return deliveryName; } set { deliveryName = value; OnPropertyChanged("DeliveryName"); Console.WriteLine("zmieni³ nazwe"); } }
        private string deliveryStreet;
        public string DeliveryStreet { get { return deliveryStreet; } set { deliveryStreet = value; OnPropertyChanged("DeliveryStreet"); } }
        private string deliveryPostcode;
        public string DeliveryPostcode { get { return deliveryPostcode; } set { deliveryPostcode = value; OnPropertyChanged("DeliveryPostcode"); } }
        private string deliveryCity;
        public string DeliveryCity { get { return deliveryCity; } set { deliveryCity = value; OnPropertyChanged("DeliveryCity"); } }
        private string deliveryCountry;
        public string DeliveryCountry { get { return deliveryCountry; } set { deliveryCountry = value; OnPropertyChanged("DeliveryCountry"); } }
        private string deliveryEmail;
        public string DeliveryEmail { get { return deliveryEmail; } set { deliveryEmail = value; OnPropertyChanged("DeliveryEmail"); } }
        private string status;
        public string Status { get { return status; } set { status = value; OnPropertyChanged("Status"); updateTemporaryOrderholder(this); Console.WriteLine($"{this}{Id}{Status}"); } }
        private string trackingNumber;
        public string TrackingNumber { get { return trackingNumber; } set { trackingNumber = value; OnPropertyChanged("TrackingNumber"); } }

        private string customerName;
        public string CustomerName { get { return customerName; } set { customerName = value; OnPropertyChanged("CustomerName"); } }

        private ICollection<Cost> costs { get; set; }
        public ICollection<Cost> Costs { get { return costs; } set { costs = value;OnPropertyChanged("Costs"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        public void updateTemporaryOrderholder(Order ord)
        {

            Console.WriteLine($"przekazano{ord.Status}");
            OrderViewModel.TemporaryOrderHolder = ord;

        }


        public bool Equals(Order other)
        {
            if (other is null) return false;
            if (object.ReferenceEquals(this, other)) return true;

            return (DispatchDate == other.DispatchDate);
        }

        public override bool Equals(object obj)
        {
            if (obj is Order)
                return Equals((Order)obj);
            else return false;
        }

        public override int GetHashCode()
        {
            return (DispatchDate).GetHashCode();
        }

        public static bool Equals(Order o1, Order o2)
        {
            if ((o1 is null) && (o2 is null)) return true;
            if ((o1 is null)) return false;
            return o1.Equals(o2);
        }

        public static bool operator ==(Order o1, Order o2) => Equals(o1, o2);
        public static bool operator !=(Order o1, Order o2) => !Equals(o1, o2);

        public int CompareTo(Order other)
        {
            if (other is null) return 1;
            if (this.Equals(other)) return 0;
            return this.DispatchDate.CompareTo(other.DispatchDate);
        }

        public int Compare(Order x, Order y)
        {
            if (x is null && y is null) return 0;
            if (x is null && !(y is null)) return -1;
            if (!(x is null) && y is null) return 1;

            return x.DispatchDate.CompareTo(y.DispatchDate);
        }

        public override string ToString()
        {
            return $"Nr zamówienia: {Id}";
        }
    }
}
