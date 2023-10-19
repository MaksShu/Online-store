using System;
using System.Collections.Generic;


public class Category : BaseEntity
{
	public List<Product> Products { get; set; }

	public string ImageURL { get; set; }

	public bool isFeatured { get; set; }

}
