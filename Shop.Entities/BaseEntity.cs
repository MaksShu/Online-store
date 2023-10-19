using System;
using System.ComponentModel.DataAnnotations;

public class BaseEntity
{
	
	public int ID { get; set; }
	[Required]
	[MinLength(5),MaxLength(50)]
	public string Name { get; set; }
	[MaxLength(500)]
	public string Description { get; set; }


}
