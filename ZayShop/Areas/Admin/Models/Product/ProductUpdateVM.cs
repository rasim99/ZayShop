using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Product
{
	public class ProductUpdateVM
	{
		[Required(ErrorMessage = "Please enter Title")]
		[MinLength(3, ErrorMessage = "Please enter minimum 3 character")]
		public string Title { get; set; }


		//[Required(ErrorMessage = "Please enter Photo path")]
		//[MinLength(5, ErrorMessage = "Please enter minimum 5 character")]
		//public string PhotoPath { get; set; }

		[Required(ErrorMessage = "Please enter Sizes")]
		[MinLength(1, ErrorMessage = "Please enter minimum 1 character")]
		public string Size { get; set; }

		[Required(ErrorMessage = "Please enter Price")]
		[Range(20, 2000, ErrorMessage = "Range is 20 => 2000")]
		public decimal Price { get; set; }

        public string? PhotoName { get; set; }

        public IFormFile? Photo { get; set; }

        [Required(ErrorMessage = "Please choose Category")]
		[Display(Name = "Category ")]
		public int CategoryId { get; set; }
		public List<SelectListItem>? Categories { get; set; }
	}
}
