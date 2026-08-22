namespace web2.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShipAddress { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // 導航屬性（Navigation Properties）
        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
    }
}