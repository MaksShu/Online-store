﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shop.Web.ViewModels
{
        public class NewCategoryViewModels
        {
            [Required]
            [MinLength(5),MaxLength(50)]
            public string Name { get; set; }
            [MaxLength(500)]
            public string Description { get; set; }

            public int CategoryID { get; set; }

            public string ImageURL { get; set; }

            public bool isFeatured { get; set; }

        }

        public class CategorySearchViewModel
        {
            public List<Category> Categories { get; set; }
            public string SearchTerm { get; set; }
            public Pager Pager { get; set; }
        }
    
        public class EditCategoryViewModel
        {
            public int ID { get; set; }

            public string Name { get; set; }
            
            public string Description { get; set; }
            
            public string ImageURL { get; set; }

            public bool isFeatured { get; set; }
        }
}
