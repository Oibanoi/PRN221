namespace SignalRAssignment.Models
{
    public class Category
    {
        //categoryId, categoryName, description
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
