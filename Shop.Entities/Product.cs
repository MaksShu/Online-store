using System;
using System.ComponentModel.DataAnnotations;
public class Product : BaseEntity
{
	public virtual Category Category { get; set; }

	[Range(1,100000)]
	public decimal Price { get; set; }

	public string ImageURL { get; set; }

}