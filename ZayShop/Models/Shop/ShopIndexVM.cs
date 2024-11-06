using ZayShop.Models.Category;
using ZayShop.Models.Product;

namespace ZayShop.Models.Shop
{
	public class ShopIndexVM
	{
        public List<CategoryVM> Categories { get; set; }
        public List<ProductVM> Products { get; set; }
    }
}
