namespace SignalRAssignment.Models
{
    public class Product
    {
        //productId, productName, supplierId, categoryId, quantityPerUnit, unitPrice, productImage
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
