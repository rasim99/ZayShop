using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Slider
{
    public class SliderCreateVM
    {
        [Required(ErrorMessage = "Please enter name")]
        [MinLength(5, ErrorMessage = "Please enter minimum 5 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [MinLength(4, ErrorMessage = "Please enter minimum 4 character")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Photo url")]
        [MinLength(5, ErrorMessage = "Please enter minimum 5 character")]
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [MinLength(8, ErrorMessage = "Please enter minimum 8 character")]
        public string Description { get; set; }

    }
}
