namespace SignalRAssignment.Models
{
    public class OrderDetail
    {
        //orderId, productId, unitPrice, quantity
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string UnitPrice { get; set; }
        public string Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
