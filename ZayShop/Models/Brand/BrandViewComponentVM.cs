using ZayShop.Entities;

namespace ZayShop.Models.Brand
{
    public class BrandViewComponentVM
    {
        public  Entities.Brand Brand { get; set; }
        public List<BrandPhoto> Photos { get; set; }
    }
}
