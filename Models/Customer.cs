namespace SignalRAssignment.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Password { get; set; }
        public string ContactName { get; set; }
        //address
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
