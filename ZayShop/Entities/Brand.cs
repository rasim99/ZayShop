namespace ZayShop.Entities
{
    public class Brand : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BrandPhoto> Photos { get; set; }
    }
}
