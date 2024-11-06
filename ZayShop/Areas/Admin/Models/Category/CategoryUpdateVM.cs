﻿using System.ComponentModel.DataAnnotations;

namespace ZayShop.Areas.Admin.Models.Category
{
    public class CategoryUpdateVM
    {
        [Required(ErrorMessage ="Please enter name")]
        [MinLength(3,ErrorMessage ="Please enter minimum 3 character")]
        public string Name { get; set; }
    }
}
