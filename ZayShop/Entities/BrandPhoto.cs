namespace ZayShop.Entities
{
    public class BrandPhoto:BaseEntity
    {
        public string PhotoPath { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}
