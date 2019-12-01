using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace WebApplication1.Models
{
	public class User 
	{
		[Required]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "First Name")]
		public string fName { get; set; }

		[Display(Name = "Last Name")]
		public string lName { get; set; }

		[DataType(DataType.Password)]
		[Required]
		[Display(Name = "Password")]
		public string password { get; set; }

	
	}
}