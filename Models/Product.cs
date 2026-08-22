namespace web2.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[]? Photo { get; set; }
        public string? Description { get; set; }

        // 相關訂單的導航屬性（Navigation Properties）
        public List<Order>? Orders { get; set; }
    }
}