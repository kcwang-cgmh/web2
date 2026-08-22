namespace web2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Photo { get; set; }

        // 相關訂單的導航屬性（Navigation Properties）
        public List<Order>? Orders { get; set; }
    }
}