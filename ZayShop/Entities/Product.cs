namespace ZayShop.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string PhotoPath { get; set; }
        public string Size { get; set; }
        public decimal Price {  get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
